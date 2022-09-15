namespace ShopStructure
{
    public class Good
    {
        public string Name { get; init; }
        public int Price { get; init; }
        public Good(string name, int price)
        {
            Name = name;
            Price = price;
        }

    }
}
