using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace B3_CDB.Controllers
{
    [ApiController]
    [Route("v1/VariacaoAsset")]
    public class CalcularCDBController : ControllerBase
    {
        private ICalcularService _calcularService { get; }

        public CalcularCDBController(ICalcularService calcularService)
        {
            _calcularService = calcularService;
        }

        ////<sumary>
        ///Busca os dados no Yahoo Finance do Ativo e periódo desejado
        ///<param name="asset">Código da ação</param>
        ///<param name="pregoes">Número pregões que deseja consultar</param>        
        ///</sumary>
        ///<param 
        [HttpGet]
        public List<AssetData> GetDadosAsset(string asset, int pregoes)
        {
            try
            {
                var result = _calcularService.GetDadosAsset(asset, pregoes);
                return result;

            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao obter cliente.", ex);
            }
        }

        
    }
}
