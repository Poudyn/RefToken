using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RefToken
{
    internal static class Parser
    {
        private const string PROPERTY_PATTERN = "^([a-zA-Z]+)$";
        private const string COLLECTION_PATTERN = "([a-zA-Z]+)\\[(\\d)\\]";
        private static bool IsProperty(string path, out Match match)
        {
            match = Regex.Match(path, PROPERTY_PATTERN);
            return match.Success;
        }
        private static bool IsCollection(string path, out Match match)
        {
            match = Regex.Match(path, COLLECTION_PATTERN);
            return match.Success;
        }
        internal static List<OPath> Parse(string path)
        {
            string[] properties = path.Split(".", StringSplitOptions.RemoveEmptyEntries);
            List<OPath> oPaths = new();
            foreach (var i in properties)
            {
                if (IsProperty(i, out Match propertyMatch))
                {
                    oPaths.Add(new OPath { Name = propertyMatch.Groups[1].Value });
                }
                else if (IsCollection(i, out Match collectionMatch))
                {
                    oPaths.Add(new OIPath { Name = collectionMatch.Groups[1].Value, Index = int.Parse(collectionMatch.Groups[2].Value) });
                }
                else
                {
                    throw new Exception("unknown path : " + i);
                }
            }
            return oPaths;
        }
    }
}
