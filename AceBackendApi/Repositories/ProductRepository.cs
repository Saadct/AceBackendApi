using AceBackend.Data;
using AceBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace AceBackend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        /*
        public async Task<Produit> GetByIdAsync(string id)
        {
            return await _context.Produits.FindAsync(id);
        }
        */
        public async Task<Product> GetByIdAsync(string id)
        {
            var produit = await _context.Produits.FindAsync(id);

            if (produit == null)
            {
                throw new KeyNotFoundException($"Le produit avec l'ID {id} n'a pas été trouvé.");
            }

            return produit;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Produits.ToListAsync();
        }

        public async Task AddAsync(Product entity)
        {
            await _context.Produits.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _context.Produits.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var produit = await GetByIdAsync(id);
            if (produit != null)
            {
                _context.Produits.Remove(produit);
                await _context.SaveChangesAsync();
            }
        }


    }
}
