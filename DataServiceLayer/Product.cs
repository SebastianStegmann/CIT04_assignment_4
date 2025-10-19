    public class Product
    {
      public int Id { get; set; }
      public string Name { get; set; }
      public double UnitPrice { get; set; }
      public int CategoryId { get; set; }
      public string QuantityPerUnit { get; set; }
      public int UnitsInStock { get; set; }
      public Category Category { get; set; }
      
      public string ProductName { get => Name;}
      public string CategoryName { get => Category?.Name; }
    }
