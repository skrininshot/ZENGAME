using UnityEngine;

namespace ZENGAME.Core
{
    public class Timer
    {
        private float _startTime;
        public void Start() => _startTime = Time.time;
        public float PassedTime => Time.time - _startTime;
    }
}