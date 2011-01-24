using System;

namespace MonoDroidSamples
{
    public class MenuItem
    {
        public string Label { get; set; }
        public Type Type { get; set; }

        public MenuItem()
        {
        }

        public MenuItem(string label, Type type)
        {
            Label = label;
            Type = type;
        }
    }
}