namespace SimpleRDS.DataLayer.Business
{
    public interface IQuantityGrouping<out T>
    {
        int Quantity { get; }
        T Item { get; }
    }

    public class QuantityGrouping<T> : IQuantityGrouping<T>
    {
        public int Quantity { get; }
        public T Item { get; }

        public QuantityGrouping(int quantity, T item)
        {
            Quantity = quantity;
            Item = item;
        }
    }
}