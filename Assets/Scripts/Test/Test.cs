using System;
using System.Linq;
using System.Collections.Generic;

public class Data
{
    public TextFormManager Manager { get; set; }

    public string Name { get; set; }
    public int Age { get; set; }
    public Data(string name, int age)
    {
        Name = name;
        Age = age;

        var form =  TextFormManager.CreateNameForm() as NameFormManager;
        form.InputName();
    }
}