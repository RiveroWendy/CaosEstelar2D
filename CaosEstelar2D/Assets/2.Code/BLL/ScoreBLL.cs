using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BE;
using TMPro;
using DAL;
using UnityEngine.SceneManagement;

namespace BLL
{
    public class ScoreBLL : MonoBehaviour
    {
        #region Properties
        private ScoreBE _scoreBE;

        public ScoreBE ScoreBE
        {
            get { return _scoreBE; }
            set { _scoreBE = value; }
        }

        private TimerBLL _timerBLL;

        [SerializeField]
        private TextMeshProUGUI _textLevelScore;
        [SerializeField]
        private TextMeshProUGUI _textTotalScore;
        private ScoreDAL _scoreDAL;
        #endregion
        private void Start()
        {
            _scoreBE = new ScoreBE();
            _scoreDAL = new ScoreDAL();
            _timerBLL = FindObjectOfType<TimerBLL>();


            // Reiniciar el puntaje total si estamos en el nivel 1
            if (SceneManager.GetActiveScene().name == "Level 1")
            {
                ResetTotalScore();
            }
            else
            {
                LoadTotalScore();
            }

            if (SceneManager.GetActiveScene().name == "Final Scene")
            {
                ShowTotalScore();
            }
        }
        #region Methods
        public void CalculateScore()
        {
            if (_timerBLL != null)
            {
                float remainingTime = _timerBLL.GetRemainingTime();
                _scoreBE.LevelScore = (int)(remainingTime * 10);
                _scoreBE.TotalScore += _scoreBE.LevelScore;
                ShowScore();
                SaveScore();
            }
        }

        public void ShowScore()
        {
            _textLevelScore.text = _scoreBE.LevelScore.ToString();
            // No actualizamos el total score aquí para evitar mostrarlo antes de tiempo
        }

        private void ShowTotalScore()
        {
            _textTotalScore.text = _scoreBE.TotalScore.ToString();
        }

        private void SaveScore()
        {
            Debug.Log("Score Guardado: " + _scoreBE.TotalScore);
            _scoreDAL.GuardarTotalScore(_scoreBE.TotalScore);
        }

        private void LoadTotalScore()
        {
            _scoreBE.TotalScore = _scoreDAL.ObtenerTotalScore();
            Debug.Log("Total Score Loaded: " + _scoreBE.TotalScore);
        }

        private void ResetTotalScore()
        {
            _scoreBE.TotalScore = 0;
            _scoreDAL.GuardarTotalScore(_scoreBE.TotalScore);
            Debug.Log("Total Score Reset to 0");
        }
    }
    #endregion
}
