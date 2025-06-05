namespace Live;

class Game
{
    static string[,] place = new string[,] { { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                                             { "+", "0", "+", "0", "0", "0", "0", "0", "0", "0" },
                                             { "0", "+", "+", "0", "0", "0", "0", "0", "0", "0" },
                                             { "0", "+", "0", "0", "0", "0", "0", "0", "0", "0" },
                                             { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                                             { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                                             { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                                             { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                                             { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
                                             { "0", "0", "0", "0", "0", "0", "0", "0", "0", "0" },
    };
    static string[,] placeUpdate = (string[,])place.Clone();

    static int arrayRow = place.GetUpperBound(0) + 1;
    static int arrayColumn = place.Length / arrayRow;

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"row {arrayRow} column {arrayColumn}");
            PrintArray();
            ArrayUpdate();
            place = (string[,])placeUpdate.Clone();
            Thread.Sleep(1000);
        }
    }

    public static void ArrayUpdate()
    {
        for (int i = 0; i < arrayRow; i++)
        {
            for (int j = 0; j < arrayColumn; j++)
            {
                if (LiveChecker(i, j))
                {
                    placeUpdate[i, j] = "+";
                }
                else
                {
                    placeUpdate[i, j] = "0";
                }
            }
        }
    }

    public static bool LiveChecker(int row, int column)
    {
        bool itLive = false;
        if (place[row, column] == "+") itLive = true;

        int countLiveObject = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int newRow = row - i + 1;
                int newColumn = column - j + 1;
                if ((newRow, newColumn) == (row, column)) continue;

                if (newRow < 0 || newRow > arrayRow - 1) newRow = Math.Abs(Math.Abs(newRow) - arrayRow);
                if (newColumn < 0 || newColumn > arrayColumn - 1) newColumn = Math.Abs(Math.Abs(newColumn) - arrayColumn); ;

                if (place[newRow, newColumn] == "+") countLiveObject++;
            }
        }

        if ((itLive && countLiveObject >= 2 && countLiveObject <= 3) || (!itLive && countLiveObject == 3))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void PrintArray()
    {
        PrintBox();
        for (int i = 0; i < arrayRow; i++)
        {
            Console.Write("|");
            for (int j = 0; j < arrayColumn; j++)
            {
                Console.Write($"{place[i, j]}");
            }
            Console.Write("|\n");
        }
        PrintBox();
    }

    public static void PrintBox()
    {
        Console.Write("+");
        for (int column = 0; column < arrayColumn; column++)
        {
            Console.Write("-");
        }
        Console.Write("+\n");
    }
}
