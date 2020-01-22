using System.Linq;
using System.Text;

namespace PaintScan.Tests
{
    public class CSharpParamterConstructor : CSharpDefaultConstructor
    {
        private readonly (string, string)[] _parameters;
        public override string Result()
        {
            var build = new StringBuilder();

            build.AppendLine($"public {Name}({_parameters.Select(p=> $"{p.Item1} {p.Item2}").Aggregate( (tuple, valueTuple) => tuple + "," + valueTuple)})");
            build.AppendLine("{");
            build.Append(Builder);
            build.AppendLine("}");
            return build.ToString();
        }

        public CSharpParamterConstructor(string name, (string,string)[] parameters) : base(name)
        {
            _parameters = parameters;
        }
    }
}