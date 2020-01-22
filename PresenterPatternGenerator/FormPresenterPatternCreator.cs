using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PaintScan.Tests
{
    public static class FormPresenterPatternCreator
    {
        private static void CreateClassProperty(string backProperty, string propertyType, string propertyName, IClass classmodel, string inter)
        {
            //strInterface.AppendLine($"{propertyType} {propertyName}" + " { get => " + $"{backProperty};" + " set => " + $"{backProperty} = value" + "; }");
            classmodel.AddFullProperty(propertyType, propertyName, backProperty, inter);
        }


        private static void CreateInterfaceProperty( PropertyInfo propertyInfo, string type, IInterface inInterface)
        {
            inInterface.AddProperty(propertyInfo.Name + "Property", type);
            //strInterface.AppendLine($"{type} {propertyInfo.Name}Property" + " { get; set; }");
        }

        public static string CreatePresenterPattern(Type type, IProgramLanguage language)
        {
            var result = type
                .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(p => p.PropertyType.IsSubclassOf(typeof(Control)));
            //var strInterface = new StringBuilder();
            var inter = language.CreateInterface("I" + type.Name);
            var strForm = language.CreateClass(type.Name);

            strForm.ImplementInterface(inter.Name);
            //var strForm = new StringBuilder();
            var strPresenter = language.CreateClass(type.Name + "Presenter");
            var constructor = strPresenter.AddConstructor(($"I{type.Name}", "view"));
            strPresenter.AddField($"I{type.Name}", "_view");
            constructor.InstantiateProperty("_view", "view");
            var strFormCtor = strForm.Constructor;
            strFormCtor.AddVariable("presenter", $"new {type.Name}Presenter(this)");
            foreach (var propertyInfo in result)
            {
                bool T(Type t)
                {
                    return propertyInfo.PropertyType == t;
                }

                void CreateInt(string strType)
                {
                    CreateInterfaceProperty( propertyInfo, strType, inter);
                }

                void Create(string strType, string clsType)
                {
                    CreateInt(strType);
                    CreateClassProperty($"{propertyInfo.Name}.{clsType}", strType, propertyInfo.Name + "Property", strForm, $"I{type.Name}");
                }
                if (T(typeof(TextBox)))
                {
                    Create("string", "Text");
                }
                else if (T(typeof(Label)))
                {
                    Create("string", "Text");
                }
                else if (T(typeof(Button)))
                {
                    strFormCtor.AddEventHandler($"{propertyInfo.Name}.Clicked",$"presenter.{propertyInfo.Name}Method");
                    strPresenter.AddMethod(
                        $"{propertyInfo.Name}Method");
                    //strInterface.AppendLine($"void {propertyInfo.Name}Method();");
                }

                else if (T(typeof(RadioButton)))
                {
                    Create("Boolean", "Checked");
                }
                else if (T(typeof(CheckBox)))
                {
                    Create("Boolean", "Checked");
                }
                else if (T(typeof(DateTimePicker)))
                {
                    Create("DateTime", "Value");
                }
                else if (T(typeof(DataGridView)))
                {
                    Create("ObservableCollection<object>", "DataSource");
                }
                else if (T(typeof(PictureBox)))
                {
                    Create("string", "Source");
                }
                else if (T(typeof(ComboBox)))
                {
                    Create("ObservableCollection<object>", "DataSource");
                    inter.AddProperty($"Selected{propertyInfo.Name}Property", "object");
                    //strInterface.AppendLine($"object Selected{propertyInfo.Name}Property" + " { get; set; }");
                }
                else if (propertyInfo.PropertyType.IsSubclassOf(typeof(Panel)) || T(typeof(Panel)))
                {

                }
                else if (T(typeof(GroupBox)))
                {

                }
                else if (T(typeof(Form)))
                {

                }
                else if (T(typeof(MdiClient)))
                {

                }
                else if (T(typeof(ContainerControl)))
                {

                }
                else if (typeof(TextBox).Assembly == propertyInfo.PropertyType.Assembly)
                {
                    throw new NotImplementedException($"{propertyInfo.PropertyType} has not been implemented");
                }
            }

            //strPresenter.AppendLine("}");
            //strFormCtor.AppendLine("}");

           // strForm.Append(strFormCtor);
            //strInterface.AppendLine("}");
           // strForm.AppendLine("}");
            return inter.Result() + Environment.NewLine + strForm.Result() + Environment.NewLine + strPresenter.Result();
        }
    }
}