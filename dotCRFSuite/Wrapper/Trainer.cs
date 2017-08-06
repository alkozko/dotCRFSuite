using System;
using System.Collections.Generic;
using System.Linq;

namespace dotCRFSuite.Wrapper
{
    public class Trainer: IDisposable
    {
        private readonly global::Trainer _trainer;

        public Trainer()
        {
            _trainer = new global::Trainer();
            _trainer.select("lbfgs", "crf1d");
        }

        public void Append(IEnumerable<IEnumerable<KeyValuePair<string, object>>> xseq, IEnumerable<string> yseq)
        {
            var _yseq = new StringList(yseq.ToList());

            _trainer.append(new ItemSequence(xseq).Items, _yseq, 0);
        }

        public void SetParams(IDictionary<string,string> @params)
        {
            foreach (var param in @params)
            {
                _trainer.set(param.Key,param.Value);
            }
        }

        public IEnumerable<string> Parameters()
        {
           return _trainer.params_();
        }

        public void Train(string modelName)
        {
            _trainer.train(modelName, -1);
        }

        public void Clear()
        {
            _trainer.clear();
        }

        public void Dispose()
        {
            _trainer?.Dispose();
        }
    }
}