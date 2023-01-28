
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Api.Helpers;
using ShopBridge.Api.ModelDTO;
using ShopBridge.Core.Entities.Products;
using ShopBridge.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            try
            {
                var dbDto = _IMapper.Map<ProductModelDto, ProductModel>(model);
                var response = await _IProductReposiyory.CreateEntity(dbDto);

                if (response)
                {
                    return Ok(new ResponseHelper<ProductModelDto>(null, null, "Product has been created successfully!",
                        HttpStatusCode.Created));
                }
                return BadRequest(new ResponseHelper<ProductModelDto>(null, null, "Something wents wrong, Please contact admin !",
                        HttpStatusCode.BadRequest));

            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, $"exception has been occured in " +
                    $"{nameof(InventoryController)} in action {nameof(CreateProduct)}" +
                    $" exception : {ex.InnerException}");

                return BadRequest(new ResponseHelper<ProductModelDto>(null, null, "Something wents wrong, Please contact admin !",
                       HttpStatusCode.BadRequest));
            }
        }


        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetProductList()
        {
            try
            {
                var dbResponse = await _IProductReposiyory.GetAllEntities(x => x.IsDeleted == false);
                var response = _IMapper.Map<List<ProductModel>, List<ProductModelDto>>(dbResponse.ToList());
                return Ok(new ResponseHelper<ProductModelDto>(null, response, "Success", HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, $"exception has been occured in " +
                     $"{nameof(InventoryController)} in action {nameof(CreateProduct)}" +
                     $" exception : {ex.InnerException}");

                return BadRequest(new ResponseHelper<ProductModelDto>(null, null, "Something wents wrong, Please contact admin !",
                       HttpStatusCode.BadRequest));
            }

        }


        [HttpPatch]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> UpdateProductDetail(ProductModelDto model)
        {
            try
            {
                var updateModel = _IMapper.Map<ProductModelDto, ProductModel>(model);
                var response = await _IProductReposiyory.UpdateEntity(updateModel);
                if (response)
                {
                    return Ok(new ResponseHelper<ProductModelDto>(null, null, "Product has been updated successfully!",
                        HttpStatusCode.Created));
                }
                return BadRequest(new ResponseHelper<ProductModelDto>(null, null, "Something wents wrong, Please contact admin !",
                        HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, $"exception has been occured in " +
                         $"{nameof(InventoryController)} in action {nameof(UpdateProductDetail)}" +
                         $" exception : {ex.InnerException}");

                return BadRequest(new ResponseHelper<ProductModelDto>(null, null, "Something wents wrong, Please contact admin !",
                       HttpStatusCode.BadRequest));
            }

        }

        [HttpDelete]
        [Produces("application/json")]
        [Consumes("application/json")]

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            try
            {
                var deleteModel = await _IProductReposiyory.GetSingleEntity(x => x.Id == productId);
                if (deleteModel != null)
                {
                    deleteModel.IsDeleted = true;
                }
                var deleteResponse = await _IProductReposiyory.DeleteEntity(deleteModel);
                if (deleteResponse)
                {
                    return Ok(new ResponseHelper<ProductModelDto>(null, null, "Product has been updated successfully!",
                        HttpStatusCode.Created));
                }
                return BadRequest(new ResponseHelper<ProductModelDto>(null, null, "Something wents wrong, Please contact admin !",
                        HttpStatusCode.BadRequest));
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message, $"exception has been occured in " +
                        $"{nameof(InventoryController)} in action {nameof(DeleteProduct)}" +
                        $" exception : {ex.InnerException}");

                return BadRequest(new ResponseHelper<ProductModelDto>(null, null, "Something wents wrong, Please contact admin !",
                       HttpStatusCode.BadRequest));

            }

        }
    }
}
