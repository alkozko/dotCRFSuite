using System;
using System.Collections.Generic;
using System.Linq;

namespace dotCRFSuite.Wrapper
{
    public class Tagger: IDisposable
    {
        private readonly global::Tagger _tagger;

        public Tagger()
        {
            _tagger = new global::Tagger();
        }

        public void Open(string modelName)
        {
            _tagger.open(modelName);
        }

        public string[] Tag(IEnumerable<IEnumerable<KeyValuePair<string, object>>> input)
        {
            return _tagger.tag(new ItemSequence(input).Items).Select(x => x).ToArray();
        }

        public void Dispose()
        {
            _tagger?.Dispose();
        }
    }
}