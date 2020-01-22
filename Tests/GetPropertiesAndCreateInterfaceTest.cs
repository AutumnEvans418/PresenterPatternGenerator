using System;
using System.CodeDom;
using NUnit.Framework;
using PaintScan.Tests.VB.Net;
using WindowsFormsTests;

namespace PaintScan.Tests
{
    [TestFixture]
    public class GetPropertiesAndCreateInterfaceTest
    {

        [Test]
        public void GetNamedProperties()
        {
            string properties = FormPresenterPatternCreator.CreatePresenterPattern(typeof(Form1), new CSharpLanguage());
            Console.WriteLine(properties);
            //Assert.Pass();
        }

        [Test]
        public void PaintTakeDown()
        {
            var result = FormPresenterPatternCreator.CreatePresenterPattern(typeof(Form1), new VbLanguage());
            Console.WriteLine(result);
        }

        [Test]
        public void VBPaintVendorTest()
        {
            string properties = FormPresenterPatternCreator.CreatePresenterPattern(typeof(Form1), new VbLanguage());
            Console.WriteLine(properties);
        }

        [Test]
        public void PaintHangTest()
        {
            var props = FormPresenterPatternCreator.CreatePresenterPattern(typeof(Form1), new CSharpLanguage());
            Console.WriteLine(props);
        }

        [Test]
        public void Form1_Should_Generate3Classes()
        {
            var result = FormPresenterPatternCreator.CreatePresenterPattern<Form1>(new VbLanguage());

            
        }

    }
}