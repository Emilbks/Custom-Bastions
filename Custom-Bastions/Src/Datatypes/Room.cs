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
    protected int Hirelings;
    private ConsoleColor TextColor;
    private ConsoleColor BackgroundColor;
    
    protected List<RoomFeature> RoomFeatures;

    protected Room()
    {
        name = "name";
        shorthand = "shorthand";
        description = "description";
        InitSize = 0;
        MaxSize = 0;
        Requirements = "requirements";
        MinLevel = 5;
        Hirelings = 0;
        RoomFeatures = new List<RoomFeature>();
        BuiltSquares = 0;
        UsedSquares = 0;
        TextColor = ConsoleColor.White;
        BackgroundColor = ConsoleColor.Black;
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