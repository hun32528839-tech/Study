using System.Runtime.Serialization.Formatters;

string[,] arr = new string[9, 9];

for(int y = 0; y < arr.GetLength(0); y++)
{
    for(int x = 0; x < arr.GetLength(1); x++)
    {
        arr[y, x] = "x";
    }
    Console.WriteLine();
}

for(int y = 1; y < arr.GetLength(0) - 1; y++)
{
    for(int x = 1; x < arr.GetLength(1) - 1; x++)
    {
        arr[y, x] = "o";
    }
    Console.WriteLine();
}

for (int y = 0; y < arr.GetLength(0); y++)
{
    for (int x = 0; x < arr.GetLength(1); x++)
    {
        Console.Write($" {arr[y, x]} ");
    }
    Console.WriteLine();
}

Console.WriteLine("================================================================");

//Console.ReadLine();

//Searching.DFS(ref arr, new DimensionIndex() { x = 4, y = 4 }); // 재귀 함수



// Queue를 사용해서 BFS(너비 우선 탐색)
Queue<DimensionIndex> searchingIndexContainer = new Queue<DimensionIndex>();

searchingIndexContainer.Enqueue(new DimensionIndex() { x = 4, y = 4 });

while (searchingIndexContainer.Count != 0)
{
    DimensionIndex dequeueData = searchingIndexContainer.Dequeue();

    if (dequeueData.x < 0 || dequeueData.x >= 9)
    {
        continue;
    }
    if (dequeueData.y < 0 || dequeueData.y >= 9)
    {
        continue;
    }
    if (arr[dequeueData.y, dequeueData.x] == "x")
    {
        continue;
    }

    arr[dequeueData.y, dequeueData.x] = "x";

    searchingIndexContainer.Enqueue(new DimensionIndex() { x = dequeueData.x - 1, y = dequeueData.y });
    searchingIndexContainer.Enqueue(new DimensionIndex() { x = dequeueData.x + 1, y = dequeueData.y });
    searchingIndexContainer.Enqueue(new DimensionIndex() { x = dequeueData.x, y = dequeueData.y - 1 });
    searchingIndexContainer.Enqueue(new DimensionIndex() { x = dequeueData.x, y = dequeueData.y + 1 });


    for (int y = 0; y < arr.GetLength(0); y++)
    {
        for (int x = 0; x < arr.GetLength(1); x++)
        {
            Console.Write($" {arr[y, x]} ");
        }
        Console.WriteLine();
    }

    Console.WriteLine("===========================================================");

    Console.ReadLine();
}



//Stack<DimensionIndex> searchingIndexContainer = new Stack<DimensionIndex>();

//searchingIndexContainer.Push(new DimensionIndex() { x = 4, y = 4 });

//while(searchingIndexContainer.Count != 0)
//{
//    DimensionIndex popData = searchingIndexContainer.Pop();

//    if(popData.x < 0 || popData.x >= 9)
//    {
//        continue;
//    }
//    if(popData.y < 0 || popData.y >= 9)
//    {
//        continue;
//    }
//    if (arr[popData.y,popData.x] == "x")
//    {
//        continue;
//    }

//    arr[popData.y, popData.x] = "x";

//    searchingIndexContainer.Push(new DimensionIndex() { x = popData.x - 1, y = popData.y });
//    searchingIndexContainer.Push(new DimensionIndex() { x = popData.x + 1, y = popData.y });
//    searchingIndexContainer.Push(new DimensionIndex() { x = popData.x, y = popData.y - 1 });
//    searchingIndexContainer.Push(new DimensionIndex() { x = popData.x, y = popData.y + 1 });


//    for(int y = 0; y < arr.GetLength(0); y++)
//    {
//        for(int x = 0; x < arr.GetLength(1); x++)
//        {
//            Console.Write($" {arr[y, x]} ");
//        }
//        Console.WriteLine();
//    }

//    Console.WriteLine("=====================================================================");

//    Console.ReadLine();
//}