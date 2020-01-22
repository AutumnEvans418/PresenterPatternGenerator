# Presenter Pattern Generator (Windows.Forms)

Windows forms apps are hard to maintain and hard to test.  By default, windows forms apps have a tight coupling to the view.  The goal of this project is to change that by making it easy to implement the presenter pattern.

## How does this work?

Most Windows forms apps use the same controls and properties over and over again.  This program uses reflection to scan your forms for fields and implements the controls using the presenter pattern.  


This project converts windows forms into the presenter pattern so that code can be tested easily

## How do I use it?

The ```FormsPresenterPatternCreator``` can be used to generate the classes like so:

```var result = FormPresenterPatternCreator.CreatePresenterPattern<Form1>(new VbLanguage());```

This will return a string with the content shown below:

```vb
Public Interface IForm1
   Property listBox1Property As ObservableCollection<object>
   Property SelectedlistBox1Property As object
   Property textBox1Property As string
End Interface

Public Class Form1
 Implements IForm1
  Public Property listBox1Property As ObservableCollection<object> implements IForm1.listBox1Property
       Get
           Return listBox1.DataSource
       End Get
       Set(ByVal value as ObservableCollection<object>)
           listBox1.DataSource = value
       End Set
   End Property
  Public Property textBox1Property As string implements IForm1.textBox1Property
       Get
           Return textBox1.Text
       End Get
       Set(ByVal value as string)
           textBox1.Text = value
       End Set
   End Property
    Sub New()
       dim presenter = new Form1Presenter(this)
       AddHandler button1.Clicked, sub(s, args) presenter.button1Method()
       AddHandler button2.Clicked, sub(s, args) presenter.button2Method()
    End Sub
End Class

Public Class Form1Presenter
   Dim _view as IForm1
   Public Sub button1Method
        throw new NotImplementedException()
    End Sub
   Public Sub button2Method
        throw new NotImplementedException()
    End Sub
    Sub New()
    End Sub
    Sub New(view as IForm1)
       _view = view
    End Sub
End Class
```
OR
```csharp
public interface IForm1
{
   ObservableCollection<object> listBox1Property { get; set; }
   object SelectedlistBox1Property { get; set; }
   string textBox1Property { get; set; }
}

public class Form1 : IForm1
{
    ObservableCollection<object> listBox1Property { get => listBox1.DataSource; set => listBox1.DataSource = value; }
    string textBox1Property { get => textBox1.Text; set => textBox1.Text = value; }
    public Form1()
    {
        var presenter = new new Form1Presenter(this)
        button1.Clicked += (s,args) => presenter.button1Method();
        button2.Clicked += (s,args) => presenter.button2Method();
    }
}

public class Form1Presenter
{
    IForm1 _view;
    button1Method() => throw new NotImplementedException();
    button2Method() => throw new NotImplementedException();
    public Form1Presenter()
    {
    }
    public Form1Presenter(IForm1 view)
    {
        _view = view;
    }
}
```

## Why would I use this?

This is mainly used to convert old projects into code that can be easily tested.  The goal would be to event make this an easy refactoring style change that would allow developers to create a presenter class that they can test the logic of their form with.

## Feature List
- [x] Convert fields to properties
- [x] Convert methods to presenter methods
- [ ] Copy the contents of the methods and have them reference the new properties
- [ ] Check what properties of each field is used and generate those.
## Resources

https://stackoverflow.com/questions/13679240/parsing-function-method-content-using-reflection