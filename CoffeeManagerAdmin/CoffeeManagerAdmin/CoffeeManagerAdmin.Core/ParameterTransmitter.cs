using System;
using System.Collections.Generic;

namespace CoffeeManagerAdmin.Core
{
    public static class ParameterTransmitter
    {
        private static readonly Dictionary<Guid, object> parameters = new Dictionary<Guid, object>();

        public static Guid PutParameter(object parameterValue)
        {
            var id = Guid.NewGuid();
            parameters.Add(id, parameterValue);
            return id;
        }

        public static IEnumerable<Guid> PutParameters(params object[] parameterValues)
        {
            parameters.Clear();

            var ids = new List<Guid>(parameterValues.Length);
            foreach (var parameterValue in parameterValues)
            {
                ids.Add(PutParameter(parameterValue));
            }
            return ids;
        }

        public static bool TryGetParameter<T>(Guid parameterId, out T parameterValue, bool clearParameterIfExists = true)
        {
            object value;
            if (!parameters.TryGetValue(parameterId, out value))
            {
                parameterValue = default(T);
                return false;
            }

            parameterValue = (T)value;

            if (clearParameterIfExists)
            {
                parameters.Remove(parameterId);
            }

            return true;
        }
    }
}
