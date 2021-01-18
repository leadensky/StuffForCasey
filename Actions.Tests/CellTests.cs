using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Actions.Tests
{
    public class CellTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Can_Lock_Cells()
        {
            var cells = new List<Cell>
            {
                new Cell(),
                new Cell(),
                new Cell()
            };
            Assert.IsFalse(cells.Any(x => x.IsLocked == true));

            cells.LockCells();

            Assert.IsTrue(cells.All(x => x.IsLocked == true));
        }

        [Test]
        public void Can_Auto_Name_Cells()
        {
            var cells = new List<Cell>
            {
                new Cell(),
                new Cell(),
                new Cell()
            };
            cells.AutoName();
            cells[1].IsLocked = true;

            var actual = cells.Process<string>(x => x.IsLocked == true, x => x.Name);

            Assert.That(actual, Is.EqualTo("B"));
        }
    }
}