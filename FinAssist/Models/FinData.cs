namespace FinAssist.Model
{
    public class FinData
    {
        public double Price { get; set; }
        public int ProductCount { get; set; }

        public FinData(double price = 0, int count = 0)
        {
            Price = price;
            ProductCount = count;
        }
    }
}
