namespace PaintScan.Tests
{
    public interface IProgramLanguage
    {
        IClass CreateClass(string name);
        IInterface CreateInterface(string name);
    }
}