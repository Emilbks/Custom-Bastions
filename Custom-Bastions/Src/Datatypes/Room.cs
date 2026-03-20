namespace CustomBastion;
public abstract class Room : IPrintable, IPrintableInline
{
    public string name { get; protected set; }
    public string shorthand { get; protected set; }
    public string description { get; protected set; }
    public int initSize { get; protected set; }
    public int builtSquares { get; protected set; }
    public int usedSquares { get; protected set; }
    public int maxSize { get; protected set; }
    public string requirements { get; protected set; }
    public int minLevel { get; protected set; }
    public int hirelings { get; protected set; }
    public ConsoleColor textColor { get; protected set; }
    public ConsoleColor backgroundColor { get; protected set; }
    
    protected List<RoomFeature> roomFeatures;

    protected Room()
    {
        name = "";
        shorthand = "";
        description = "";
        initSize = 0;
        maxSize = 0;
        requirements = "";
        minLevel = 5;
        hirelings = 0;
        roomFeatures = new List<RoomFeature>();
        builtSquares = 0;
        usedSquares = 0;
        textColor = ConsoleColor.White;
        backgroundColor = ConsoleColor.Black;
    }

    public abstract void Print();

    public void PrintInline()
    {
        ConsoleColor oldTextColor = Console.ForegroundColor;
        ConsoleColor oldBackgroundColor = Console.BackgroundColor;

        Console.ForegroundColor = textColor;
        Console.BackgroundColor = backgroundColor;
        Console.Write(shorthand);

        Console.ForegroundColor = oldTextColor;
        Console.BackgroundColor = oldBackgroundColor;
    }
}