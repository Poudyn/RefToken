using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace RefToken
{
    internal class RefService
    {
        private readonly object _parent;
        private object _currentValue;

        internal RefService(object parent)
        {
            _parent = parent;
        }
        private object GetValue(object parentObject, string name)
        {
            PropertyInfo propertyInfo = parentObject.GetType().GetProperty(name);
            if (propertyInfo != null)
            {
                object value = propertyInfo.GetValue(parentObject);
                if (value != null)
                {
                    return value;
                }
            }
            return null;
        }
        private bool PropertyExists(object parentObject, OPath oPath)
        {
            object value = GetValue(parentObject, oPath.Name);
            if (value != null)
            {
                _currentValue = value;
                return true;
            }
            return false;
        }
        private bool ItemExists(object parentObject, OIPath oIPath)
        {
            object value = GetValue(parentObject, oIPath.Name);
            if (value != null)
            {
                if (value is IList collection)
                {
                    object item = collection[oIPath.Index];
                    if (item != null)
                    {
                        _currentValue = item;
                        return true;
                    }
                }
            }
            return false;
        }
        private bool PathIsValid(OPath oPath)
        {
            if (_currentValue == null)
            {
                if (oPath is OIPath oiPath)
                {
                    return ItemExists(_parent, oiPath);
                }
                else
                {
                    return PropertyExists(_parent, oPath);
                }
            }
            else
            {
                if (oPath is OIPath oiPath)
                {
                    return ItemExists(_currentValue, oiPath);
                }
                else
                {
                    return PropertyExists(_currentValue, oPath);
                }
            }
        }
        internal bool PathsExist(List<OPath> paths)
        {
            bool found = true;
            foreach (var i in paths)
            {
                if (!PathIsValid(i))
                {
                    found = false;
                    break;
                }
            }
            return found;
        }
        internal object FinalValue
        {
            get
            {
                return _currentValue;
            }
        }
    }
}
