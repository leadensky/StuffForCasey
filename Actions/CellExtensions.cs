using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Actions
{
    public static class CellExtensions
    {
        public static void LockCells(this IEnumerable<Cell> cells)
        {
            cells.Process(c => c.IsLocked = true);
        }

        public static void UnlockCells(this IEnumerable<Cell> cells)
        {
            cells.Process(c => c.IsLocked = false);
        }

        public static void AutoName(this IEnumerable<Cell> cells)
        {
            var index = 65; //"A" in ASCII
            cells.Process(c =>
            {
                c.SetName(Convert.ToChar(index).ToString());
                index++;
            });
        }

        public static void Process(this IEnumerable<Cell> cells, Action<Cell> doThisTo)
        {
            foreach(var aCell in cells)
            {
                doThisTo(aCell);
            }
        }

        public static T Process<T>(this IEnumerable<Cell> cells, Func<Cell, bool> predicate, Func<Cell, T> getValue)
        {
            var cell = cells.Where(predicate).FirstOrDefault();
            if (cell == null)
                return default(T);

            return getValue(cell);


        }
    }
}
