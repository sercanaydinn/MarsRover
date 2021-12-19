namespace MarsRover
{
    public class Rover : IRover
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        public Direction direction { get; set; }
        public Plateau plateau { get; set; }

        public Rover(int xCoordinate, int yCoordinate, string direction, Plateau plateau)
        {
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
            this.direction = (Direction)Enum.Parse(typeof(Direction), direction);
            this.plateau = plateau;
        }

        public void RoverAction(string commands)
        {
            foreach (var command in commands)
            {
                switch ((Action)Enum.Parse(typeof(Action), command.ToString()))
                {
                    case Action.L:
                        RoverTurnLeft();
                        break;
                    case Action.M:
                        RoverMove();
                        break;
                    case Action.R:
                        RoverTurnRight();
                        break;
                    default:
                        break;
                }
            }
        }

        private void RoverTurnLeft()
        {
            this.direction = (this.direction - 1) < Direction.N ? Direction.W : this.direction - 1;
        }

        private void RoverTurnRight()
        {
            this.direction = (this.direction + 1) > Direction.W ? Direction.N : this.direction + 1;
        }

        private void RoverMove()
        {
            int roverXCoordinate = this.xCoordinate;
            int roverYCoordinate = this.yCoordinate;

            switch (this.direction)
            {
                case Direction.N:
                    roverYCoordinate++;
                    break;
                case Direction.S:
                    roverYCoordinate--;
                    break;
                case Direction.W:
                    roverXCoordinate--;
                    break;
                case Direction.E:
                    roverXCoordinate++;
                    break;
                default:
                    break;
            }

            if (RoverBorderControl(roverXCoordinate, roverYCoordinate))
            {
                this.xCoordinate = roverXCoordinate;
                this.yCoordinate = roverYCoordinate;
            }
        }

        private bool RoverBorderControl(int roverXCoordinate, int roverYCoordinate)
        {
            if (roverXCoordinate > this.plateau.width || roverXCoordinate < 0 || roverYCoordinate > this.plateau.height || roverYCoordinate < 0)
            {
                return false;
            }

            return true;
        }
    }
}
