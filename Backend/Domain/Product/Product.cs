﻿using Backend.Domain.DesignPattern;
using Backend.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Models;
public partial class Product : Subject
{
    private IProductRepository _repository;
    private List<Observer> _observers;

    public void SetName(string name)
    {
        if (name.IsNullOrEmpty()) throw new ArgumentException("empty name");
        if (name.Length > 128) throw new ArgumentException("too long name");
        if (!ValidationHelpers.IsValidString(name)) throw new ArgumentException("invalid character input", name);
        this.Name = name;
    }

    public void SetDescription(string description)
    {
        if (description.IsNullOrEmpty()) throw new ArgumentException("empty description");
        if (description.Length > 512) throw new ArgumentException("too long description");
        if (!ValidationHelpers.IsValidString(description)) throw new ArgumentException("invalid character input", description);
        this.Description = description;
    }

    public void SetFingerPrint(int fingerPrint)
    {
        if (fingerPrint == 0) throw new ArgumentException("empty fingerPrint");
        if (fingerPrint > 128) throw new ArgumentException("too long fingerPrint");
        if (!ValidationHelpers.IsValidNumber(fingerPrint)) throw new ArgumentException("invalid character input", fingerPrint.ToString());
        this.FingerPrint = fingerPrint;
    }

    public void SetCategory(Category category)
    {
        if (category.ToString().IsNullOrEmpty()) throw new ArgumentException("empty description");
        this.Category = category;
    }
    public void SetImages(List<string> images)
    {
        if (images.IsNullOrEmpty()) throw new ArgumentException("no images");
        this.Images = images;
    }

    public void SetPrice(decimal price)
    {
        // if (price == null) throw new ArgumentNullException("price");
        if (price == 0) throw new ArgumentException("empty price");
        if (price > 128) throw new ArgumentException("too long price");
        if (!ValidationHelpers.IsValidNumber((int)price)) throw new ArgumentException("invalid character input", price.ToString());
        this.Price = price;
    }

    public void SetFeatures(string features)
    {
        if (features != null)
        {
            if (features.Length > 256) throw new ArgumentException("too long features");
            if (!ValidationHelpers.IsValidString(features)) throw new ArgumentException("invalid character input", features);
        }
        this.Features = features;
    }

    public void SetRepository(IProductRepository repository)
    {
        this._repository = repository;
    }

    public void Save()
    {
        if (this._repository == null) throw new ArgumentNullException("repository not found");
        if (this.Product_code == 0) _repository.Create(this);
        else _repository.Set(this.Product_code, this);
    }

    public void AddObserver(Observer obs)
    {
        _observers.Add(obs);
    }

    public void RemoveObserver(Observer obs)
    {
        _observers.Remove(obs);
    }

    public void Notify()
    {
        foreach(var obs in _observers) obs.Update();
    }

    public void UpdateStock(int quantity)
    {
        this.Quantity -= quantity;
        Notify();
    }
}