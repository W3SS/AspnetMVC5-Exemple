using Microsoft.AspNet.Identity;
using ModuloCongresso.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ModuloCongresso.Application.Interfaces.Cotacao;
using ModuloCongresso.Application.ViewModels;
using ModuloCongresso.Application.ViewModels.Business;
using ModuloCongresso.Application.ViewModels.Cotacao;
using ModuloCongresso.Infra.CrossCutting.MvcFilters;

namespace ModuloCongresso.UI.Site.Controllers
{
    public class CotacaoController : Controller
    {
        private readonly IMarcaAppService _marcaAppService;
        private readonly IModeloAppService _modeloAppService;
        private readonly IProfissaoAppService _profissaoAppService;
        private readonly IPaisResidenciaAppService _paisResidenciaAppService;
        private readonly ITipoCalculoAppService _tipoCalculoAppService;
        private readonly ITipoSeguroAppService _tipoSeguroAppService;
        private readonly IRastreadorAppService _rastreadorAppService;
        private readonly IAntiFurtoAppService _antiFurtoAppService;
        private readonly ITipoResidenciaAppService _tipoResidenciaAppService;
        private readonly IEstadoCivilAppService _estadoCivilAppService;
        private readonly ICoberturaAppService _coberturasAppService;
        private readonly ICotacaoAppService _cotacaoAppService;
        private readonly ISexoAppService _sexoAppService;
        private readonly ITempoHabilitacaoAppService _tempoHabilitacaoAppService;
        private readonly IDistanciaTrabalhoAppService _distanciaTrabalhoAppService;
        private readonly IUsoAppService _usoAppService;
        private readonly IImpostoAppService _impostoAppService;
        private readonly IItemAppService _itemAppService;

        public CotacaoController(IMarcaAppService marcaAppService,
            IModeloAppService modeloAppService,
            IPaisResidenciaAppService paisResidenciaAppService,
            IProfissaoAppService profissaoAppService,
            ITipoCalculoAppService tipoCalculoAppService,
            ITipoSeguroAppService tipoSeguroAppService,
            IRastreadorAppService rastreadorAppService,
            IAntiFurtoAppService antiFurtoAppService,
            ITipoResidenciaAppService tipoResidenciaAppService,
            IEstadoCivilAppService estadoCivilAppService,
            ICoberturaAppService coberturaAppService,
            ICotacaoAppService cotacaoAppService,
            ISexoAppService sexoAppService,
            ITempoHabilitacaoAppService tempoHabilitacaoAppService,
            IDistanciaTrabalhoAppService distanciaTrabalhoAppService,
            IUsoAppService usoAppService,
            IImpostoAppService impostoAppService,
            IItemAppService itemAppService)
        {
            _marcaAppService = marcaAppService;
            _modeloAppService = modeloAppService;
            _paisResidenciaAppService = paisResidenciaAppService;
            _profissaoAppService = profissaoAppService;
            _tipoCalculoAppService = tipoCalculoAppService;
            _tipoSeguroAppService = tipoSeguroAppService;
            _rastreadorAppService = rastreadorAppService;
            _antiFurtoAppService = antiFurtoAppService;
            _tipoResidenciaAppService = tipoResidenciaAppService;
            _estadoCivilAppService = estadoCivilAppService;
            _coberturasAppService = coberturaAppService;
            _cotacaoAppService = cotacaoAppService;
            _sexoAppService = sexoAppService;
            _tempoHabilitacaoAppService = tempoHabilitacaoAppService;
            _distanciaTrabalhoAppService = distanciaTrabalhoAppService;
            _usoAppService = usoAppService;
            _impostoAppService = impostoAppService;
            _itemAppService = itemAppService;
        }

        // GET: Cotacao
        public ActionResult Index()
        {
            var manageCotacao = new ManageCotacaoViewModel {ListCotacoes = CarregarCotacoes() };

            return View(manageCotacao);
        }

        [HttpGet]
        public ActionResult CotacaoResultado(string cotacaoId, string premioTotal)
        {
            var descricao = _cotacaoAppService.ObterDescricaoModeloCotacao(int.Parse(cotacaoId));

            var cotacao = new CotacaoViewModel
            {
                CotacaoId = int.Parse(cotacaoId),
                PremioTotal = decimal.Parse(premioTotal),
                Descricao = descricao
            };


            return View(cotacao);
        }

