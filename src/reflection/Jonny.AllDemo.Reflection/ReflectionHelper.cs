using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Jonny.AllDemo.Reflection
{
    public class ReflectionHelper
    {
        /// <summary>
        /// Get all the constant values in the specified type (including the base type).
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string[] GetPublicConstantsRecursively(Type type)
        {
            const int maxRecursiveParameterValidationDepth = 8;

            var publicConstants = new List<string>();

            void Recursively(List<string> constants, Type targetType, int currentDepth)
            {
                if (currentDepth > maxRecursiveParameterValidationDepth)
                {
                    return;
                }

                constants.AddRange(targetType.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                    .Where(x => x.IsLiteral && !x.IsInitOnly)
                    .Select(x => x.GetValue(null).ToString()));

                var nestedTypes = targetType.GetNestedTypes(BindingFlags.Public);

                foreach (var nestedType in nestedTypes)
                {
                    Recursively(constants, nestedType, currentDepth + 1);
                }
            }

            Recursively(publicConstants, type, 1);

            return publicConstants.ToArray();
        }
    }
}
