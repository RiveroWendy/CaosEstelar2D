using BLL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBLL : MonoBehaviour
{
    // Condiciones para reiniciar el nivel   
    // - Que termine el timer
    // - Que se salga del la pantalla

    [SerializeField] private TimerBLL _timerBLL;
    [SerializeField] private ConstellationBLL _constellationBLL;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private float _secondsPlayerOutsideBoundaries;

    private Scene _currentScene;

    private void Start()
    {
        _currentScene = SceneManager.GetActiveScene();
    }

    private void FixedUpdate()
    {
        CheckForLevelResetConditions();
    }

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
        // Implementar la lógica para completar el nivel
    }

    // Condiciones para pasar de nivel
    // - Que se complete la constelación
}
