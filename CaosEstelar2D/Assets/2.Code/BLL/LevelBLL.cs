using BLL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBLL : MonoBehaviour
{
    #region Properties

    [SerializeField] private TimerBLL _timerBLL;
    [SerializeField] private ConstellationBLL _constellationBLL;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private float _secondsPlayerOutsideBoundaries;
    [SerializeField] private string _levelName;
    [SerializeField] private float _secondsWaitChangeScene;
    private Scene _currentScene;
    #endregion
    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
    }

    private void FixedUpdate()
    {
        CheckForLevelResetConditions();
    }
    #region Methods
    private void CheckForLevelResetConditions()
    {
        if (IsTimerFinished() || IsPlayerOutsideBoundaries())
        {
            ResetLevel();
        }
    }

    private bool IsTimerFinished()
    {
        return _timerBLL.TimerEnded();
    }

    private bool IsPlayerOutsideBoundaries()
    {
        Vector3 playerViewportPosition = _camera.WorldToViewportPoint(_player.position);
        return playerViewportPosition.y < 0 || playerViewportPosition.x < 0 || playerViewportPosition.x > 1;
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(_currentScene.name);
    }

    public void LevelCompleted()
    {
        if (_constellationBLL.IsConstellationCompleted())
        {
            StartCoroutine(WaitAndChangeScene());
        }
    }

    private IEnumerator WaitAndChangeScene()
    {
        yield return new WaitForSeconds(_secondsWaitChangeScene);
        SceneManager.LoadScene(_levelName);
    }

    #endregion
}
