using System;

namespace Lab04_ProductManager
{
    public class Product : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0) throw new ArgumentException("Đơn giá không được âm.");
                price = value;
            }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0) throw new ArgumentException("Số lượng không được âm.");
                quantity = value;
            }
        }

        public Product(string id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Mã SP: {Id,-10} | Tên SP: {Name,-20} | Giá: {Price,-10} | SL: {Quantity}";
        }
    }
}