using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

namespace Backend.Repositories;

public class LaterListRepository : ILaterListRepository
{
    private readonly AppDbContext _context;

    public LaterListRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddProduct(Product product, Client client)
    {
        LaterList laterList = client.LaterList;
        var isInList = laterList.listProducts.Where(x => x.Product_code == product.Product_code && x.List_code == laterList.List_code).FirstOrDefault();
        if (isInList != null)
        {
            throw new ResourceNotFound("product is already in GiftList", product);
        }
        _context.ListProducts.Add(new ListProduct { List_code = laterList.List_code, Product_code = product.Product_code });
        _context.SaveChanges();
    }

    public void DeleteProduct(Product product, Client client)
    {
        var laterList = client.LaterList;
        var productList = laterList.listProducts
            .Where(x => x.Product_code == product.Product_code)
            .FirstOrDefault();

        if (laterList == null || productList == null) throw new ResourceNotFound("list or productList not found", product);

        _context.ListProducts.Remove(productList);
        _context.SaveChanges();
    }

    public List<Product> GetProducts(Client client)
    {
        _context.Entry(client).Reference(client => client.LaterList).Load();
        var listCodes = _context.ListProducts
            .Include(lp => lp.Product).ThenInclude(p => p.Images)
            .Where(lp => lp.List_code == client.LaterList.List_code)
            .ToList();
            
        return listCodes.Select(lc => lc.Product).ToList();
    }
}