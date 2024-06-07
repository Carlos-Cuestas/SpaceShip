using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la posición del ratón en el mundo
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.transform.position.z; // Ajustar la Z para que coincida con la cámara

        // Convertir la posición del ratón a coordenadas del mundo
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePos);

        // Calcular la dirección del puntero con respecto al jugador
        Vector3 direction = target - transform.position;

        // Calcular el ángulo de rotación en radianes
        float angle = Mathf.Atan2(direction.y, direction.x);

        // Convertir el ángulo de radianes a grados y ajustar para que el vértice apunte al puntero
        float angleDegrees = angle * Mathf.Rad2Deg - 90f; // Restar 90 grados para alinear la esquina superior del triángulo

        // Rotar el jugador en el eje Z hacia el ángulo calculado
        transform.rotation = Quaternion.Euler(0f, 0f, angleDegrees);

    }
}
