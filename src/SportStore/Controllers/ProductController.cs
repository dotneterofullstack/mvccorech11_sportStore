using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        IProductRepository repository;
        public int pageSize = 4;

        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1) 
            => View(new ProductsListViewModel {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PageInfo {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ? 
                        repository.Products.Count() :
                        repository.Products.Where(
                            e => e.Category == category).Count()
                },
                CurrentCategory = category
            });
    }
}
