using Application.Dto;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiBlueFleet.Controllers
{
    [Route("api/veiculos")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoApiService _veiculoService;

        public VeiculosController(IVeiculoApiService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        // GET: api/<VeiculosController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                ResultService? result = await _veiculoService.GetAllAsync();

                if (result.IsSucess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception e)
            {
                return BadRequest("Erro na função Get: " + e.Message);
                //throw;
            }
        }

        // GET api/<VeiculosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                ResultService? result = await _veiculoService.GetByIdAsync(id);

                if (result.IsSucess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception e)
            {
                return BadRequest("Erro na função Get: " + e.Message);
                //throw;
            }
        }

        // POST api/<VeiculosController>
        [HttpPost]
        public async Task<ActionResult> Adicionar([FromBody] VeiculosDto veiculo)
        {
            try
            {
                ResultService? result = await _veiculoService.SaveAsync(veiculo);

                if (result.IsSucess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception e)
            {
                return BadRequest("Erro na função Adicionar: " + e.Message);
                //throw;
            }
        }

        // PUT api/<VeiculosController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Editar(int id, [FromBody] VeiculosDto veiculo)
        {
            try
            {
                veiculo.Id = id;
                ResultService? result = await _veiculoService.UpdateAsync(veiculo);

                if (result.IsSucess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception e)
            {
                return BadRequest("Erro na função Editar: " + e.Message);
                //throw;
            }
        }

        // DELETE api/<VeiculosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                ResultService? result = await _veiculoService.DeleteAsync(id);

                if (result.IsSucess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception e)
            {
                return BadRequest("Erro na função Delete: " + e.Message);
                //throw;
            }
        }
    }
}
