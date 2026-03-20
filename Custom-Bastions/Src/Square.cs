using DefaultNamespace;

namespace CustomBastion;

public class Square : IPrintableInline
{
    //public bool supportsRoomAbove = false;
    protected bool built;
    protected Room room = new NoRoom();
    protected RoomFeature roomFeature = new NoFeature();
    public Square(bool built = false)
    {
        this.built = built;
    }

    public void PrintInline() { roomFeature.PrintInline(); } 
    public void BuildSquare() { built = true; }
}