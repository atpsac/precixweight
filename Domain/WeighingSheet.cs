using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WeighingSheet
    {
        public int WeighingSheetId { get; set; }
        public DateTime WeighingSheetDate { get; set; }
        public string WeighingSheetReference { get; set; }
        public string WeighingSheetState { get; set; }
        public ICollection<WeighingSheetDetails> ProductLink { get; set; }

    }
}
