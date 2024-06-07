using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreTextTMP; // Referencia al texto de TextMeshPro
    private float score; // Puntaje actual

    void Start()
    {
        score = 0f; // Inicializa el puntaje a 0
    }

    void Update()
    {
        score += 2f * Time.deltaTime; // Incrementa el puntaje en 2 puntos por segundo
        scoreTextTMP.text = "Score: " + Mathf.FloorToInt(score); // Actualiza el texto de TextMeshPro
    }
}
