namespace MarsRover
{
    public class Plateau : IPlateau
    {
        public int width { get; set; }
        public int height { get; set; }

        public Plateau(int width,int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
