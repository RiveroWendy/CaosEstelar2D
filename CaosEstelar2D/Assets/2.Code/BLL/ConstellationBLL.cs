using BE;
using System.Collections.Generic;
using UnityEngine;

namespace BLL
{
    public class ConstellationBLL : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _starOrder;

        public List<GameObject> StarOrder
        {
            get { return _starOrder; }
            set { _starOrder = value; }
        }

        private ConstellationBE _constellationBEObject;

        public ConstellationBE ConstellationBEObject
        {
            get { return _constellationBEObject; }
            set { _constellationBEObject = value; }
        }


        private void Awake()
        {
            _constellationBEObject = GetComponent<ConstellationBE>() ?? gameObject.AddComponent<ConstellationBE>();
            _constellationBEObject.Star = new StarBE(0); // Asegura que Star no sea nulo
        }

        public bool VerifySequence(GameObject touchedStar)
        {
            if (ConstellationBEObject == null || StarOrder == null)
            {
                Debug.LogError("ConstellationBE or StarOrder is not initialized");
                return false; // Retorna false si la inicialización falla
            }

            if (IsCorrectStar(touchedStar))
            {
                Debug.Log($"Correct star touched: {touchedStar.name}");
                ConstellationBEObject.CurrentIndex++;

                if (IsConstellationCompleted())
                {
                    ConstellationBEObject.ConstellationCompleted = true;
                    Debug.Log("Constellation completed!");
                    return true; // Retorna true si la constelación se completa
                }

                return true; // Retorna true si la estrella tocada es correcta pero la constelación no está completa
            }
            else
            {
                Debug.Log($"Wrong star touched: {touchedStar.name}");
                RestartSequence();
                return false; // Retorna false si la estrella tocada es incorrecta
            }
        }


        private bool IsCorrectStar(GameObject touchedStar)
        {
            return touchedStar == StarOrder[ConstellationBEObject.CurrentIndex];
        }

        public bool IsConstellationCompleted()
        {
            return ConstellationBEObject.CurrentIndex >= StarOrder.Count;
        }

        public void RestartSequence()
        {
            Debug.Log("Sequence restarted");
            ConstellationBEObject.CurrentIndex = 0;
            ConstellationBEObject.ConstellationCompleted = false;
            ResetStars();
        }

        private void ResetStars()
        {
            foreach (GameObject star in StarOrder)
            {
                ResetStar(star);
            }
        }

        private void ResetStar(GameObject star)
        {
            var starBLL = star.GetComponent<StarBLL>();
            if (starBLL != null && starBLL.StarBEObject != null)
            {
                starBLL.StarBEObject.IsTouched = false;
                starBLL.ResetColor();
            }
        }
    }
}