        [HttpGet]
        public ActionResult CotacaoAutomovel()
        {
            var marcas =
                _marcaAppService.ObterTodosOrdenadoAlfabeticamente()
                    .AsEnumerable()
                    .Select(m => new SelectListItem {Value = m.MarcaId.ToString(), Text = m.Nome});

            var tiposCalculo = _tipoCalculoAppService.ObterTodos()
                    .AsEnumerable()
                    .Select(t => new SelectListItem { Value = t.TipoCalculoId.ToString(), Text = t.Descricao});

            var tiposSeguro = _tipoSeguroAppService.ObterTodos()
                    .AsEnumerable()
                    .Select(t => new SelectListItem { Value = t.TipoSeguroId.ToString(), Text = t.Descricao });

            var profissoes = _profissaoAppService.ObterTodos().AsEnumerable()
            .Select(p => new SelectListItem { Value = p.ProfissaoId.ToString(), Text = p.Nome });

            var pais = _paisResidenciaAppService.ObterTodos().AsEnumerable()
            .Select(pr => new SelectListItem { Value = pr.PaisResidenciaId.ToString(), Text = pr.Nome });

            var rastreadores = _rastreadorAppService.ObterTodos()
                    .AsEnumerable()
                    .Select(r => new SelectListItem { Value = r.RastreadorId.ToString(), Text = r.Nome });

            var antiFurto = _antiFurtoAppService.ObterTodos()
                    .AsEnumerable()
                    .Select(a => new SelectListItem { Value = a.AntiFurtoId.ToString(), Text = a.Nome });

            var estadoCivil = _estadoCivilAppService.ObterTodos()
                    .AsEnumerable()
                    .Select(e => new SelectListItem { Value = e.EstadoCivilId.ToString(), Text = e.Descricao });

            var tipoResidencia = _tipoResidenciaAppService.ObterTodos()
                    .AsEnumerable()
                    .Select(t => new SelectListItem { Value = t.TipoResidenciaId.ToString(), Text = t.Descricao });

            var sexo = _sexoAppService.ObterTodos()
                    .AsEnumerable()
                    .Select(s => new SelectListItem { Value = s.SexoId.ToString(), Text = s.Descricao });

            var tempohab = _tempoHabilitacaoAppService.ObterTodos()
                    .AsEnumerable()
                    .Select(t => new SelectListItem { Value = t.TempoHabilitacaoId.ToString(), Text = t.Descricao });

            var distancia = _distanciaTrabalhoAppService.ObterTodos()
                    .AsEnumerable()
                    .Select(d => new SelectListItem { Value = d.DistanciaTrabalhoId.ToString(), Text = d.Descricao });

            var uso = _usoAppService.ObterTodos()
                    .AsEnumerable()
                    .Select(i => new SelectListItem { Value = i.UsoId.ToString(), Text = i.Descricao });

            var imposto = _impostoAppService.ObterTodos()
                    .AsEnumerable()
                    .Select(i => new SelectListItem { Value = i.ImpostoId.ToString(), Text = i.Descricao });

            var coberturas = _coberturasAppService.ObterCoberturasProdutos((int)Produtos.Automóvel).ToList();

            var modelo = new ModeloViewModel { Marcas = marcas };
            var cliente = new ClienteEnderecoViewModel { Profissoes = profissoes, Pais = pais };
            var item = new ItemViewModel { Modelo = modelo, Imposto = imposto, Uso = uso};
            var perfil = new PerfilViewModel { EstadoCivil = estadoCivil, TipoResidencia = tipoResidencia, Sexo = sexo, TempoHabilitacao = tempohab, DistanciaTrabalho = distancia};
            var questionario = new QuestionarioViewModel { Rastreadores = rastreadores, DispositivosFurtos = antiFurto };

            var cotacao = new CotacaoViewModel
            {
                Cliente = cliente,
                Item = item,
                Perfil = perfil,
                Questionario = questionario,
                TiposSeguro = tiposSeguro,
                TiposCalculo = tiposCalculo,
                ListCoberturas = coberturas
            };

            return View(cotacao);
        }

