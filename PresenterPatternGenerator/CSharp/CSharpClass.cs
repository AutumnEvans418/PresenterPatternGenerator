using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PaintScan.Tests
{
    public class CSharpClass : ClassBase, IClass
    {
        //public IConstructor Constructor { get; }

        public override string StartClass()
        {
            var build = new StringBuilder();
            build.Append($"public class {Name}");

            if (interfaces.Any())
            {
                build.Append($" : {interfaces.Aggregate((f, s) => f + "," + s)}");
            }

            build.AppendLine("");

            build.AppendLine("{");
            return build.ToString();
        }

        public override string EndClass()
        {
            return "}" + Environment.NewLine;
        }

       

        public override void AddMethod(string name)
        {
            Builder.AppendLine($"{name}() => throw new NotImplementedException();");
        }

        public override void AddFullProperty(string propertyType, string propertyName, string backProperty, string impinterface)
        {
            Builder.AppendLine($"{propertyType} {propertyName}" + " { get => " + $"{backProperty};" + " set => " + $"{backProperty} = value" + "; }");
        }

        public override IConstructor AddConstructor(params (string, string)[] parameters)
        {
            SpecialConstructors.Add(new CSharpParamterConstructor(Name, parameters));
            return SpecialConstructors.Last();
        }

        public override void AddField(string fieldType, string fieldName)
        {
            Builder.AppendLine($"{fieldType} {fieldName};");
        }

        //public override string Result()
        //{
        //    var build = new StringBuilder();
        //    build.AppendLine($"public class {Name}");
        //    build.AppendLine("{");
        //    build.Append(Builder);
        //    build.Append(Constructor.Result());
        //    foreach (var specialConstructor in _specialConstructors)
        //    {
        //        build.Append(specialConstructor.Result());
        //    }
        //    build.AppendLine("}");
        //    return build.ToString();
        //}

        public CSharpClass(string name) : base(name)
        {
            Constructor = new CSharpDefaultConstructor(name);
        }
    }
}