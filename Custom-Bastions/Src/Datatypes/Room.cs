namespace CustomBastion;
using System.Text.Json;
using static CustomBastion.Shortcuts;
public abstract class Room : IPrintable, IPrintableInline
{
    protected string name;
    protected string shorthand;
    protected string description;
    protected int InitSize;
    protected int BuiltSquares;
    protected int UsedSquares;
    protected int MaxSize;
    protected int buildCost;
    protected int timeToBuild;
    protected int expandCost;
    protected string Requirements;
    protected int MinLevel;
    protected string HireLings;
    private ConsoleColor TextColor;
    private ConsoleColor BackgroundColor;

    protected string perks;
    protected List<RoomFeature> RoomFeatures;
    protected List<RoomFeature> BuiltFeatures;
    protected Room(string name, string shorthand, string description, int initSize, int maxSize, int buildCost, int timeToBuild, int expandCost, string requirements, 
        int minLevel, string hireLings, string perks,  ConsoleColor textColor = ConsoleColor.White, 
        ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        this.name = name;
        this.shorthand = shorthand;
        this.description = description;
        InitSize = initSize;
        MaxSize = maxSize;
        this.buildCost = buildCost;
        this.timeToBuild = timeToBuild;
        this.expandCost = expandCost;
        Requirements = requirements;
        MinLevel = minLevel;
        HireLings = hireLings;
        this.perks = perks;
        RoomFeatures = new List<RoomFeature>();
        BuiltFeatures = new List<RoomFeature>();
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
    
    
    

    public void SaveRoom()
    {
        string filename = FixRoomPath(name);

        if (!Directory.Exists("data"))
        {
            Directory.CreateDirectory("data");
        }

        if (!Directory.Exists("data/rooms"))
        {
            Directory.CreateDirectory("data/rooms");
        }

        string jsonString = JsonSerializer.Serialize(this);
        File.WriteAllText(filename, jsonString);
    }
    
    
}