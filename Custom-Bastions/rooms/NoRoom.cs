using CustomBastion;

public class NoRoom : Room
{
    public NoRoom()
    {
        shorthand = "Emp";
    }

    public override void Print()
    {
        throw new NotImplementedException();
    }
}