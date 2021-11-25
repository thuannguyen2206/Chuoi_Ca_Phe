using DataTransferObjects.DTOs.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;

namespace NordaShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("list/adminrole={adminRole}")]
        [AllowAnonymous]
        public IActionResult GetAll(bool adminRole)
        {
            var result = _categoryService.GetAll(adminRole);
            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _categoryService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("create")]
        public IActionResult Create(CategoryDto dto)
        {
            var result = _categoryService.Create(dto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}/update")]
        public IActionResult Update(int id, CategoryDto dto)
        {
            var result = _categoryService.Update(id, dto);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _categoryService.Delete(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
