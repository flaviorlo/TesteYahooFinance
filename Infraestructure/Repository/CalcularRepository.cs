using AngleSharp.Dom;
using AngleSharp.Text;
using Dapper;
using Domain.Model;
using Google.Protobuf.WellKnownTypes;
using Infraestructure.Enum;
using Infraestructure.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mysqlx.Cursor;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Data;
using System.Drawing;
using Method = RestSharp.Method;

namespace Infraestructure.Repository
{
    public class CalcularRepository :BaseRepository<AssetData>, ICalcularRepository
    {
        private IConfiguration _configuration { get; }
        private readonly ICalcularRepository _repository;

        /// <param name="options">Interface de configurações</param>
        /// <param name="logger">Interface de logs</param>
        public CalcularRepository(DbConnection options, IConfiguration cnn) : base(DatabaseType.MySql, cnn)
        {
            _configuration = cnn;
        }
        public  List<AssetData> GetDadosAsset(string asset, int days)
        {
            List<AssetData> mov = new List<AssetData>();
            int i = 0;
            decimal ganho = 0;
            decimal coteini = 0;
            decimal retGeral = 0;
            var urlapi = _configuration["ExternalServiceStartup:YahooFinance:Url"];
            var client = new RestClient($"{urlapi}" + asset + "?region=US&lang=en-US&includePrePost=false&interval=1d&useYfid=true&range=" + days + "d&corsDomain=finance.yahoo.com&.tsrc=finance");
            var request = new RestRequest();
            request.Method = Method.Get;

            var response = client.Execute(request);
            dynamic retorno = JObject.Parse(response.Content);
            var meta = retorno.chart.result[0].meta;
            //var reg = meta.currentTradingPeriod.pre;
            var timestamp = retorno.chart.result[0].timestamp;
            var indicators = retorno.chart.result[0].indicators.quote;
            var open = indicators[0].open;
            var close = indicators[0].close;

            foreach (var item in timestamp)
            {
                DateTime dat_Time = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                dat_Time = dat_Time.AddSeconds(Convert.ToDouble(item));
                decimal cote = Convert.ToDecimal(close[i].ToString("#0.00"));

                if (i > 0)
                {
                    ganho = ((cote - Convert.ToDecimal(close[i - 1].ToString("#0.00"))) / cote) * 100;
                    retGeral = ((cote - coteini) / coteini) * 100;
                }
                else
                {
                    coteini = cote;
                }
                mov.Add(new AssetData
                {
                    symbol = meta.symbol,
                    dtpregao = dat_Time,
                    vlfechamento = cote,
                    variacao = ganho,
                    retTotal = retGeral
                });

                string fecha = cote.ToString("#0.00").Replace(",", ".");
                string variacao = ganho.ToString("#0.00").Replace(",", ".");
                string retornott = retGeral.ToString("#0.00").Replace(",", ".");
                string datamov = dat_Time.Year + "-" + dat_Time.Month + "-" + dat_Time.Day;

                string sql = $@"INSERT INTO tb_dadosb3
                              (symbol,dtpregao,vlfechamento,variacao,retTotal)
                             VALUEs('{mov[0].symbol}','{datamov}',{fecha},{variacao},{retornott})";

                var result = ExecuteAsync(sql);
                i++;
            }


            return mov;
        }


    }
}
