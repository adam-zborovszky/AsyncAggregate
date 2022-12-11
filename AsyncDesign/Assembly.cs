using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncDesign
{
    public abstract class Assembly : Component
    {
        public List<Component> Components = new List<Component>();

        protected Assembly(double cost) : base(cost)
        {
        }

        public abstract IAsyncEnumerable<Assembly> DesignGenerator();

        public async Task Design()
        {
            Cost = double.MaxValue;
            await foreach (var version in DesignGenerator())
            {
                // safety
                if (version == null)
                    continue;

                // recursively unfold this version, then collect Components and cost
                var versionComponents = new List<Component>();
                double versionCost = 0;
                foreach (var component in version.Components)
                    if (component is Assembly assemblyComponent)
                    {
                        await assemblyComponent.Design();
                        versionComponents.AddRange(assemblyComponent.Components);
                        versionCost += assemblyComponent.Cost;
                    }
                    else
                    {
                        versionComponents.Add(component);
                        versionCost += component.Cost;
                    }
                        
                // evaluate version and replace actual version if cheaper
                if (versionCost < Cost)
                {
                    Components = versionComponents;
                    Cost = versionCost;
                }
            }
        }
    }
}
