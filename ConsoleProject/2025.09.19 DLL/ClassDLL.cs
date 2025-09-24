public class Node
{
    public int Value;
    public Node PrevNode;
    public Node NextNode;
}

public class DLL
{
    public Node Head;
    public Node Tail;

    int count = 0;

    public void Add(int inValue)
    {
        Node newNode = new Node();
        newNode.Value = inValue;

        if (Head == null && Tail == null)
        {
            Head = newNode;
            Tail = newNode;
            count++;
        }
        else
        {
            newNode.PrevNode = Tail;
            Tail.NextNode = newNode;
            Tail = newNode;
            count++;
        }
    }

    public bool Contains(int inValue)
    {
        Node currentHead = Head;

        while (currentHead != null)
        {
            if (currentHead.Value == inValue)
            {
                return true;
            }
            currentHead = currentHead.NextNode;
        }
        return false;
    }

    public void Print()
    {
        Node currentHead = Head;

        while (currentHead != null)
        {
            Console.WriteLine(currentHead.Value);
            currentHead = currentHead.NextNode;
        }
    }

    public void Remove(int inValue)
    {
        
        if (Head == null || Tail == null)
        {
            throw new Exception("invalid index exception");
        }

        if (Head.Value == inValue)
        {
            Head = Head.NextNode;

            Head.PrevNode = null;

            count--;

            return;
        }

        if (Tail.Value == inValue)
        {
            Tail = Tail.PrevNode;

            Tail.NextNode = null;

            count--;

            return;
        }

        Node current = Head.NextNode;

        while (current != null)
        {
            if (current.Value == inValue)
            {
                current.PrevNode.NextNode = current.NextNode;
                current.NextNode.PrevNode = current.PrevNode;
                count--;
                break;
            }
            current = current.NextNode;
        }
    }

    public void RemoveAt(int inIndex)
    {
        Node current = Head;

        int index = 0;

        while (current != null)
        {
            if (index == inIndex)
            {
                if (current == Head) // 주소값(참조) 비교 
                {
                    Head = Head.NextNode;
                    Head.PrevNode = null;
                    count--;
                    break;
                }

                else if (current == Tail)
                {
                    Tail = Tail.PrevNode;
                    Tail.NextNode = null;
                    count--;
                    break;
                }

                else
                {
                    current.PrevNode.NextNode = current.NextNode;
                    current.NextNode.PrevNode = current.PrevNode;
                    count--;
                    break;
                }
            }
            current = current.NextNode;
            index++;
        }
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
    }

    public int GetCount()
    {
        return count;
    }

}







