#if NETFX_CORE
using System;
using System.Collections.Generic;
using System.Reflection;

namespace System.Reflection
{
    public static class TypeCodeExtensions
    {
        private static readonly Dictionary<Type, TypeCode> TypeCodeTable = new Dictionary<Type,TypeCode>();

        static TypeCodeExtensions()
        {
            TypeCodeTable[typeof(bool)] = TypeCode.Boolean;
            TypeCodeTable[typeof(char)] = TypeCode.Char;
            TypeCodeTable[typeof(sbyte)] = TypeCode.SByte;
            TypeCodeTable[typeof(byte)] = TypeCode.Byte;
            TypeCodeTable[typeof(short)] = TypeCode.Int16;
            TypeCodeTable[typeof(ushort)] = TypeCode.UInt16;
            TypeCodeTable[typeof(int)] = TypeCode.Int32;
            TypeCodeTable[typeof(uint)] = TypeCode.UInt32;
            TypeCodeTable[typeof(long)] = TypeCode.Int64;
            TypeCodeTable[typeof(ulong)] = TypeCode.UInt64;
            TypeCodeTable[typeof(float)] = TypeCode.Single;
            TypeCodeTable[typeof(double)] = TypeCode.Double;
            TypeCodeTable[typeof(decimal)] = TypeCode.Decimal;
            TypeCodeTable[typeof(DateTime)] = TypeCode.DateTime;
            TypeCodeTable[typeof(string)] = TypeCode.String;
        }
        
        /// <summary>
        /// Converts the underlying type code of the specified Type.
        /// </summary>
        /// <param name="type">The type whose underlying type code to get. </param>
        /// <returns>The code of the underlying type.</returns>
        public static TypeCode GetTypeCode(this Type type)
        {
            if (TypeCodeTable.ContainsKey(type))
            {
                return TypeCodeTable[type];
            }
            
            if (type.GetTypeInfo().IsEnum)
            {
                return TypeCodeTable[Enum.GetUnderlyingType(type)];
            }
            
            return TypeCode.Object;
        }
    }
}
#endif