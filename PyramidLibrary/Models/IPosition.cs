namespace PyramidLibrary.Models
{
    public interface IPosition
    {
        Card? Card { get; set; }
        (int?, int?) Id { get; set; }
    }
}