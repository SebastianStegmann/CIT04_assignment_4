using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataServiceLayer;

public class DataService
{
    private readonly NorthwindContext _context;

    public DataService()
    {
        _context = new NorthwindContext();
    }

    public List<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategory(int id)
    {
        // return _context.Categories.Single(c => c.Id == id);
        return _context.Categories.Find(id);
    }

    public Category CreateCategory(string name, string description)
    {
int newId = _context.Categories.Any() ? _context.Categories.Max(c => c.Id) + 1 : 1;
      var category = new Category { Id = newId, Name = name, Description = description };
        _context.Categories.Add(category);
        _context.SaveChanges();
        return category;
    }

    public bool DeleteCategory(int id)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
            return false;
        _context.Categories.Remove(category);
        _context.SaveChanges();
        return true;
    }

    public bool UpdateCategory(int id, string name, string description)
    {
        var category = _context.Categories.Find(id);
        if (category == null)
            return false;
        category.Name = name;
        category.Description = description;
        _context.SaveChanges();
        return true;
        
    }

    public Product GetProduct(int id)
    {
        // return _context.Categories.Single(c => c.Id == id);
        return _context.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
    } 

    public List<Product> GetProductByCategory(int id)
    {
        return _context.Products.Include(p => p.Category).Where(p => p.CategoryId == id).ToList();
    }

    public List<Product> GetProductByName(string name)
    {
        return _context.Products
        .Include(p => p.Category)
        .AsEnumerable() 
        .Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
        .ToList();}


    public Order GetOrder(int id)
    {
        // return _context.Categories.Single(c => c.Id == id);
return _context.Orders
    .Include(o => o.OrderDetails)
    .ThenInclude(od => od.Product)
    .ThenInclude(p => p.Category)
    .FirstOrDefault(o => o.Id == id);    }

}
