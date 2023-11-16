using CRUDOperation.Application.Commands.Request;
using CRUDOperation.Application.Dtos;
using CRUDOperation.Application.Queries.Request;
using CRUDOperations.Infrastructure.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CRUDOperations.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBrands()
        {
            var reponse = await _mediator.Send(new GetAllBrandsRequest { });
            return Ok(reponse);
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetBrandById([FromQuery] int id)
        {
            var respons = await _mediator.Send(new GetBrandByIdRequest { Id = id });
            return Ok(respons);
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBrand([FromBody]BrandCreateDto brandCreatDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _mediator.Send(new AddBrandRequest { 
                    
                        AddBrand = brandCreatDto
                    });
                    if (response!= null)
                    {
                        return Ok(response);
                    }
                    return BadRequest("Records not created");
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
            return BadRequest("Invalid Model");
        }



        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            var response = await _mediator.Send(new  GetBrandByIdRequest { Id = id });
            if(response == null)
            {
                return BadRequest();
            }
            else
            {
                var result = await _mediator.Send(new DeleteBrandRequest { Id = id });
            }
            return Ok();
        }



        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateBrand([FromBody] BrandUpdateDto brandUpdateDto, [FromQuery] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var response = await _mediator.Send(new UpdateBrandRequest
                {

                    Update = brandUpdateDto,
                    Id = id,
                    
                });
                return Ok(response);
            }
            
        }
    }

}
