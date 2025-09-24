public class Queue
{
    private int[] _arr = null;
    private int _count = 0;

    public void Enqueue(int inValue)
    {
        if(_arr == null)
        {
            _arr = new int[1];
        }
        else if(_arr.Length == _count)
        {
            int[] newArr = new int[_arr.Length * 2];
            for(int i = 0; i < _arr.Length; i++)
            {
                newArr[i] = _arr[i];
            }
            _arr = newArr;
        }

        _arr[_count] = inValue;
        _count++;

    }

    int index = 0;
    public int Dequeue()
    {
        int value = _arr[index];
        index++;
        _count--;

        return value;
    }

    public int Peek()
    {               
        return _arr[index];
    }
}