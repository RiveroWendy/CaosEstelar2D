using System.Collections;
using UnityEngine;
using TMPro;
using BE;

namespace BLL
{
    public class TimerBLL : MonoBehaviour
    {
        #region Properties
        private TimerBE _timerBEObject = new();

        [SerializeField]
        private TextMeshProUGUI _textMeshProTimer;

        [SerializeField]
        private ConstellationBLL _constellationBLLObject;

        private bool _isPaused = false;
        #endregion

        private void Start()
        {
            _timerBEObject.CurrentTime = _timerBEObject.TotalTime;
            StartCoroutine(UpdateTimerCoroutine());
        }

        private IEnumerator UpdateTimerCoroutine()
        {
            while (_timerBEObject.CurrentTime > 0)
            {
                if (!_timerBEObject.IsTimerFinished && !_isPaused)
                {
                    _timerBEObject.CurrentTime -= 1f;
                    ShowTimer();
                }

                if (_constellationBLLObject.IsConstellationCompleted())
                {
                    PauseTimer();
                }

                yield return new WaitForSeconds(1f); // Esperar 1 segundo
            }

            _timerBEObject.CurrentTime = 0;
            ShowTimer();
            _timerBEObject.IsTimerFinished = true;
        }

        public void ShowTimer()
        {
            _textMeshProTimer.text = _timerBEObject.CurrentTime.ToString("F0");
        }

        public bool TimerEnded()
        {
            return _timerBEObject.IsTimerFinished;
        }

        public void PauseTimer()
        {
            _isPaused = true;
        }

        public void ResumeTimer()
        {
            _isPaused = false;
        }
    }
}
