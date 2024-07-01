using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public abstract class BaseConfig : MonoBehaviour
    {
        [SerializeField] protected Point PointPrefab;
        [SerializeField] protected LineRendererBetweenPoints LineRendererBetweenPoints;
        
        protected List<Point> Points = new List<Point>();
        
        public LineRendererBetweenPoints LineRendererBetween => LineRendererBetweenPoints;

        public virtual void Init()
        {
            
        }
        
        public virtual void ActiveAchigment()
        {
        
        }

        public virtual void Close()
        {
            
        }
    }
}