using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;

namespace AsyncAggregate.Tests
{

    public class TestComponent : Component
    {
        public int Number;

        public TestComponent(double cost, int number) : base(cost)
        {
            Number = number;
        }
    }


    public class TestAssembly : Assembly
    {
        public int Number;

        public TestAssembly(double cost, int number) : base(cost)
        {
            Number = number;
        }

        public override async IAsyncEnumerable<Assembly> AssemblyVersionGenerator()
        {
            var random = new Random();
            for (int i = 0; i < 1; i++) // versions
            {
                var version = new TestAssembly(random.Next(100), Number);
                // add sub Components
                for (int j = 0; j < 5; j++)
                    version.Components.Add(new TestComponent(i*1000 + random.Next(100), Number * 10 + j));
                for (int j = 0; j < 5; j++)
                    if (Number < 100000 && random.Next(10) < 8) // add a sub-Assembly
                    {
                        version.Components.Add(new TestAssembly(i * 1000 + random.Next(100), Number * 10 + 9));
                    }
                
                yield return version;
            }
        }
    }

    public class AsyncManufactureTest1
    {
        [Fact]
        public async void Test1()
        {
            var testAssembly = new TestAssembly(0, 2);
            await testAssembly.ManufactureAsync();
            
            var a = testAssembly.Components.Select(i => i.Cost).ToArray();
            ;
        }
    }
}
