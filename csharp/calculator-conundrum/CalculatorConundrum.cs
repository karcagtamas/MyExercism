public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        if (operation == null)
        {
            throw new ArgumentNullException("Operation cannot be null");
        }

        if (operation == string.Empty)
        {
            throw new ArgumentException("Operation cannot be empty");
        }

        if (operation == "/" && operand2 == 0)
        {
            return "Division by zero is not allowed.";
        }

        var result = operation switch
        {
          "+" => SimpleOperation.Addition(operand1, operand2),
          "/" => SimpleOperation.Division(operand1, operand2),
          "*" => SimpleOperation.Multiplication(operand1, operand2),
          _ => throw new ArgumentOutOfRangeException("Invalid operation")  
        };

        return $"{operand1} {operation} {operand2} = {result}";
    }
}
