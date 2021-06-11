using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WeighingSheetDetails
    {
        public int WeighingSheetDetailsProductId { get; set; }
        public int WeighingSheetDetailsWeighingSheetId { get; set; }
        public int WeighingSheetDetailsQuantity { get; set; }
        public decimal WeighingSheetDetailsTare { get; set; }
        public decimal WeighingSheetDetailsGrossWeight { get; set; }
        public decimal WeighingSheetDetailsNetWeight { get; set; }
        public string WeighingSheetDetailsState { get; set; }
        public Product Product { get; set; }
        public WeighingSheet WeighingSheet { get; set; }
    }
}
