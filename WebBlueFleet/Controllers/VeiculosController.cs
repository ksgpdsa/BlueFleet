using Application.Dto;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using IVeiculoService = Application.Interfaces.IVeiculoService;

namespace WebBlueFleet.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly IVeiculoService _veiculoService;
        private readonly INotificacaoService _notificacaoService;
        private readonly IToastNotification _toastNotification;

        public VeiculosController(
            IVeiculoService veiculoService,
            INotificacaoService notificacaoService,
            IToastNotification toastNotification
        )
        {
            _veiculoService = veiculoService;
            _notificacaoService = notificacaoService;
            _toastNotification = toastNotification;
        }

        // GET: VeiculosController
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ResultService<IEnumerable<VeiculosDto>>? resposta = await _veiculoService.GetAllAsync();
            return View(resposta.Result);
        }

        // GET: VeiculosController/Visualizar/5
        public async Task<ActionResult> Visualizar(int id)
        {
            ResultService<VeiculosDto>? resposta = await _veiculoService.GetByIdAsync(id);
            return View(resposta.Result);
        }

        // GET: VeiculosController/Create
        public ActionResult Create()
        {
            return View("Criar");
        }

        // POST: VeiculosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VeiculosDto veiculo)
        {
            try
            {
                ResultService<bool>? resposta = await _veiculoService.SaveAsync(veiculo);

                if (_notificacaoService.Notificacao(resposta))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Criar", veiculo);
                }
            }
            catch (Exception e)
            {
                _toastNotification.AddErrorToastMessage(e.Message);
                return View("Criar");
            }
        }

        // GET: VeiculosController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ResultService<VeiculosDto>? resposta = await _veiculoService.GetByIdAsync(id);
            return View("Editar", resposta.Result);
        }

        // POST: VeiculosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, VeiculosDto veiculo)
        {
            try
            {
                ResultService<bool>? resposta = await _veiculoService.UpdateAsync(veiculo);

                if (_notificacaoService.Notificacao(resposta))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Editar", veiculo);
                }
            }
            catch (Exception e)
            {
                _toastNotification.AddErrorToastMessage(e.Message);
                return View("Editar", veiculo);
            }
        }

        // GET: VeiculosController/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            ResultService<VeiculosDto>? resposta = await _veiculoService.GetByIdAsync(id);
            return View("Deletar", resposta.Result);
        }

        // POST: VeiculosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, VeiculosDto veiculo)
        {
            try
            {
                ResultService<bool>? resposta = await _veiculoService.DeleteAsync(id);

                if (_notificacaoService.Notificacao(resposta))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Deletar", veiculo);
                }
            }
            catch (Exception e)
            {
                _toastNotification.AddErrorToastMessage(e.Message);
                return View("Deletar");
            }
        }
    }
}
