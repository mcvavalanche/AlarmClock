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
            ParentType = null;
        }

        /// <summary>
        /// Useful for specifing the parent of leaf children
        /// </summary>
        /// <param name="parentType">Type of the parent view</param>
        public RegionAttribute(Type parentType)
        {
            ParentType = parentType;
        }
        
        public Type ParentType { get; private set; }
    }
}
