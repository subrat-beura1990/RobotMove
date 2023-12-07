using System;
using System.Collections.Generic;
using System.Text;

namespace RoboMove
{
    interface IToyRobot
    {
        public void Place(int x, int y, Direction direction);
        public void Move();
        public void TurnLeft();
        public void TurnRight();
        public string Report();
    }
}
