namespace CustomBastion;

public abstract class RoomFeature : IPrintable, IPrintableInline
{
    protected Room room;
    
    protected string name;
    protected string shorthand;
    protected string description;
    protected string perks;
    
    //Cost for feature
    protected int squareCost;
    protected int GPCost;
    protected int turnsToBuild;
    protected string requirements;
    protected int minLevel;
    protected int hirelingsAdded;
    private ConsoleColor textColor;
    private ConsoleColor backgroundColor;

    public RoomFeature(Room room, string featureName, string shorthand, string description, string effects, string perks, int squareCost, int gpCost, 
        int turnsToBuild, string requirements, int minLevel, int hirelingsAdded, ConsoleColor textColor = ConsoleColor.White,
        ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        this.room = room;
        name = featureName;
        this.shorthand = shorthand;
        this.description = description;
        this.perks = perks;
        this.textColor = textColor;
        this.backgroundColor = backgroundColor;
        this.squareCost = squareCost;
        GPCost = gpCost;
        this.turnsToBuild = turnsToBuild;
        this.requirements = requirements;
        this.minLevel = minLevel;
        this.hirelingsAdded = hirelingsAdded;
    }

    public string GetName() { return name; }
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

    public abstract void EditFeature();
   
}