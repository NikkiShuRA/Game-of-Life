namespace Live;

class Game
{
    static string[,] place = new string[,] { { "0", "+", "0", },
                                             { "0", "+", "0", },
                                             { "0", "+", "0", },
    };
    static string[,] placeUpdate = (string[,])place.Clone();

    static int h = place.GetUpperBound(0) + 1;
    static int w = place.Length / h;

    static void Main()
    {
        while (true)
        {
            Console.WriteLine($"r {h} c {w}");
            PrintArray();
            ArrayUpdate();
            place = (string[,])placeUpdate.Clone();
            Thread.Sleep(1000);
        }
    }

    public static void ArrayUpdate()
    {
        int rows = place.GetUpperBound(0) + 1;
        int columns = place.Length / rows;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
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

    public static bool LiveChecker(int r, int c)
    {
        bool itLive = false;
        if (place[r, c] == "+") itLive = true;

        int countLiveObject = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int newR = r - i + 1;
                int newC = c - j + 1;
                if ((newR, newC) == (r, c)) continue;
                if ((newR < 0 || newR > h-1) || (newC < 0 || newC > w - 1)) continue;
                if (place[newR, newC] == "+") countLiveObject++;
            }
        }

        if ((itLive && countLiveObject >= 2) || countLiveObject >= 3) 
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
        for (int i = 0; i < h; i++)
        {
            Console.Write("|");
            for (int j = 0; j < w; j++)
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
        for (int column = 0; column < w; column++)
        {
            Console.Write("-");
        }
        Console.Write("+\n");
    }
}
