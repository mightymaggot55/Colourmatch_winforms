using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colourmatch_winforms
{
    public class MatchRequest_Sales
    {
        //SALES
        public string matchNo { get; set; }
        public int reqNo { get; set; }
        public int strokeNo { get; set; }
        public DateTime date { get; set; }
        public DateTime dateRequired { get; set; }
        public string salesContact { get; set; }
        public string customer { get; set; }
        public string customerContact { get; set; } 
        public string projectReference { get; set; } 
        public string process { get; set; } 
        public string mouldingMaterial { get; set; } 
        public string colourPrefixOne { get; set; } 
        public string colourPrefixTwo { get; set; } 
        public string colour { get; set; } 
        public string colourTarget { get; set; }
        public string lightSource { get; set; } 
        public string plaques { get; set; } 
        public string pelletSize { get; set; } 
        public string heatStability { get; set; } 
        public string lightFastness { get; set; } 
        public string sampleQuantity { get; set; } 
        public string additionRate { get; set; } 
        public string notes { get; set; } 
        public string sampleType { get; set; }
    }

    public class MatchRequest_Purchasing
    {
        //PURCHASING
        public string MasterbatchRefOne { get; set; } 
        public string MasterbatchRefTwo { get; set; }
        public string AdditionRateReceived { get; set; } 
        public string LightFastnessReceived { get; set; }
        public string HeatStabilityReceived { get; set; } 
        public DateTime DateReceivedOne { get; set; } 
        public DateTime DateReceivedTwo { get; set; } 
        public string MatchStatusOne { get; set; } 
        public string MatchStatusTwo { get; set; } 
        public string PurchasingNotesOne { get; set; } 
        public string PurchasingNotesTwo { get; set; }
        public string AdditionalNotesOne { get; set; }
        public string AdditionalNotesTwo { get; set; }
        public bool MultipleSuppliers { get; set; } 
    }
}
