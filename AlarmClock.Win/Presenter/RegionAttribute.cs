using System;

namespace AlarmClock.Win.Presenter
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RegionAttribute
       : Attribute
    {
        public RegionAttribute(string name, string parentName="")
        {
            Name = name;
            ParentName = parentName;
        }

        public string Name { get; private set; }
        public string ParentName { get; private set; }
    }
}
