using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextExtractionService.Models
{
    public class ExtractionModel
    {
        public string meanConfidenceLabel { get; private set; }
        public string resultText { get; private set; }
        
        public ExtractionModel(string meanConfidenceLabel, string resultText)
        {
            this.meanConfidenceLabel = meanConfidenceLabel;
            this.resultText = resultText;
        }
    }
}