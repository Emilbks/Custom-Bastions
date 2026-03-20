using DefaultNamespace;
using System.IO.Enumeration;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks.Dataflow;
using static CustomBastion.Shortcuts;

namespace CustomBastion;

public class Bastion
{   
    public List<Room> Rooms;
    public string name { get; set;}
    /// <summary>
    /// 3D array of strings representing the layout of the bastion. The first dimension represents the floor, the second dimension represents the x-axis, and the third dimension represents the y-axis. Each string in the array represents a room or an empty space. The string can be used to identify the type of room or to store additional information about the room.
    /// </summary>
    public Square[,,] layout;
    public int[] xUpperBounds = new int[1];
    public int[] xLowerBounds = new int[1];
    public int[] yUpperBounds = new int[1];
    public int[] yLowerBounds = new int[1];
    public int HirelingAmount;
    public int tileAmount;
    public int playerLevel;
    public int groundFloor = 0;
    public PriceCalculator pc;

    public Bastion()
    {
        name = "Unnamed Bastion";
        playerLevel = 1;
        tileAmount = 0;
        Rooms = new List<Room>();
        pc = new PriceCalculator("1+1", this); // Needs fixing
        layout = new Square[1, 10, 10];

        for (int i = 0; i < layout.GetLength(0); i++)
        {
            for (int j = 0; j < layout.GetLength(1); j++)
            {
                for (int k = 0; k < layout.GetLength(2); k++)
                {
                    layout[i, j, k] = new Square();
                }
            }
        }

        //TODO: Something with initial size
        xLowerBounds[0] = 3;
        xUpperBounds[0] = 7;
        yLowerBounds[0] = 3;
        yUpperBounds[0] = 6;
    }

    public void ChangeFunction(string newfunc)
    {
        pc.ChangeExperssion(newfunc);
    }
    
    
    public void ChangePlayerLevel(int level)
    {
        playerLevel = level;
        pc.ChangeParam("l", playerLevel);
    }
    public void ChangeTileAmount(int amount)
    {
        tileAmount = amount;
        pc.ChangeParam("ta", tileAmount);
    }

    public void GetTilePrice()
    {
        pc.eval();
    }
    
    public void DisplayBastionFloor(int f)
    {
        
        Console.Write("    +");
        for (int i = 0; i <= xUpperBounds[f] - xLowerBounds[f]; i++)
        {
            Console.Write("---+");
        }
        Console.Write("\r\n");

        for (int i = yUpperBounds[f]; i >= yLowerBounds[f]; i--)
        {
            Console.Write($"{i.ToString().PadLeft(3, '0')} |");
            for (int j = 0; j <= xUpperBounds[f] - xLowerBounds[f]; j++)
            {
                layout[f, i, j].PrintInline();
                Console.Write("|");
            }
            Console.Write("\r\n");
            
            Console.Write($"    +");
            for (int j = 0; j <= xUpperBounds[f] - xLowerBounds[f]; j++)
            {
                Console.Write("---+");
            }
            Console.Write("\r\n");
            
        }

        Console.Write("    |");
        for (int i = 0; i <= xUpperBounds[f] - xLowerBounds[f]; i++)
        {
            Console.Write($"{(xLowerBounds[f] + i).ToString().PadLeft(3, '0')}|");
        }
        Console.Write("\r\n");
    }

    /// <summary>
    /// Adds a new floor to the bastion. If basement is true, the new floor will be added below the ground floor, otherwise it will be added above as the top floor. The layout of the bastion is updated accordingly, and the groundFloor variable is updated if a basement floor is added. The new floor will be initialized with empty squares.
    /// </summary>
    /// <param name="basement"></param>
    public void AddFloor(bool basement = false)
    {
        Square[,,] newLayout = new Square[layout.GetLength(0) + 1, layout.GetLength(1), layout.GetLength(2)];
        for (int i = 0; i < layout.GetLength(0); i++)
        {
            for (int j = 0; j < layout.GetLength(1); j++)
            {
                for (int k = 0; k < layout.GetLength(2); k++)
                {
                    newLayout[i + (basement ? 1 : 0), j, k] = layout[i, j, k];
                }
            }
        }
        layout = newLayout;
        groundFloor += basement ? 1 : 0;
    }

