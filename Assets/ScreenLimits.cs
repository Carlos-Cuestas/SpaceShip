using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limites : MonoBehaviour
{
    // Declaración de variables privadas
    private Rigidbody2D rb; // Referencia al componente Rigidbody2D del objeto
    private Vector2 screenBounds; // Límites de la pantalla en coordenadas del mundo
    private float playerWidth; // Ancho del sprite del jugador
    private float playerHeight; // Altura del sprite del jugador

    void Start()
    {
        // Inicialización de las variables
        rb = GetComponent<Rigidbody2D>(); // Obtiene el componente Rigidbody2D adjunto al objeto
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; // Obtiene la mitad del ancho del sprite del jugador
        playerHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; // Obtiene la mitad de la altura del sprite del jugador
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z)); // Convierte los límites de la pantalla en coordenadas del mundo
    }

    void Update()
    {
        // Mantiene al jugador dentro de los límites de la pantalla
        Vector3 viewPos = transform.position; // Obtiene la posición actual del objeto
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x + playerWidth, screenBounds.x - playerWidth); // Restringe la posición en el eje x para que no salga de los límites de la pantalla
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y + playerHeight, screenBounds.y - playerHeight); // Restringe la posición en el eje y para que no salga de los límites de la pantalla
        transform.position = viewPos; // Actualiza la posición del objeto
    }
}
