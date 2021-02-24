namespace GenericsAssignment1
{
    class Product
    {
        public Product(string name, double price, int quantity, string type)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Type = type;
        }

        public string Name;
        public double Price;
        public int Quantity;
        public string Type;
    }
}

