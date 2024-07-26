using BLL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConstellationBLL : MonoBehaviour
{
    [SerializeField] private ConstellationBLL _constellationBLLObject;

    private LineRenderer _line;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
    }

    public void SetUpLine()
    {
        List<GameObject> starOrder = _constellationBLLObject.StarOrder;
        Transform[] starPoints = new Transform[starOrder.Count];

        for (int i = 0; i < starOrder.Count; i++)
        {
            starPoints[i] = starOrder[i].transform;
        }

        // Incrementamos el tamaño del arreglo para incluir el primer punto al final
        _line.positionCount = starPoints.Length + 1;

        Vector3[] positions = new Vector3[starPoints.Length + 1];
        for (int i = 0; i < starPoints.Length; i++)
        {
            positions[i] = starPoints[i].position;
        }
        // Añadimos el primer punto al final para cerrar la línea
        positions[starPoints.Length] = starPoints[0].position;

        // Inicialmente, la línea no tiene posiciones
        _line.positionCount = 0;

        // Iniciamos la corrutina para dibujar la línea progresivamente
        StartCoroutine(DrawLineProgressively(positions));
    }

    private IEnumerator DrawLineProgressively(Vector3[] positions)
    {
        for (int i = 0; i < positions.Length - 1; i++)
        {
            float progress = 0;
            while (progress <= 1)
            {
                _line.positionCount = i + 2;
                _line.SetPosition(i, positions[i]);
                _line.SetPosition(i + 1, Vector3.Lerp(positions[i], positions[i + 1], progress));
                progress += Time.deltaTime;
                yield return null;
            }
        }

        // Establecemos la última posición para cerrar la línea
        _line.SetPosition(positions.Length - 1, positions[positions.Length - 1]);
    }
}
