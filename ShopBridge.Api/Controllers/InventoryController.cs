
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Api.ModelDTO;
using ShopBridge.Core.Entities.Products;
using ShopBridge.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/{version:apiVersion}/[controller]/[action]")]


    public class InventoryController : ControllerBase
    {
        private readonly IRepository<ProductModel, int> _IProductReposiyory;
        private readonly IMapper _IMapper;
        public InventoryController(IRepository<ProductModel, int> productRepository, IMapper mapper)
        {
            _IProductReposiyory = productRepository;
            _IMapper = mapper;
        }

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> CreateProduct(ProductModelDto model)
        {
            var dbDto = _IMapper.Map<ProductModelDto, ProductModel>(model);
            var response = await _IProductReposiyory.CreateEntity(dbDto);
            return Ok("sdfshd");
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetProductList()
        {
            var dbResponse = await _IProductReposiyory.GetAllEntities(x => x.IsDeleted == false);
            var response = _IMapper.Map<List<ProductModel>, List<ProductModelDto>>(dbResponse.ToList());
            return Ok(response);
        }


        [HttpPatch]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateProductDetail(ProductModelDto model)
        {
            var updateModel = _IMapper.Map<ProductModelDto, ProductModel>(model);
            var response = await _IProductReposiyory.UpdateEntity(updateModel);
            return Ok("");
        }

        [HttpDelete]
        [Produces("application/json")]
        [Consumes("application/json")]

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            var deleteModel = await _IProductReposiyory.GetSingleEntity(x => x.Id == productId);
            if (deleteModel != null)
            {
                deleteModel.IsDeleted = true;
            }
            var deleteResponse = await _IProductReposiyory.DeleteEntity(deleteModel);
            return Ok("");
        }
    }
}
