namespace PaintScan.Tests
{
    public interface IInterface : ICreator
    {
        string Name { get; }
        //void AddFullProperty(PropertyInfo name, string type);
        void AddProperty(string name, string type);
    }
}