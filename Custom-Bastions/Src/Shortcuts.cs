namespace CustomBastion;

public static class Shortcuts
{
    /// <summary>
    /// Reads input from the console and returns it as a string.
    /// This is used to read input from the console in a safe way.
    /// </summary>
    /// <returns>A null value will be returned as "null" to avoid errors.</returns>
    public static string ReadInput() { return Console.ReadLine() ?? "null";}

    /// <summary>
    /// Reads input from the console and returns it as an integer.
    /// </summary>
    /// <returns>The integer value of the input, or 0 if the input is null.</returns>
    public static int ReadInt() { return Convert.ToInt32(Console.ReadLine() ?? "0"); }

    public static string FixBastionPath(string path)
    {
        if (!path.StartsWith("data/bastions/"))
        {
            path = "data/bastions/" + path;
        }

        if (!path.EndsWith(".json"))
        {
            path += ".json";
        }

        return path;
    }
    
    public static string FixRoomPath(string path)
    {
        if (!path.StartsWith("data/rooms/"))
        {
            path = "data/rooms/" + path;
        }

        if (!path.EndsWith(".json"))
        {
            path += ".json";
        }

        return path;
    }
}