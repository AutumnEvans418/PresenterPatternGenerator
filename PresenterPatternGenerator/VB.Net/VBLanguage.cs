namespace PaintScan.Tests.VB.Net
{
    public class VbLanguage : IProgramLanguage
    {
        public IClass CreateClass(string name)
        {
            return new VbClass(name);
        }

        public IInterface CreateInterface(string name)
        {
            return new VbInterface(name);
        }
    }
}