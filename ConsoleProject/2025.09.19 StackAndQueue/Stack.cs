public class Stack
{
    private int[] _arr = null;
    private int _count = 0;
    

    public void Push(int inValue)
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

    public int Pop()
    {
        int value = _arr[_count - 1];
        _count--;
        return value;       
    }

    public int Peek()
    {
        return _arr[_count - 1];
    }
}