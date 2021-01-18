using System;

namespace Actions
{
    public class Cell
    {
        public bool IsLocked { get; set; }
        public string Name { get; private set; }
        public void SetName(string name)
        {
            Name = name;
        }
    }
}
