using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseGround
{
    public enum MoveDirection { None, Left, Right, Up, Down };
    internal class Player
    {
        private string name;
        private int score;
        private int livesLeft;
        private static int noOfObjects; 
        public static int NoOfObjs { get { return noOfObjects; } private set { noOfObjects = value; } }
//        private int Score1;
        public int Score1
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                if (score < 0)
                {
                    score = 0;
                }
            }
        }

        public Player() 
        {
        }

        public Player(string name)
        {
            noOfObjects++;
            this.name = name;
        }

        public Player(string name, int startingLives)
        {
            noOfObjects++;
            this.name = name;
            this.livesLeft = startingLives;
        }

        //public static int GetNoOfObject()
        //{
          //  return noOfObjects;
        //}

        public string GetName()
        {
            return this.name;
        }

        public int GetScore()
        {
            return this.score;
        }

        public void AddPoints(int addPoints)
        {
            this.score += addPoints;
        }

        public void Kill()
        {
            // We make sure they can't get negative lives.
            if (this.livesLeft > 0)
            {
                this.livesLeft--;
            }
        }
        public int GetLivesLeft()
        {
            return livesLeft;
        }

        public virtual MoveDirection MakeMove()
        {
            return MoveDirection.Left;
        }
    }

}
