using System.ComponentModel.DataAnnotations;

public class MyList
{
    private int[] _arr = null;
    private int _elementCount = 0;

    public void Add(int value)
    {
        if (_arr == null)
        {
            _arr = new int[1];
        }
        else if (_arr.Length == _elementCount)
        {
            int[] newArr = new int[_arr.Length * 2];
            for(int i = 0; i < _arr.Length; i++)
            {
                newArr[i] = _arr[i]; 
            }
            _arr = newArr;
        }

        _arr[_elementCount] = value;
        _elementCount++;
    }

    public void Pop()
    {
        if(_elementCount == 0)
        {
            throw new Exception("List is empty.");
        }

       _arr[_elementCount - 1] = 0;
       _elementCount--;

        //_elementCount--;
    }

    public int GetData(int index)
    {
        if (index < 0 || index >= _elementCount)
        {
            throw new Exception("invalid index exception");
        }

        return _arr[index];
    }

    public void RemoveAt(int index)
    {
        for (int i = index; i < _arr.Length - 1; i++)
        {
            _arr[i] = _arr[i + 1];
        }
        _elementCount--;
    }

    public void Insert(int index , int value)
    {
        if (index < 0 || index >= _elementCount)
        {
            throw new Exception("invalid index exception");
        }

        for (int i = _arr.Length - 2; i >= index; i--)
        {
            _arr[i + 1] = _arr[i];
        }
        _arr[index] = value;
        _elementCount++;
    }

    public void Print()
    {
        for(int i = 0; i < _arr.Length; i++)
        {
            Console.WriteLine(_arr[i]);
        }
    }

    public void Clear()
    {
        for(int i = 0; i < _arr.Length; i++)
        {
            _arr[i] = 0;
        }
        _elementCount = 0;

        //_elementCount = 0;
    }
}
