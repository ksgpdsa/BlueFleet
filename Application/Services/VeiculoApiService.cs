using Application.Dto;
using Application.Interfaces;
using Application.Validations;
using AutoMapper;
using Domain.IRepositories;
using Domain.Models;
using FluentValidation.Results;
using Infra.Data.Interfaces;

namespace Application.Services
{
    public class VeiculoApiService : IVeiculoApiService
    {
        private readonly IUnitOfWork _unityOfWork;
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _mapper;

        public VeiculoApiService(IUnitOfWork unityOfWork, IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _veiculoRepository = veiculoRepository;
            _mapper = mapper;
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            try
            {
                _unityOfWork.BeginTransaction();

                bool retorno = await _veiculoRepository.DeleteAsync(id);

                _unityOfWork.Commit();

                return ResultService.Ok("Deletado com sucesso !");
            }
            catch (Exception e)
            {
                _unityOfWork.Rollback();
                return ResultService.Fail("Não foi possível deletar: " + e.Message);

                //throw;
            }
        }

        public async Task<ResultService<IEnumerable<VeiculosDto>>> GetAllAsync()
        {
            try
            {
                IEnumerable<Veiculo>? retorno = await _veiculoRepository.GetAllAsync();

                return ResultService.Ok(_mapper.Map<IEnumerable<VeiculosDto>>(retorno));
            }
            catch (Exception e)
            {
                return ResultService.Fail<IEnumerable<VeiculosDto>>("Não foi possível obter os dados: " + e.Message);
                //throw;
            }
        }

        public async Task<ResultService<VeiculosDto>> GetByIdAsync(int id)
        {
            try
            {
                Veiculo? retorno = await _veiculoRepository.GetByIdAsync(id);

                return ResultService.Ok(_mapper.Map<VeiculosDto>(retorno));
            }
            catch (Exception e)
            {
                return ResultService.Fail<VeiculosDto>("Não foi possível obter os dados: " + e.Message);
                //throw;
            }
        }

        public async Task<ResultService> SaveAsync(VeiculosDto veiculoDto)
        {
            try
            {
                if (veiculoDto == null)
                    return ResultService.Fail("Objeto deve ser informado");

                ValidationResult? result = new VeiculosValidationSalvar().Validate(veiculoDto);

                if (!result.IsValid)
                    return ResultService.RequestError("Problemas de validação", result);

                Veiculo? veiculo = _mapper.Map<Veiculo>(veiculoDto);

                _unityOfWork.BeginTransaction();

                bool retorno = await _veiculoRepository.SaveAsync(veiculo);

                _unityOfWork.Commit();

                return ResultService.Ok("Salvo com sucesso !");
            }
            catch (Exception e)
            {
                return ResultService.Fail("Erro ao salvar o veículo: " + e.Message);

                // throw;
            }
        }

        public async Task<ResultService> UpdateAsync(VeiculosDto veiculoDto)
        {
            try
            {
                if (veiculoDto == null)
                    return ResultService.Fail("Objeto deve ser informado");

                ValidationResult? result = new VeiculosValidationEditar().Validate(veiculoDto);

                if (!result.IsValid)
                    return ResultService.RequestError("Problemas de validação", result);

                Veiculo? veiculo = _mapper.Map<Veiculo>(veiculoDto);

                _unityOfWork.BeginTransaction();

                bool retorno = await _veiculoRepository.UpdateAsync(veiculo);

                _unityOfWork.Commit();

                return ResultService.Ok("Editado com sucesso !");
            }
            catch (Exception e)
            {
                return ResultService.Fail("Erro ao atualizar o veículo: " + e.Message);

                //throw;
            }
        }
    }
}
