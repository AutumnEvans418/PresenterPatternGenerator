using System.Text;

namespace PaintScan.Tests
{
    public class CSharpDefaultConstructor : CreatorBase, IConstructor
    {
        public override string Result()
        {
            var build = new StringBuilder();

            build.AppendLine($"public {Name}()");
            build.AppendLine("{");
            build.Append(Builder);
            build.AppendLine("}");
            return build.ToString();
        }

        public void AddVariable(string variableName, string variableInstiator)
        {
            Builder.AppendLine($"var {variableName} = new {variableInstiator}");
        }

        public void AddEventHandler(string eventName, string methodName)
        {
            Builder.AppendLine($"{eventName} += (s,args) => {methodName}();");

        }

        public void InstantiateProperty(string propertyName, string parameterName)
        {
            Builder.AppendLine($"{propertyName} = {parameterName};");
        }

        public CSharpDefaultConstructor(string name) : base(name)
        {
        }
    }
}