        [HttpPost]
        public JsonResult CotacaoAutomovel(CotacaoViewModel model)
        {
            model.UserId = GetClienteId();

            if (!ModelState.IsValid)
            {
                var errorList = ModelState.ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return Json(new { error = "ModelStateError", model = errorList.Where(t => t.Value.Length > 0) });
            }


            model.ValidationResult = new DomainValidation.Validation.ValidationResult();

            model = _cotacaoAppService.Adicionar(model);

            if (!model.ValidationResult.IsValid)
            {
                LoadCotacaoErrors(model);
                return Json(new { error = "ValildationResultError", model = model.ValidationResult });
            }

            return Json(new { error = "", model, Url = "CotaçãoResultado" });
        }

        private void LoadCotacaoErrors(CotacaoViewModel model)
        {
            foreach (var error in model.ValidationResult.Erros)
            {
                ModelState.AddModelError(string.Empty, error.Message);
            }
        }

        [HttpGet]
        public ActionResult EditCotacaoAutomovel(int? cotacaoId)
        {
            if (cotacaoId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cotacaoViewModel = _cotacaoAppService.ObterCotacaoPorId(int.Parse(cotacaoId.ToString()));

            var marcas = _marcaAppService.ObterTodosOrdenadoAlfabeticamente().AsEnumerable().Select(m => new SelectListItem { Value = m.MarcaId.ToString(), Text = m.Nome});

            var modelo = new ModeloViewModel { Marcas = marcas };
            cotacaoViewModel.Item.Modelo = modelo;

            cotacaoViewModel.Cliente.Profissoes = _profissaoAppService.ObterTodos().AsEnumerable().Select(p => new SelectListItem { Value = p.ProfissaoId.ToString(), Text = p.Nome, Selected = true });
            cotacaoViewModel.Cliente.Pais = _paisResidenciaAppService.ObterTodos().AsEnumerable().Select(pr => new SelectListItem { Value = pr.PaisResidenciaId.ToString(), Text = pr.Nome, Selected = true });
            cotacaoViewModel.Item.Imposto = _impostoAppService.ObterTodos().AsEnumerable().Select(i => new SelectListItem { Value = i.ImpostoId.ToString(), Text = i.Descricao, Selected = true });
            cotacaoViewModel.Item.Uso = _usoAppService.ObterTodos().AsEnumerable().Select(i => new SelectListItem { Value = i.UsoId.ToString(), Text = i.Descricao, Selected = true });
            cotacaoViewModel.Perfil.EstadoCivil = _estadoCivilAppService.ObterTodos().AsEnumerable().Select(e => new SelectListItem { Value = e.EstadoCivilId.ToString(), Text = e.Descricao, Selected = true });
            cotacaoViewModel.Perfil.TipoResidencia = _tipoResidenciaAppService.ObterTodos().AsEnumerable().Select(t => new SelectListItem { Value = t.TipoResidenciaId.ToString(), Text = t.Descricao, Selected = true });
            cotacaoViewModel.Perfil.Sexo = _sexoAppService.ObterTodos().AsEnumerable().Select(s => new SelectListItem { Value = s.SexoId.ToString(), Text = s.Descricao, Selected = true });
            cotacaoViewModel.Perfil.TempoHabilitacao = _tempoHabilitacaoAppService.ObterTodos().AsEnumerable().Select(t => new SelectListItem { Value = t.TempoHabilitacaoId.ToString(), Text = t.Descricao, Selected = true });
            cotacaoViewModel.Perfil.DistanciaTrabalho = _distanciaTrabalhoAppService.ObterTodos().AsEnumerable().Select(d => new SelectListItem { Value = d.DistanciaTrabalhoId.ToString(), Text = d.Descricao, Selected = true });
            cotacaoViewModel.Questionario.Rastreadores = _rastreadorAppService.ObterTodos().AsEnumerable().Select(r => new SelectListItem { Value = r.RastreadorId.ToString(), Text = r.Nome, Selected = true });
            cotacaoViewModel.Questionario.DispositivosFurtos = _antiFurtoAppService.ObterTodos().AsEnumerable().Select(a => new SelectListItem { Value = a.AntiFurtoId.ToString(), Text = a.Nome, Selected = true });
            cotacaoViewModel.TiposCalculo = _tipoCalculoAppService.ObterTodos().AsEnumerable().Select(t => new SelectListItem { Value = t.TipoCalculoId.ToString(), Text = t.Descricao, Selected = true });
            cotacaoViewModel.TiposSeguro = _tipoSeguroAppService.ObterTodos().AsEnumerable().Select(t => new SelectListItem { Value = t.TipoSeguroId.ToString(), Text = t.Descricao, Selected = true });
            cotacaoViewModel.ListCoberturas = _coberturasAppService.ObterCoberturasProdutos((int)Produtos.Automóvel).ToList();

            return View(cotacaoViewModel);
        }

        private Guid GetClienteId()
        {
            return Guid.Parse(User.Identity.GetUserId());
        }

        [HttpGet]
        public JsonResult ReloadProduct(string buttonClass)
        {
            string url = string.Empty;

            switch (buttonClass)
            {
                case "btnAuto":
                    url = "CotacaoAutomovel";
                    break;

                case "btnMoto":
                    url = "";
                    break;

                case "btnResidencial":
                    url = "";
                    break;
            }

            object result = new { Value = url };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult VerifyProduct(string buttonClass)
        {
            var url = string.Empty;

            switch (buttonClass)
            {
                case "btnAuto":
                    url = "_selectedProductAutomovel";
                    break;

                case "btnMoto":
                    url = "_selectedProductMoto";
                    break;

                case "btnResidencial":
                    url = "_selectedProductResidencial";
                    break;
            }

            return PartialView(url);
        }

        private List<CotacaoViewModel> CarregarCotacoes()
        {
            return LoadCotacoesAll(GetClienteId());
        }

        private List<CotacaoViewModel> LoadCotacoesAll(Guid userId)
        {
            return _cotacaoAppService.ObterCotacoesPorUsuario(userId).ToList();
        }

        [HttpGet]
        public JsonResult VerifyFlagBasic()
        {
            var id = _coberturasAppService.ObterIdCoberturaBasica((int) Produtos.Automóvel);

            return Json(id, JsonRequestBehavior.AllowGet); 
        }

        [HttpGet]
        public JsonResult VerifyValorModelo(string valueId)
        {
            var valor = _modeloAppService.ObterValorModelo(int.Parse(valueId));

            return Json(valor, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadModelos(string valueId)
        {
            var modelos = _modeloAppService.ObterNomeTodosModelosPorMarca(int.Parse(valueId));

            object result = new { Value = modelos };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadModelosResults(string marcaId, string modelo, string anoFabricacao, string anoModelo, string zeroKm)
        {
            var modelos =
                _modeloAppService.ObterTodosSelecionados(int.Parse(marcaId), modelo, anoFabricacao, anoModelo, zeroKm).ToList();

            return Json(modelos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadSelectModelo(string modeloId)
        {
            var modelo = _modeloAppService.ObterModeloPorId(int.Parse(modeloId));

            return Json(modelo, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadDadosMarca(string marcaId)
        {
            var marca = _marcaAppService.ObterMarcaPorId(int.Parse(marcaId));

            return Json(marca, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadDataInicioFim(string dataVigenciaInicial, string tipoCalculoId)
        {
            var dataFim = _tipoCalculoAppService.ObterDataVigenciaFinal(int.Parse(tipoCalculoId), dataVigenciaInicial);

            return Json(dataFim, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadDadosRastreador()
        {
            var rastreadores = _rastreadorAppService.ObterTodos().ToList();

            return Json(rastreadores, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadDadosDispositivoAntiFurto()
        {
            var dispositivos = _antiFurtoAppService.ObterTodos().ToList();

            return Json(dispositivos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadMarcaPorModeloCotacao(string cotacaoId)
        {
            var marcaId = _marcaAppService.ObterMarcaPorModeloCotacao(int.Parse(cotacaoId));

            return Json(marcaId, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadNomeModeloCotacao(string cotacaoId)
        {
            var nome = _modeloAppService.ObterNomeModeloCotacao(int.Parse(cotacaoId));

            return Json(nome, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadInfoDadosVeiculosCotacao(string cotacaoId)
        {
            var dados = _modeloAppService.ObterAnoFabModCotacao(int.Parse(cotacaoId));
            var zeroKm = _modeloAppService.ChecarVeiculoZeroKmCotacao(int.Parse(cotacaoId));

            object result = new { Ano = dados, FlagZeroKm = zeroKm };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
