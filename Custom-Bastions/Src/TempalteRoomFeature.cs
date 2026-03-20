using CustomBastion;
using static CustomBastion.Shortcuts;
namespace CustomBastions;

public class TempalteRoomFeature : RoomFeature
{
    public TempalteRoomFeature(Room room, string featureName, string shorthand, string description, string effects, string perks, int squareCost, int gpCost, int turnsToBuild, string requirements, int minLevel, int hirelingsAdded, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black) : base(room, featureName, shorthand, description, effects, perks, squareCost, gpCost, turnsToBuild, requirements, minLevel, hirelingsAdded, textColor, backgroundColor)
    {
    }

    public override void Print()
    {
        throw new NotImplementedException();
    }
     public override void EditFeature()
    {
        while (true)
        {
            Console.WriteLine("\nAt feature editor for: "+name+", enter a command (type 'help' for a list of commands):");
            switch (ReadInput().ToLower().Trim())
            {
                case "exit" or "close" or "quit" or "c" or "q" or "x":
                    return;
                case "edit name":
                    Console.WriteLine("Enter a new name for the feature:");
                    name = ReadInput();
                    break;
                case "edit shorthand":
                    Console.WriteLine("Enter a new shorthand for the feature:");
                    shorthand = ReadInput();
                    break;
                case "edit description":
                    Console.WriteLine("Enter a new description for the feature:");
                    description = ReadInput();
                    break;
                case "edit perks":
                    Console.WriteLine("Enter a new perks for the feature:");
                    perks = ReadInput();
                    break;
                case "edit square cost":
                    Console.WriteLine("Enter a new square cost for the feature:");
                    squareCost = ReadInt();
                    break;
                case "edit gp cost":
                    Console.WriteLine("Enter a new gp cost for the feature:");
                    GPCost = ReadInt();
                    break;
                case "edit turns to build":
                    Console.WriteLine("Enter a new turns to build for the feature:");
                    turnsToBuild = ReadInt();
                    break;
                case "edit requirements":
                    Console.WriteLine("Enter a new requirements for the feature:");
                    requirements = ReadInput();
                    break;
                case "edit min level":
                    Console.WriteLine("Enter a new min level for the feature:");
                    minLevel = ReadInt();
                    break;
                case "edit hirelings added":
                    Console.WriteLine("Enter a new hirelings added for the feature:");
                    hirelingsAdded = ReadInt();
                    break;
                case "help" or "h":
                default:
                    HelpFeatureEditor();
                    break;
            }
        }
    }
    
    public void HelpFeatureEditor()
    {
        Console.WriteLine("To save use the save command in the room editor.");
        Console.WriteLine("Available commands:");
        Console.WriteLine("'exit' or 'close' or 'quit' or 'c' or 'q' or 'x' - Exit the feature editor and save changes.");
        Console.WriteLine("'edit name' - Edit the name of the feature.");
        Console.WriteLine("'edit shorthand' - Edit the shorthand of the feature.");
        Console.WriteLine("'edit description' - Edit the description of the feature.");
        Console.WriteLine("'edit perks' - Edit the perks of the feature.");
        Console.WriteLine("'edit square cost' - Edit the square cost of the feature.");
        Console.WriteLine("'edit gp cost' - Edit the gp cost of the feature.");
        Console.WriteLine("'edit turns to build' - Edit the turns to build of the feature.");
        Console.WriteLine("'edit requirements' - Edit the requirements of the feature.");
        Console.WriteLine("'edit min level' - Edit the min level of the feature.");
        Console.WriteLine("'edit hirelings added' - Edit the hirelings added of the feature.");
    }
}