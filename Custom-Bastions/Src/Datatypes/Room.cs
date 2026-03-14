namespace CustomBastion;
public abstract class Room : IPrintable, IPrintableInline
{
    protected string name;
    protected string shorthand;
    protected string description;
    protected int InitSize;
    protected int BuiltSquares;
    protected int UsedSquares;
    protected int MaxSize;
    protected string Requirements;
    protected int MinLevel;
    protected string HireLings;
    private ConsoleColor TextColor;
    private ConsoleColor BackgroundColor;
    
    protected List<RoomFeature> RoomFeatures;

    protected Room(string name, string shorthand, string description, int initSize, int maxSize, string requirements, int minLevel, string hireLings, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        this.name = name;
        this.shorthand = shorthand;
        this.description = description;
        InitSize = initSize;
        MaxSize = maxSize;
        Requirements = requirements;
        MinLevel = minLevel;
        HireLings = hireLings;
        RoomFeatures = new List<RoomFeature>();
        BuiltSquares = InitSize;
        UsedSquares = InitSize;
        TextColor = textColor;
        BackgroundColor = backgroundColor;
    }

    public abstract void Print();

    public void PrintInline()
    {
        ConsoleColor oldTextColor = Console.ForegroundColor;
        ConsoleColor oldBackgroundColor = Console.BackgroundColor;

        Console.ForegroundColor = TextColor;
        Console.BackgroundColor = BackgroundColor;
        Console.Write(shorthand);

        Console.ForegroundColor = oldTextColor;
        Console.BackgroundColor = oldBackgroundColor;
    }
}