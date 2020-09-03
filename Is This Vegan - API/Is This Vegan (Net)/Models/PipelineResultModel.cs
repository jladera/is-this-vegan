using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Is_This_Vegan__Net_.Models
{
    public class PipelineResultModel
    {
        /// <summary>
        /// Execute ran successfully
        /// </summary>
        public bool isSuccessful { get; set; }

        /// <summary>
        /// % confidence of extraction. This property is only set after text extraction.
        /// </summary>
        public float meanConfidence { get; set; }

        /// <summary>
        /// If isSuccessful is true:
        ///     result will be the output of the pipeline
        /// If isSuccessful is false:
        ///     result will be an error message explaining 
        ///     why execute did not run successfully
        /// </summary>
        public string result { get; set; }
    }
}