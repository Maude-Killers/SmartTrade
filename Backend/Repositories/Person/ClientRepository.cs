using Backend.Database;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;
using SmartTrade.Models;

namespace Backend.Repositories;
public class ClientRepository : IClientRepository
{
    private readonly AppDbContext _context;
    private readonly IProductRepository _productRepository;

    public ClientRepository(AppDbContext context)
    {
        _context = context;
        _productRepository = new ProductRepository(context);
    }

    public void Create(Client client)
    {
        if (_context.Client.Any(x => x.Email == client.Email)) throw new ResourceNotFound("Client already exists", client);

        ClientEntity clientEntity = new ClientEntity
        {
            Email = client.Email,
            FullName = client.FullName,
            Password = client.Password,
            PhoneNumber = client.PhoneNumber,
        };

        _context.Client.Add(clientEntity);
        _context.SaveChanges();
    }

    public void Delete(string Email)
    {
        var targetClient = _context.Client
            .Where(client => client.Email == Email)
            .FirstOrDefault();

        if (targetClient == null) throw new InvalidOperationException();

        _context.Client.Remove(targetClient);
        _context.SaveChanges();
    }

    public Client Get(string email)
    {
        ClientEntity clientEntity = _context.Client
            .Include(c => c.WishList).ThenInclude(w => w.listProducts)
            .Include(c => c.GiftList).ThenInclude(g => g.listProducts)
            .Include(c => c.LaterList).ThenInclude(n => n.listProducts)
            .Include(c => c.ShoppingCart).ThenInclude(p => p.listProducts)
            .First(c => c.Email == email);

        Client client = new Client
        {
            Email = clientEntity.Email,
            Password = clientEntity.Password,
            FullName = clientEntity.FullName,
            PhoneNumber = clientEntity.PhoneNumber,
            GiftList = clientEntity.GiftList.listProducts
                .Select(x => _productRepository.Get(x.Product_code)).ToList(),
            LaterList = clientEntity.LaterList.listProducts
                .Select(x => _productRepository.Get(x.Product_code)).ToList(),
            ShoppingCart = clientEntity.ShoppingCart.listProducts
                .Select(x => _productRepository.Get(x.Product_code)).ToList(),
            WishList = clientEntity.ShoppingCart.listProducts
                .Select(x => _productRepository.Get(x.Product_code)).ToList(),
        };

        return client ?? throw new ResourceNotFound("Client email don't exists", email);
    }

    public Client? GetByCredentials(string Email, string Password)
    {
        ClientEntity clientEntity = _context.Client
            .Where(client => client.Email == Email && client.Password == Password)
            .First() ?? throw new ResourceNotFound("Client not found", (Email, Password));

        Client client = new Client
        {
            Email = clientEntity.Email,
            Password = clientEntity.Password,
            FullName = clientEntity.FullName,
            PhoneNumber = clientEntity.PhoneNumber,
            GiftList = clientEntity.GiftList.listProducts
                .Select(x => _productRepository.Get(x.Product_code)).ToList(),
            LaterList = clientEntity.LaterList.listProducts
                .Select(x => _productRepository.Get(x.Product_code)).ToList(),
            ShoppingCart = clientEntity.ShoppingCart.listProducts
                .Select(x => _productRepository.Get(x.Product_code)).ToList(),
            WishList = clientEntity.ShoppingCart.listProducts
                .Select(x => _productRepository.Get(x.Product_code)).ToList(),
        };

        return client;
    }

    public List<Client> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Set(string Email, Client client)
    {
        var actualClient = _context.Client
            .Where(client => client.Email == Email)
            .FirstOrDefault();

        if (actualClient == null) throw new InvalidOperationException();

        actualClient.Password = client.Password;
        _context.SaveChanges();
    }
}