using System.Collections.Generic;
using System.Text;

namespace PaintScan.Tests
{

    public abstract class ClassBase : CreatorBase, IClass
    {
        public ClassBase(string name) : base(name)
        {
        }

        public override string Result()
        {
            var build = new StringBuilder();
            build.Append(StartClass());
            build.Append(Builder);
            build.Append(Constructor.Result());
            foreach (var specialConstructor in SpecialConstructors)
            {
                build.Append(specialConstructor.Result());
            }
            build.Append(EndClass());
            return build.ToString();
        }

        public abstract string StartClass();
        public abstract string EndClass();
        protected readonly List<IConstructor> SpecialConstructors = new List<IConstructor>();

        public IConstructor Constructor { get; set; }


        protected readonly List<string> interfaces = new List<string>();
        public void ImplementInterface(string interfaceimp)
        {
            interfaces.Add(interfaceimp);
        }

        public abstract void AddMethod(string name);

        public abstract void AddFullProperty(string propertyType, string propertyName, string backProperty, string impinteface);

        public abstract IConstructor AddConstructor(params (string, string)[] parameters);

        public abstract void AddField(string fieldType, string fieldName);
    }

    public abstract class CreatorBase : ICreator
    {
        public string Name { get; }

        public CreatorBase(string name)
        {
            Name = name;
        }
        protected readonly StringBuilder Builder = new StringBuilder();
        public abstract string Result();
    }
}