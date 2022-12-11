using System;
using Xunit;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AsyncDesign;

namespace Unfoldit.Tests
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

        public override async IAsyncEnumerable<Assembly> DesignGenerator()
        {
            var random = new Random();
            for (int i = 0; i < 1; i++) // versions
            {
                var version = new TestAssembly(random.Next(100), Number);
                // add sub Components
                for (int j = 0; j < 3; j++)
                    version.Components.Add(new TestComponent(random.Next(100), Number * 10 + j));
                if (random.Next(10) < 6) // add a sub-Assembly
                {
                    version.Components.Add(new TestAssembly(random.Next(100), Number * 10 + 8));
                }
                if (random.Next(10) < 6) // add a sub-Assembly
                {
                    version.Components.Add(new TestAssembly(random.Next(100), Number * 10 + 9));
                }
                yield return version;
            }
        }
    }

    public class UnfoldItTest
    {
        [Fact]
        public async void Test1()
        {
            var testAssembly = new TestAssembly(0, 2);
            await testAssembly.Design();
            
            var a = testAssembly.Components.Select(i => i.Cost).ToArray();
            ;
        }
    }
}
