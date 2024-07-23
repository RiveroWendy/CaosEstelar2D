using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BE;

namespace BLL
{
    public class ScoreBLL : MonoBehaviour
    {
        //private ScoreBE _scoreBE;
        //private TimerBE _timerBE;

        private ScoreBE _scoreBE;

        public ScoreBE ScoreBE
        {
            get { return _scoreBE; }
            set { _scoreBE = value; }
        }

        private TimerBE _timerBE;

        public TimerBE TimerBE
        {
            get { return _timerBE; }
            set { _timerBE = value; }
        }


        public void CalculateScore()
        {

        }

        public void ShowScore()
        {

        }
    }
}