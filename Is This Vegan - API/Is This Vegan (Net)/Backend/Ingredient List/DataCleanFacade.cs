/*
 * Author: Jake Ladera
 * Version: 1.0
 * 
 * Summary:
 *  Facade for cleaning up data such as ingredient lists, product names, and ingredient references.
 */

using Is_This_Vegan__Net_.Backend.Interfaces;
using Is_This_Vegan__Net_.Enums;
using Is_This_Vegan__Net_.Models;
using System;
using System.Runtime.Remoting.Messaging;

namespace Is_This_Vegan__Net_.Backend.Ingredient_List
{
    public class DataCleanFacade
    {
        // Data cleaning pipeline
        public IPipeline pipeline { get; set; }

        public DataCleanFacade(DataCleanEnum? type)
        {
            if (type == DataCleanEnum.ListPrimary)
            {
                pipeline = new PrimaryCleanPipeline();
            }
            else if (type == DataCleanEnum.ListSecondary)
            {
                pipeline = new SecondaryCleanPipeline();
            }
            else
            {
                return;
            }
        }

        public PipelineResultModel Clean<T>(ref T input)
        {
            var result = pipeline.Execute(ref input, null, null);
            return result;
        }
    }
}