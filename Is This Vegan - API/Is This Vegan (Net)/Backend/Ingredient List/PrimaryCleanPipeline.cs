﻿/*
 * Author: Jake Ladera
 * Version: 1.0
 * 
 * Summary:
 *  This class will perform primary cleaning operations on 
 *  an ingredient list immediately after extracting text from 
 *  a photo.
 */
using Is_This_Vegan__Net_.Backend.Interfaces;
using Is_This_Vegan__Net_.Enums;
using Is_This_Vegan__Net_.Models;
using System;
using System.Collections.Generic;

namespace Is_This_Vegan__Net_.Backend.Ingredient_List
{
    public class PrimaryCleanPipeline : IPipeline
    {
        /// <summary>
        /// Cleans initial ingredient list text extraction
        /// </summary>
        /// <typeparam name="T"> For the primary cleaning pipeline, must be string </typeparam>
        /// <param name="input"> Ingredient list extracted from photo using Tesseract </param>
        /// <param name="type"> Type of data cleaning; Is ignored in pipeline </param>
        /// <returns> A PipelineResult object indicating if the method completed successfully and its result </returns>
        public PipelineResultModel Execute<T>(ref T input, DataCleanEnum? type, double? meanConfidence)
        {
            var list = input.ToString();
            PipelineResultModel result;
            try
            {
                list = PrimaryCleanPipeline.Remove(list);
                result = IsValid(list, meanConfidence);
                result.result = list.ToLower();
            }
            catch (Exception e)
            {
                result = new PipelineResultModel();
                result.isSuccessful = false;
                result.result = e.ToString();
            }

            return result;
        }

        /// <summary>
        /// TODO:
        /// Determines if the initial ingredient list is valid. And ingredient list
        /// is considered invalid if the ingredient list contains 0 or 1 characters after
        /// removing invalid characters.
        /// 
        /// It is worth noting that 
        /// </summary>
        /// <param name="list"> Ingredient List in paragraph form</param>
        /// <returns> True if valid, false otherwise </returns>
        public PipelineResultModel IsValid(string list, double? meanConfidence)
        {
            if (meanConfidence <= 70.00) 
            {
                return new PipelineResultModel() { isSuccessful = false };
            }
            else if (list.Length <= 1)
            {
                return new PipelineResultModel() { isSuccessful = false };
            }
            else
            {
                return new PipelineResultModel() { isSuccessful = true};
            }
        }

        /// <summary>
        /// Removes unnecessary characters, newlines, etc. from an ingredient list.
        /// </summary>
        /// <param name="rawList"> Raw ingredient list (done after text extraction) </param>
        /// <returns> The ingredient list without invalid characters </returns>
        public static string Remove(string rawList)
        {
            // Key = text to remove
            // Value = replacement text
            var toRemoveList = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("\n", " "),
                new KeyValuePair<string, string>("\t", " "),
                new KeyValuePair<string, string>("_", ""),
                new KeyValuePair<string, string>("|", "")
            };

            foreach (var toRemove in toRemoveList)
            {
                rawList = rawList.Replace(toRemove.Key, toRemove.Value);
            }

            rawList = rawList.Trim();

            return rawList;
        }
    }
}