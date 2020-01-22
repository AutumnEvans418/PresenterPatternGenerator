using System.Linq;
using System.Text;

namespace PaintScan.Tests.VB.Net
{
    public class VbConstructor : CreatorBase, IConstructor
    {
        private readonly (string, string)[] _parameters;

        public VbConstructor(string name, (string, string)[] parameters) : base(name)
        {
            _parameters = parameters;
        }

        public override string Result()
        {
            var builder = new StringBuilder();
            if (_parameters != null)
            {
                builder.AppendLine($"    Sub New({_parameters.Select(p => $"{p.Item2} as {p.Item1}").Aggregate((tuple, valueTuple) => tuple + "," + valueTuple)})");
            }
            else
            {
                builder.AppendLine("    Sub New()");
            }
            builder.Append(Builder);
            builder.AppendLine("    End Sub");
            return builder.ToString();
        }

        public void AddVariable(string variableName, string variableInstiator)
        {
            Builder.AppendLine($"       dim {variableName} = {variableInstiator}");
        }

        public void AddEventHandler(string eventName, string methodName)
        {
            Builder.AppendLine($"       AddHandler {eventName}, sub(s, args) {methodName}()");
        }

        public void InstantiateProperty(string propertyName, string parameterName)
        {
            Builder.AppendLine($"       {propertyName} = {parameterName}");
        }
    }
}