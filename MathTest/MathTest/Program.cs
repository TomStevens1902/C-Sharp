
using System.Runtime.InteropServices;

class Program
{
    struct Question
    {
        #region Question variables
        public int Num1 { get; }

        public char Operator1 { get; }
        public int Num2 { get; }
        public char Operator2 { get; }
        public int Num3 { get; }

        public double Result { get; }
        #endregion

        // Constructor for questions with one operator
        public Question(int num1, char op, int num2)
        {
            Num1 = num1;
            Num2 = num2;
            Operator1 = op;
            Operator2 = ' ';
            Num3 = 0;
            Result = CalculateAnswer(num1, num2, op);
        }

        // Constructor for questions with two operators
        public Question(int num1, char op1, int num2, char op2, int num3)
        {
            Num1 = num1;
            Num2 = num2;
            Operator1 = op1;
            Operator2 = op2;
            Num3 = num3;
            Result = CalculateAnswer(num1, num2, op1, num3, op2);
        }

        // Calculate answer for questions with one operator
        private static double CalculateAnswer(int num1, int num2, char op)
        {
            return PerformOperation(num1, num2, op);
        }

        //calculate answer for questions with two operators
        private static double CalculateAnswer(int num1, int num2, char op1, int num3, char op2)
        {
            double result;
            if ((op1 == '+' || op1 == '-') && (op2 == '*' || op2 == '/'))
            {
                double tempResult = PerformOperation(num2, num3, op2);
                result = PerformOperation(num1, tempResult, op1);
            } else
            {
                double tempResult = PerformOperation(num1, num2, op1);
                result = PerformOperation(tempResult, num3, op2);
            }
            return result;
        }

        private static double PerformOperation(double num1, double num2, char op)
        {
            switch (op)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    //assumption is that values are between 1 and 50
                    return num1 / num2;
                default:
                    throw new ArgumentException("Invalid operator");
            }
        }
    }
    static void Main(string[] args)
    {

        // Input three numbers
        Console.WriteLine("Enter three numbers:");
        int num1 = Convert.ToInt32(Console.ReadLine());
        int num2 = Convert.ToInt32(Console.ReadLine());
        int num3 = Convert.ToInt32(Console.ReadLine());

        // Input two operations (+, -, *, /)
        Console.WriteLine("Enter two operations (+, -, *, /):");
        char op1 = Convert.ToChar(Console.ReadLine());
        char op2 = Convert.ToChar(Console.ReadLine());

        Question question1 = new Question(num1,op1,num2);
        Console.WriteLine(question1.Result);

        Question question2 = new Question(num1, op1, num2, op2, num3);
        Console.WriteLine(question2.Result);
    }

}