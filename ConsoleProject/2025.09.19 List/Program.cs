MyList list = new MyList();

list.Add(1);
list.Add(2);
list.Add(3);
list.Add(4);
list.Add(5);

list.RemoveAt(2);

//list.Insert(-2, 10);
list.Insert(3, 30);

list.Pop();

list.Clear();

list.Print();