using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SWStarships.Services.ValueObjects.Enum
{
    public class BaseEnum<T, Y> where T : BaseEnum<T, Y>
    {
        public int Code { get; protected set; }
        public Y Value { get; protected set; }

        protected BaseEnum(int code, Y value)
        {
            Code = code;
            Value = value;
        }

        public static IList<T> ToList()
        {
            var result = new List<T>();
            var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static);
            fields.ToList().ForEach(f => result.Add((T)f.GetValue(null)));
            return result;
        }

        public static implicit operator int(BaseEnum<T, Y> @enum) => @enum?.Code ?? 0;

        public static implicit operator Y(BaseEnum<T, Y> @enum) => @enum == null ? default(Y) : @enum.Value;

        public static explicit operator BaseEnum<T, Y>(int codigo)
        {
            return ToList().FirstOrDefault(e => e.Code == codigo);
        }

        public static explicit operator BaseEnum<T, Y>(Y valor)
        {
            return ToList().FirstOrDefault(e => e.Value.Equals(valor));
        }
    }
}
