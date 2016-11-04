using System;

namespace AlarmClock.Win.Presenter
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RegionAttribute
       : Attribute
    {
        /// <summary>
        /// ctor useful for specifing the name of root parents 
        /// </summary>
        public RegionAttribute()
        {
            HostType = null;
        }

        /// <summary>
        /// Useful for specifing the parent of leaf children
        /// </summary>
        /// <param name="hostType">Type of the parent view</param>
        public RegionAttribute(Type hostType)
        {
            HostType = hostType;
        }
        
        public Type HostType { get; private set; }
    }
}
