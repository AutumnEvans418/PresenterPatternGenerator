namespace PaintScan.Tests
{
    public interface IConstructor : ICreator
    {
        void AddVariable(string variableName, string variableInstiator);
        void AddEventHandler(string eventName, string methodName);
        void InstantiateProperty(string propertyName, string parameterName);
    }
}