using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MapGuideBLL : MonoBehaviour
{
    [SerializeField] private GameObject _mapGuideObject;
    private Light2D _mapLight2D;

    private float _originalIntensity;
    private float _targetIntensity = 0.1f;  // La intensidad objetivo cuando la luz está apagada
    private float _duration = 1.0f;  // Duración de la transición
    private float _interval = 10.0f;  // Intervalo entre cada parpadeo

    void Start()
    {
        _mapLight2D = _mapGuideObject.GetComponent<Light2D>();
        if (_mapLight2D != null)
        {
            _originalIntensity = _mapLight2D.intensity;
            StartCoroutine(BlinkLight());
        }
        else
        {
            Debug.LogError("No se encontró el componente Light2D en el objeto asignado.");
        }
    }

    IEnumerator BlinkLight()
    {
        while (true)
        {
            // Reducir la intensidad de la luz gradualmente
            float elapsedTime = 0.0f;
            while (elapsedTime < _duration)
            {
                _mapLight2D.intensity = Mathf.Lerp(_originalIntensity, _targetIntensity, elapsedTime / _duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            _mapLight2D.intensity = _targetIntensity;

            // Esperar un breve momento antes de aumentar la intensidad de nuevo
            yield return new WaitForSeconds(0.5f);

            // Aumentar la intensidad de la luz gradualmente
            elapsedTime = 0.0f;
            while (elapsedTime < _duration)
            {
                _mapLight2D.intensity = Mathf.Lerp(_targetIntensity, _originalIntensity, elapsedTime / _duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            _mapLight2D.intensity = _originalIntensity;

            // Esperar el intervalo antes de repetir
            yield return new WaitForSeconds(_interval);
        }
    }
}
