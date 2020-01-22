using System.Reflection;

namespace PaintScan.Tests
{
    public interface IClass : ICreator
    {
        IConstructor Constructor { get; }
        void ImplementInterface(string interfaceimp);
        void AddMethod(string name);
        void AddFullProperty(string propertyType, string propertyName, string backProperty, string implementInteface);
        IConstructor AddConstructor(params (string, string)[] parameters);
        void AddField(string fieldType, string fieldName);
    }
}