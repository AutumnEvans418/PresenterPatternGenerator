using System;
using System.Linq;
using System.Text;

namespace PaintScan.Tests.VB.Net
{
    public class VbClass : ClassBase
    {
        public VbClass(string name) : base(name)
        {
            Constructor = new VbConstructor(Name, null);
        }


        public override string StartClass()
        {
            var build = new StringBuilder();
            build.AppendLine($"Public Class {Name}");
            if (interfaces.Any())
            {
                foreach (var @interface in interfaces)
                {
                    build.AppendLine($" Implements {@interface}");
                }

            }
            return build.ToString();
        }

        public override string EndClass()
        {
            return "End Class" + Environment.NewLine;
        }

        public override void AddMethod(string name)
        {
            Builder.AppendLine($"   Public Sub {name}");
            Builder.AppendLine("        throw new NotImplementedException()");
            Builder.AppendLine("    End Sub");
        }

        public override void AddFullProperty(string propertyType, string propertyName, string backProperty, string impInterface)
        {
            //"'Private Property TextBox8BatchNoProperty As String Implements IPaintVendor.TextBox8BatchNoProperty
            //'    Get
            //'        Return TextBox8BatchNo.Text
            //'    End Get
            //'    Set(ByVal value As String)
            //'        TextBox8BatchNo.Text = value
            //'    End Set
            //'End Property";

            Builder.AppendLine($"  Public Property {propertyName} As {propertyType} implements {impInterface}.{propertyName}");
            Builder.AppendLine($"       Get");
            Builder.AppendLine($"           Return {backProperty}");
            Builder.AppendLine($"       End Get");
            Builder.AppendLine($"       Set(ByVal value as {propertyType})");
            Builder.AppendLine($"           {backProperty} = value");
            Builder.AppendLine($"       End Set");
            Builder.AppendLine($"   End Property");

        }

        public override IConstructor AddConstructor(params (string, string)[] parameters)
        {
            SpecialConstructors.Add(new VbConstructor(Name, parameters));
            return SpecialConstructors.Last();
        }

        public override void AddField(string fieldType, string fieldName)
        {
            Builder.AppendLine($"   Dim {fieldName} as {fieldType}");
        }
    }
}