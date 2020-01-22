namespace PaintScan.Tests
{
    public class CSharpLanguage : IProgramLanguage
    {
        public IClass CreateClass(string name)
        {
            return new CSharpClass(name);
        }

        public IInterface CreateInterface(string name)
        {
            return new CSharpInterface(name);
        }
    }
}