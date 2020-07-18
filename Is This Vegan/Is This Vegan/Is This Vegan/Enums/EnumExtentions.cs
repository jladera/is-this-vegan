/*
 * Created by Jake Ladera
 * 
 * Intended Use:
 *      Extension methods for project's Enums
 */

using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Is_This_Vegan.Enums
{
    public static class EnumExtentions
    {
        /// <summary>
        /// Gets the Description of an Enum type
        /// </summary>
        /// <param name="value"> The Enum's numerical value </param>
        /// <returns> The Enum's description presented as a string </returns>
        public static string GetDescription(this Enum value)
        {
            return ((DescriptionAttribute)Attribute.GetCustomAttribute(
                value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
                    .Single(x => x.GetValue(null).Equals(value)),
                typeof(DescriptionAttribute)))?.Description ?? value.ToString();
        }
    }
}
