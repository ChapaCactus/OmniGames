using System.Collections.Generic;

public class TextFormManager
{
    /// <summary>
    /// 年齢を入力するフォーム
    /// </summary>
    public static TextFormManager CreateAgeForm()
    {
        return new AgeFormManager();
    }

    /// <summary>
    /// 名前を入力するフォーム
    /// </summary>
    public static TextFormManager CreateNameForm()
    {
        return new NameFormManager();
    }
}

public class AgeFormManager : TextFormManager
{
    public void InputAge()
    {
    }
}

public class NameFormManager : TextFormManager
{
    public void InputName()
    {
    }
}