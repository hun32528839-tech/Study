public class Node
{
    public int value;
    public Node nextNode;
}

public class LinkedList
{
    public Node root;
   
    int count = 0;

    public void Add(int inValue)
    {
        if (root == null)
        {
            root = new Node();
            root.value = inValue;
        }
        else
        {
            Node temp = root;
            while (temp.nextNode != null) // temp 노드에 끝은 찾기 위해서
            {
                temp = temp.nextNode;
            }
            temp.nextNode = new Node();
            temp.nextNode.value = inValue;
        }
        count++;
    }

    public bool Contains(int inValue)
    {
        Node temp = root;

        while (temp != null)
        {
            if (temp.value == inValue)
            {
                return true;
            }
            temp = temp.nextNode;
        }
        return false;
    }

    public void Print()
    {
        Node temp = root;

        while (temp != null)
        {
            Console.WriteLine(temp.value);
            temp = temp.nextNode;
        }
    }

    public void Remove(int inValue)
    {
        Node temp = root;
        Node prev = null; // 삭제하기 위해서 이전 노드를 알아야 함

        while (temp != null)
        {
            if (temp.value == inValue)
            {
                if (prev == null) // 현재 탐색 중인 노드(temp)가 root 노드라는 뜻
                {
                    root = root.nextNode;
                    count--;
                }
                else // 현재 탐색 중인 노드(temp)가 root 노드가 아니라는 뜻
                {
                    prev.nextNode = temp.nextNode; // 이전 노드(prev)의 다음 노드(nextNode)를 현재 노드(temp)의 다음 노드로 연결한다는 의미
                    count--;
                }
                break;
            }
            prev = temp;
            temp = temp.nextNode;
        }
    }

    public void RemoveAt(int inIndex)
    {
        int index = 0;

        Node temp = root;
        Node prev = null;

        while (temp != null)
        {
            if (index == inIndex)
            {
                if (prev == null)
                {
                    root = root.nextNode;
                    count--;
                }
                else
                {
                    prev.nextNode = temp.nextNode;
                    count--;
                }
                break;
            }
            prev = temp;
            temp = temp.nextNode;
            index++;
        }
    }

    public void Clear()
    {
        root = null;
        count = 0;
    }

    public int GetCount()
    {
        return count;
    }
}







