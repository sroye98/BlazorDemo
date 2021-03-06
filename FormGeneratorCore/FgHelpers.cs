﻿using System;
using System.Linq;

namespace FormGenerator.Core
{
    public static class FgHelpers
    {
        public static bool IsTypeDerivedFromGenericType(
            Type typeToCheck,
            Type genericType)
        {
            if (typeToCheck == typeof(object))
            {
                return false;
            }
            else if (typeToCheck == null)
            {
                return false;
            }
            else if (typeToCheck.IsGenericType && typeToCheck.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }
            else
            {
                return IsTypeDerivedFromGenericType(
                    typeToCheck.BaseType,
                    genericType);
            }
        }

        public static bool TypeImplementsInterface(
            Type type,
            Type typeToImplement)
        {
            Type foundInterface = type
                .GetInterfaces()
                .Where(i =>
                {
                    return i.Name == typeToImplement.Name;
                })
                .Select(i => i)
                .FirstOrDefault();

            return foundInterface != null;
        }
    }
}
