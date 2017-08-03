using System;
using NUnit.Framework;

namespace dotCRFSuite.Tests
{
    public class Tests
    {
        [Test]
        public void Test()
        {
            var trainer = new Wrapper.Trainer();


            var parameters = trainer.Parameters();
            foreach (var parameter in parameters)
            {
                Console.WriteLine(parameter);                
            }
        }
    }
}
