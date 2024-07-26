using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BE;

namespace DAL
{
    public class ScoreDAL
    {
        public ScoreDAL()
        {
        }

        public void GuardarTotalScore(int score)
        {
            PlayerPrefs.SetInt("TotalScore", score);
            PlayerPrefs.Save();
        }

        public int ObtenerTotalScore()
        {
            return PlayerPrefs.HasKey("TotalScore") ? PlayerPrefs.GetInt("TotalScore") : 0;
        }

      
    }
}
