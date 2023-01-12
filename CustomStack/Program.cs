using System.Runtime.Intrinsics.X86;

public enum YourColor
{
    Red,
    Black
}

public class Item
{
    public YourColor Color { get; }
    public object Obj { get; }

    public Item(YourColor color, object obj)
    {
        Color = color;
        Obj = obj;
    }
}
public class CustomStack
{
    public Stack<Item> myItems;

    public CustomStack()
    {
        myItems = new Stack<Item>();
    }

    public void Push(YourColor color, object value)
    {
        myItems.Push(new Item(color, value));
    }

    public object Pop()
    {
        return myItems.TryPop(out Item item) ? item.Obj : null;

    }

    public object FindLastByColor(YourColor yourColor)
    {
        var item = myItems.FirstOrDefault(i => i.Color == yourColor);
        return item.Obj;
    }
}
public class Program
{
    public static void Main()
    {
        var stack = new CustomStack();
        stack.Push(YourColor.Red, 3);
        stack.Push(YourColor.Black, 5);
        stack.Push(YourColor.Red, 2);
        Console.WriteLine(stack.FindLastByColor(YourColor.Black));
        stack.Pop();
        Console.WriteLine(stack.FindLastByColor(YourColor.Red));


    }
}