    /// <summary>
    /// Removes a floor from either end of the bastion, with the top as default. Only works if there is more than one floor. More work has to be done to update the rooms according to the removed floor.
    /// </summary>
    /// <param name="basement">Boolean indicating whether to remove a basement floor if there is one.</param>
    public void RemoveFloor(bool basement = false)
    {
        if (layout.GetLength(0) <= 1)
        {
            Console.WriteLine("Cannot remove floor, only one floor left.");
            return;
        }
        if (basement && groundFloor <= 0)
        {
            Console.WriteLine("Cannot remove basement floor, no basement floor exists.");
            return;
        }
        Square[,,] newLayout = new Square[layout.GetLength(0) - 1, layout.GetLength(1), layout.GetLength(2)];
        for (int i = 0; i < newLayout.GetLength(0); i++)
        {
            for (int j = 0; j < newLayout.GetLength(1); j++)
            {
                for (int k = 0; k < newLayout.GetLength(2); k++)
                {
                    newLayout[i, j, k] = layout[i + (basement ? 1 : 0), j, k];
                }
            }
        }
        layout = newLayout;
        groundFloor -= basement ? 1 : 0;

        //TODO: update rooms accordng to squares removed
    }

    /// <summary>
    /// Expands the bastion in the positive x direction by adding 5 columns of empty squares to the layout. The new columns are added to the right side of the layout, and the existing squares are shifted accordingly. The xUpperBounds array is updated to reflect the new upper bound of the x-axis.
    /// </summary>
    public void ExpandXUp()
    {
        Square[,,] newLayout = new Square[layout.GetLength(0), layout.GetLength(1) + 5, layout.GetLength(2)];
        for (int i = 0; i < layout.GetLength(0); i++)
        {
            for (int j = 0; j < layout.GetLength(1); j++)
            {
                for (int k = 0; k < layout.GetLength(2); k++)
                {
                    newLayout[i, j, k] = layout[i, j, k];
                }
            }
        }
        layout = newLayout;
    }

    public void ExpandXDown()
    {
        Square[,,] newLayout = new Square[layout.GetLength(0), layout.GetLength(1) + 5, layout.GetLength(2)];
        for (int i = 0; i < layout.GetLength(0); i++)
        {
            for (int j = 0; j < layout.GetLength(1); j++)
            {
                for (int k = 0; k < layout.GetLength(2); k++)
                {
                    newLayout[i, j + 5, k] = layout[i, j, k];
                }
            }
        }
        layout = newLayout;
        for (int i = 0; i < xUpperBounds.Length; i++)
        {
            xUpperBounds[i] += 5;
            xLowerBounds[i] += 5;
        }
    }

    public void ExpandYUp()
    {
        Square[,,] newLayout = new Square[layout.GetLength(0), layout.GetLength(1) + 5, layout.GetLength(2)];
        for (int i = 0; i < layout.GetLength(0); i++)
        {
            for (int j = 0; j < layout.GetLength(1); j++)
            {
                for (int k = 0; k < layout.GetLength(2); k++)
                {
                    newLayout[i, j, k] = layout[i, j, k];
                }
            }
        }
        layout = newLayout;
    }

    public void ExpandYDown()
    {
        Square[,,] newLayout = new Square[layout.GetLength(0), layout.GetLength(1) + 5, layout.GetLength(2)];
        for (int i = 0; i < layout.GetLength(0); i++)
        {
            for (int j = 0; j < layout.GetLength(1); j++)
            {
                for (int k = 0; k < layout.GetLength(2); k++)
                {
                    newLayout[i, j, k + 5] = layout[i, j, k];
                }
            }
        }
        layout = newLayout;
        for (int i = 0; i < yUpperBounds.Length; i++)
        {
            yUpperBounds[i] += 5;
            yLowerBounds[i] += 5;
        }
    }

    public void SaveBastion()
    {
        while (name == "Unnamed Bastion")
        {
            Console.WriteLine("Enter a name for the bastion (entering an existing name will overwrite that bastion):");
            name = string.Join("_", ReadInput().Trim().Split());
            if (name.Length == 0) name = "Unnamed Bastion";
        }

        string filename = FixBastionPath(name);

        if (!Directory.Exists("data"))
        {
            Directory.CreateDirectory("data");
        }

        if (!Directory.Exists("data/bastions"))
        {
            Directory.CreateDirectory("data/bastions");
        }

        string jsonString = JsonSerializer.Serialize(this);
        File.WriteAllText(filename, jsonString);

        File.WriteAllText("data/PresviousBastionPath.txt", filename);
    }
}