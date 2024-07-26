using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BE;
using TMPro;

namespace BLL
{
    public class ScoreBLL : MonoBehaviour
    {
        private ScoreBE _scoreBE;

        public ScoreBE ScoreBE
        {
            get { return _scoreBE; }
            set { _scoreBE = value; }
        }

        private TimerBLL _timerBLL;

        [SerializeField]
        private TextMeshProUGUI _textScore;

        private void Start()
        {
            _scoreBE = new ScoreBE();
            _timerBLL = FindObjectOfType<TimerBLL>();
        }

        public void CalculateScore()
        {
            if (_timerBLL != null)
            {
                float remainingTime = _timerBLL.GetRemainingTime();
                _scoreBE.LevelScore = (int)(remainingTime * 10); 
                ShowScore();
            }
        }

        public void ShowScore()
        {
            _textScore.text = _scoreBE.LevelScore.ToString();
        }
    }
}