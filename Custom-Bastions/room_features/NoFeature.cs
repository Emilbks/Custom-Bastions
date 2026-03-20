using CustomBastion;

public class NoFeature : RoomFeature
{
    public NoFeature(Room? room = null)
    {
        if (room != null) this.room = room; 
        shorthand = this.room.shorthand;
        textColor = ConsoleColor.DarkBlue;
    }

    public void SetRoom(Room room)
    {
        this.room = room;
        shorthand = room.shorthand;
    }

    override public void Print()
    {
        throw new NotImplementedException();
    }
}