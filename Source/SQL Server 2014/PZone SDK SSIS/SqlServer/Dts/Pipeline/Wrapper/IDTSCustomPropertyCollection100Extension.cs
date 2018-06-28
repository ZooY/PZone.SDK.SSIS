using System.Collections.Generic;
using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
using Microsoft.SqlServer.Dts.Runtime.Wrapper;
using Microsoft.SqlServer.Dts.Pipeline;

namespace SSIS.SqlServer.Dts.Pipeline.Wrapper
{
    public static class IDTSCustomPropertyCollection100Extension
    {
        public static void AddRange(this IDTSCustomPropertyCollection100 collection, IEnumerable<CustomProperty> properties)
        {
            foreach (var customProperty in properties)
            {
                var prop = collection.New();
                prop.ExpressionType = DTSCustomPropertyExpressionType.CPET_NOTIFY;
                prop.Name = customProperty.Name;
                prop.Description = customProperty.Description;
                prop.Value = customProperty.Value;
            }
        }


        public static string Get(this IDTSCustomPropertyCollection100 collection, PipelineComponent component, string name)
        {
            string value = collection[name].Value.ToString();
            if (value.StartsWith("@"))
            {
                var variableName = value.StartsWith("@[") ? value.Substring(2, value.Length - 3) : value.Substring(1);
                IDTSVariables100 variables;
                component.VariableDispenser.LockForRead(variableName);
                component.VariableDispenser.GetVariables(out variables);
                value = variables[variableName].Value.ToString();
            }
            return value;
        }
    }
}