using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Model
{
    [Table("tb_dadosb3")]
    public class AssetData
    {
        public int id { get; }
        public string symbol { get; set; }       
        public DateTime dtpregao { get; set; }       
        public decimal vlfechamento { get; set; }
        public decimal variacao { get; set; }
        public decimal retTotal { get; set; }
    }

}

public class DataPregao
{
    public string dtmovimento { get; set; }
    public List<DataPregao> dtmov { get; set; }

}

public class Indicators
{
    public string vlclosed { get; set; }
    public List<Indicators> valor { get; set; }
}
