
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

        //Constructor for questions with one operator
        public Question(int num1, char op, int num2)
        {
            Num1 = num1;
            Num2 = num2;
            Operator1 = op;
            Operator2 = ' ';
            Num3 = 0;
            Result = CalculateAnswer(num1, num2, op);
        }

        //Constructor for questions with two operators
        public Question(int num1, char op1, int num2, char op2, int num3)
        {
            Num1 = num1;
            Num2 = num2;
            Operator1 = op1;
            Operator2 = op2;
            Num3 = num3;
            Result = CalculateAnswer(num1, num2, op1, num3, op2);
        }

        //Calculate answer for questions with one operator
        private static double CalculateAnswer(int num1, int num2, char op)
        {
            return PerformOperation(num1, num2, op);
        }

        //Calculate answer for questions with two operators
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

        //Preforms operators on 2 given numbers returning a result
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

        //Ask for student name
        Console.Write("Please enter your name: ");
        string StudentName = Console.ReadLine();

        //Define variables for use
        Random Random = new Random();
        char[] Operators = { '+', '-', '*', '/' };

        //Keep track of score
        int Score = 0;

        #region Questions
        //Populate 10 easy questions
        Stack<Question> EasyQuestions = new Stack<Question>();
        for (int i = 0; i < 10; i++)
        {
            //Need to ensure no duplicates values
            int num1 = Random.Next(1, 51);
            int num2 = Random.Next(1, 51);
            char op = Operators[Random.Next(0, 4)];
            EasyQuestions.Push(new Question(num1,op,num2));
        }

        //Score is accumulated within askQuestion() and returned
        Score += AskQuestions(EasyQuestions);

        //Populate 10 easy questions
        Stack<Question> HardQuestions = new Stack<Question>();
        for (int i = 0; i < 10; i++)
        {
            //Need to ensure no duplicate values
            int num1 = Random.Next(1, 51);
            int num2 = Random.Next(1, 51);
            int num3 = Random.Next(1, 51);
            char op1 = Operators[Random.Next(0, 4)];
            char op2 = Operators[Random.Next(0, 4)];
            HardQuestions.Push(new Question(num1, op1, num2, op2, num3));
        }

        //Score is accumulated within askQuestion() and returned
        Score += AskQuestions(HardQuestions);
        #endregion

        //Display the grade of the test
        DiplayGrade(Score, StudentName);
    }

    static int AskQuestions(Stack<Question> questions)
    {
        int score = 0;

        //Loops through a stack of questions until all questions have been asked
        while(questions.Count > 0)
        {
            Question Question = questions.Peek();
            double answer = ObtainAnswer(Question);

            // Determine if answer is correct or not
            if (answer == Question.Result)
            {
                score++;
            }

            questions.Pop();
        }
        return score;
    }

    static double ObtainAnswer(Question question)
    {
        DisplayQuestion(question);
        Console.Write("Answer = ");

        string answer = Console.ReadLine();
        bool valid = double.TryParse(answer, out double number);

        //Check if answer is a valid number
        while (!valid)
        {
            //If not ask question again
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
        //Clear previous question
        Console.Clear();

        //Ask question
        Console.WriteLine("Question:");
        //Changes depending on the number of operators given
        if(question.Operator2 == ' ')
        {
            Console.WriteLine("{0} {1} {2}", question.Num1, question.Operator1, question.Num2);
        }
        else
        {
            Console.WriteLine("{0} {1} {2} {3} {4}", question.Num1, question.Operator1, question.Num2, question.Operator2, question.Num3);
        }
        
    }
    
    static void DiplayGrade(int score, string name)
    {
        //Clear the console
        Console.Clear();

        //Display score
        Console.WriteLine("{0} scored: {1}", name ,score);

        //DisplayGrade
        if(score <= 4)
        {
            Console.WriteLine("Grade: Failed");
        }
        else if (score <= 10)
        {
            Console.WriteLine("Grade: Pass");
        }
        else if (score <= 16)
        {
            Console.WriteLine("Grade: Merit");
        } 
        else
        {
            Console.WriteLine("Distinction");
        }

        //Allow the user to see there grade before exiting.
        Console.ReadLine();
    }
}