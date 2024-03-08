using API_Practice.Contracts;
using API_Practice.Dtos;
using API_Practice.Models;
using API_Practice.PhoneBook;
using API_Practice.Shared.Config;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Mime;

namespace API_Practice.Controllers;

public class ProductController : BaseController
{
    private readonly IProductPhoneBook _productPhoneBook;
    private readonly IMapper _mapper;
    private readonly MySettings _mySettings;
    public ProductController(IProductPhoneBook productPhoneBook, IMapper mapper, IOptionsSnapshot<MySettings> mySettings)
    {
        _mySettings = mySettings.Value;
        _mapper = mapper;
        _productPhoneBook = productPhoneBook;
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        Product product = _productPhoneBook.GetProductById(id);

        if (product is null)
            return NotFound();
        product.Name = $" {_mySettings.StringSetting}  {product.Name}";
        var productDto = _mapper.Map<ProductDto>(product);

        return Ok(productDto);
    }

    [Route("")]
    [HttpDelete]
    public async Task<bool> Delete()
    {
        return true;
    }

    [Route("")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add([FromBody] AddProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        _productPhoneBook.AddProduct(product);

        return Created();
    }

    [Route("")]
    [HttpPut]
    public bool Update(Product product)
    {
        return true;
    }


}

