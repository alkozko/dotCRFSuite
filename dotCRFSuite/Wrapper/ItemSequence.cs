using System;
using System.Collections.Generic;
using System.Linq;

namespace dotCRFSuite.Wrapper
{
    public class ItemSequence
    {
        private Item[] _items;

        public ItemSequence(IEnumerable<IEnumerable<KeyValuePair<string, object>>> xseq)
        {
            _items = xseq
                .Select(x => new Item(x.Select(a => CreateAttribute(a.Key, a.Value)).ToArray()))
                .ToArray();
        }

        private Attribute CreateAttribute(string argKey, object argValue)
        {
            if (argValue is bool)
                return new Attribute(argKey, (bool)argValue ? 1.0 : 0.0);
            if (argValue is string)
                return new Attribute($"{argKey}={(string)argValue}", 1.0);
            if (argValue is double)
                return new Attribute(argKey, (double)argValue);
            if (argValue is int)
                return new Attribute(argKey, (int) argValue);

            throw new ArgumentException();
        }


        internal global::ItemSequence Items => new global::ItemSequence(_items);
    }
}