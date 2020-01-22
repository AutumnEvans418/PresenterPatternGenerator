using System.Reflection;
using System.Text;

namespace PaintScan.Tests
{
    public class CSharpInterface : CreatorBase, IInterface
    {
        
        

        public void AddProperty(string name, string type)
        {
            Builder.AppendLine($"   {type} {name}" + " { get; set; }");
        }

        public override string Result()
        {
            var build = new StringBuilder();
            build.AppendLine($"public interface {Name}");
            build.AppendLine("{");
            build.Append(Builder);
            build.AppendLine("}");
            return build.ToString();
        }

        public CSharpInterface(string name) : base(name)
        {
        }
    }
}