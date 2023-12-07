namespace RoboMove
{
    public enum Direction
    {
        NORTH,
        EAST,
        SOUTH,
        WEST
    }

    public class ToyRobot: IToyRobot
    {
        private int x;
        private int y;
        private Direction direction;
        private bool isPlaced;

        public void Place(int x, int y, Direction direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
            isPlaced = true;
        }

        public void Move()
        {
            if (isPlaced)
            {
                switch (direction)
                {
                    case Direction.NORTH:
                        if (y < 4) y++;
                        break;
                    case Direction.EAST:
                        if (x < 4) x++;
                        break;
                    case Direction.SOUTH:
                        if (y > 0) y--;
                        break;
                    case Direction.WEST:
                        if (x > 0) x--;
                        break;
                }
            }
        }

        public void TurnLeft()
        {
            if (isPlaced)
            {
                direction = (Direction)(((int)direction + 3) % 4);
            }
        }

        public void TurnRight()
        {
            if (isPlaced)
            {
                direction = (Direction)(((int)direction + 1) % 4);
            }
        }

        public string Report()
        {
            if (isPlaced)
            {
                return $"{x},{y},{direction}";
            }
            else
            {
                return "Robot not placed on the table.";
            }
        }

    }
}
