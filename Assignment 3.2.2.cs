/* Assignment 3.2.2
2. Write a program in C# Sharp for addition of two Matrices of the same size.

Test Data :
Input the size of the square matrix (less than 5): 2
Input elements in the first matrix :

element - [0],[0] : 1
element - [0],[1] : 2
element - [1],[0] : 3
element - [1],[1] : 4

Input elements in the second matrix :
element - [0],[0] : 5
element - [0],[1] : 6
element - [1],[0] : 7
element - [1],[1] : 8

Expected Output:
The First matrix is:
1 2
3 4

The Second matrix is :
5 6
7 8

The Addition of two matrix is :
6 8
10 12
*/
public class Program
{
    /// <summary> Prompts the user for input and ensures a non-empty string is returned. This is the non-generic overload.</summary>
    /// <param name="prompt">The message to display to the user.</param>
    /// <returns>A non-null, non-whitespace string from the user.</returns>
    private static string GetUserInput(string prompt)
    {
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }
    /// <summary> Prompts the user for input, validates it, and converts it to the specified type `T`.
    /// See https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics for more details.
    /// </summary>
    /// <typeparam name="T">The desired type (e.g., int, decimal, double), which must be parsable.</typeparam>
    /// <param name="prompt">The message to display to the user.</param>
    /// <param name="parseErrorMessage">An optional custom error message to display on parsing failure.</param>
    /// <returns>A valid value of type `T` from the user.</returns>
    private static T GetUserInput<T>(string prompt, string? parseErrorMessage = null) where T : IParsable<T>
    {
        T? value;
        while (!T.TryParse(GetUserInput(prompt), null, out value)) // Calls GetUserInput() to get the raw user input first.
        {
            Console.WriteLine(parseErrorMessage ?? $"Invalid input. Please enter a valid {typeof(T).Name}.");
        }
        return value;
    }
    private static void PrintMatrix(int[,] matrix) // print matrix with formatting
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            Console.Write("|");
            for (int j = 0; j < cols; j++)
            {
                Console.Write(" " + matrix[i, j] + " |");
            }
            Console.WriteLine();
        }
    }
    private static void InputElements(int[,] matrix, int size, string matrixName) // input elements into matrix from user
    {
        Console.WriteLine($"Input elements in the {matrixName} matrix :");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = GetUserInput<int>($"element - [{i}],[{j}] : ", "Invalid input. Please enter a whole number.");
            }
        }
    }
    public static void Main(string[] args)
    {
        int size;
        do // get size of square matrix from user, must be less than 5
        {
            size = GetUserInput<int>("Input the size of the square matrix (less than 5): ", "Please enter a whole number between 1 and 4 or we will be here all day.");
        } while (size < 1 || size > 4);

        int[,] matrix1 = new int[size, size];
        int[,] matrix2 = new int[size, size];
        int[,] result = new int[size, size];

        // input elements into first matrix
        InputElements(matrix1, size, "first");
        // input elements into second matrix
        InputElements(matrix2, size, "second");
                
        // adding two matrices, iterate through both and add corresponding elements in their positions
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }
        Console.WriteLine("The First matrix is:");
        PrintMatrix(matrix1);
        // print second matrix
        Console.WriteLine("The Second matrix is:");
        PrintMatrix(matrix2);
        // print result
        Console.WriteLine("The Addition of two matrix is:");
        PrintMatrix(result);
    }
}