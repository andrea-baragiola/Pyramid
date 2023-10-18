namespace PyramidLibrary.Models
{
    public interface IPosition
    {
        Card? Card { get; set; }
        (string?, int?) Id { get; set; }
    }
}