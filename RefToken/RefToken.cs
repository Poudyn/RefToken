using System;
using System.Collections.Generic;

namespace RefToken
{
    public class RefToken
    {
        private readonly List<OPath> _paths;
        public RefToken(string path)
        {
            _paths = string.IsNullOrEmpty(path) ? throw new Exception("ObjectPath cannot be empty") : Parser.Parse(path);
        }
        public bool Select<T>(object obj, out T result)
        {
            RefService refService = new(obj);
            if (refService.PathsExist(_paths))
            {
                result = (T)refService.FinalValue;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }
        public static bool Select<T>(object obj, string path, out T result)
        {
            List<OPath> paths = Parser.Parse(path);
            RefService refService = new(obj);
            if (refService.PathsExist(paths))
            {
                result = (T)refService.FinalValue;
                return true;
            }
            else
            {
                result = default;
                return false;
            }
        }
    }
}
