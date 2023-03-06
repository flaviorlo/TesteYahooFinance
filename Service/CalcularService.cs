using Domain.Model;
using Infraestructure.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Service
{
    public class CalcularService : ICalcularService
    {
        private ICalcularRepository variacaoRepository { get; }

        public CalcularService(ICalcularRepository _calculaRepository)
        {
            variacaoRepository = _calculaRepository;
        }
       
        public  List<AssetData> GetDadosAsset(string asset, int days)
        {
            var result=  variacaoRepository.GetDadosAsset(asset,days);
            return result;

        }
    }
}
