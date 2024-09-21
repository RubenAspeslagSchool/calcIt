using NCalc;
namespace calcItWeb.Client.Models
{
    public class CalculatorModel
    {
        public string calculatorInput { get; set; }

        public string calculatorOutput
        {
            get => EvaluateExpression(calculatorInput);
        }

        static string EvaluateExpression(string expression)
        {
            try
            {
                NCalc.Expression e = new NCalc.Expression(expression);  // Explicit reference to NCalc.Expression
                return Convert.ToDouble(e.Evaluate()).ToString();
            } catch (Exception ex) { }
            {
                return $"error ";
            }
            
        }
    }
}
