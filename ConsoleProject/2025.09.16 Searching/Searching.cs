using System.Reflection.Metadata.Ecma335;

public static class Searching
{
    public static void DFS(ref string[,] arr , DimensionIndex index)
    {
        if(index.x < 0 || index.x >= 9)
        {
            return;
        }
        if(index.y < 0 || index.y >= 9)
        {
            return;
        }
        if (arr[index.y , index.x] == "x")
        {
            return;
        }

        arr[index.y, index.x] = "x";

        for (int y = 0; y < arr.GetLength(0); y++)
        {
            for (int x = 0; x < arr.GetLength(1); x++)
            {
                Console.Write($" {arr[y, x]} ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("==================================================");

        Console.ReadLine();

        DFS(ref arr, new DimensionIndex() { x = index.x + 1, y = index.y });
        DFS(ref arr, new DimensionIndex() { x = index.x - 1, y = index.y });
        DFS(ref arr, new DimensionIndex() { x = index.x, y = index.y + 1 });
        DFS(ref arr, new DimensionIndex() { x = index.x, y = index.y - 1 });
    }
}