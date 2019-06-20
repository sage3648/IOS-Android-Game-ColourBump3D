using System;
using System.Security.Policy;
using Boo.Lang.Environments;
using Assets.Scripts;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObstaclePattern
    {
      
        public enum Alignment
        {
            Arrow, Circle, Wall, Diamond
        }

        public enum ObstacleType
        {
            Blocks,Cylinders,Diamonds
        }
        public ObstaclePattern()
        {
            float obstacleCount;     
        }

        public Vector3[] CreateObstaclesPattern(Alignment alignment)
        {
            switch (alignment)
            {
                case Alignment.Arrow:
                    Vector3[] positions = new Vector3[50];
                    foreach (Vector3 position in positions)
                    {
                        
                    }
    
                    break; 
                case Alignment.Circle:
                    break; 
                case Alignment.Diamond:
                    break; 
                
                    
            }

            return null; 
        }
        
    }
}