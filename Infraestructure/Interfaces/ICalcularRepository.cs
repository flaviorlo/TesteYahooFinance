using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Interfaces
{
    public interface ICalcularRepository 
    {
        //
        public List<AssetData> GetDadosAsset(string asset, int days);
       
    }
}
