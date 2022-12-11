namespace AsyncDesign
{
    public abstract class Component
    {
        public double Cost = 0;

        protected Component(double cost)
        {
            Cost = cost;
        }
    }  
}
