using UnityEngine;


namespace BE
{
    public class TimerBE
    {
        private float _totalTime = 30f;

        public float TotalTime
        {
            get { return _totalTime; }
            set { _totalTime = value; }
        }

        private float _currentTime;

        public float CurrentTime
        {
            get { return _currentTime; }
            set { _currentTime = value; }
        }

        private bool _isTimerFinished = false;

        public bool IsTimerFinished
        {
            get { return _isTimerFinished; }
            set { _isTimerFinished = value; }
        }

        public TimerBE()
        {
            
        }
    }
}