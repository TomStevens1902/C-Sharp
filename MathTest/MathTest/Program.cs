
using System;
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
                    // Assumption is that values are between 1 and 50
                    // Rounded to two demical places
                    return Math.Round(num1 / num2, 2);
                default:
                    throw new ArgumentException("Invalid operator");
            }
        }
    }
    static void Main(string[] args)
    {

        Console.WriteLine("Welcome to the Math Test!");
        Console.Write("Please enter your name: ");
        string studentName = Console.ReadLine();

        Random random = new Random();
        char[] operators = { '+', '-', '*', '/' };

        //First 10 basic questions
        Stack<Question> EasyQuestions = new Stack<Question>();
        for (int i = 0; i < 10; i++)
        {
            int num1 = random.Next(1, 51);
            int num2 = random.Next(1, 51);
            char op = operators[random.Next(0, 4)];
            EasyQuestions.Push(new Question(num1,op,num2));
        }

        AskQuestions(EasyQuestions);

    }

    static void AskQuestions(Stack<Question> questions)
    {
        while(questions.Count > 0)
        {
            Question Question = questions.Peek();

            double Answer = ObtainAnswer(Question);



            // Determine if answer is correct or not
            if (Answer == Question.Result)
            {
                //correct
                Console.WriteLine("Correct");
                Console.ReadLine();
            }
            else
            {
                //false
                Console.WriteLine("False");
                Console.ReadLine();
            }

            questions.Pop();
        }
    }

    static double ObtainAnswer(Question question)
    {
        DisplayQuestion(question);
        Console.Write("Answer = ");

        string answer = Console.ReadLine();
        bool valid = double.TryParse(answer, out double number);

        // Check if answer is a valid number
        while (!valid)
        {
            // If not ask question again
            DisplayQuestion(question);
            Console.WriteLine("Please enter numbers only such as '42'");
            Console.Write("Answer = ");
            answer = Console.ReadLine();
            valid = double.TryParse(answer, out number);
        }

        return number;
    }

    static void DisplayQuestion(Question question)
    {
        // Clear previous question
        Console.Clear();

        // Ask question
        Console.WriteLine("Question:");
        Console.WriteLine("{0} {1} {2}", question.Num1, question.Operator1, question.Num2);
    }
    
}