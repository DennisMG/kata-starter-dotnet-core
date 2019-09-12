public class Calculator
{
    public int Add(string input= "")
    {
        return string.IsNullOrEmpty(input) ? 0 : int.Parse(input);
    }
}