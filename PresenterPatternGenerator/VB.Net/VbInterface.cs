using System.Text;

namespace PaintScan.Tests.VB.Net
{
    public class VbInterface : CreatorBase, IInterface
    {
        public VbInterface(string name) : base(name)
        {
        }

        public override string Result()
        {
            
            var build = new StringBuilder();
            build.AppendLine($"Public Interface {Name}");
            build.Append(Builder);
            build.AppendLine("End Interface");
            return build.ToString();
        }

        public void AddProperty(string name, string type)
        {
            Builder.AppendLine($"   Property {name} As {type}");
        }
    }
}