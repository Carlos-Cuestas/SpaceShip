using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;

    public float intervaloEntreDisparos = 1f; // Intervalo de tiempo entre cada disparo
    bool disparando = false; // Variable para controlar si se está disparando actualmente

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

        if (Input.GetButtonDown("Fire1") && !disparando) // Verifica si se presionó el botón y no se está disparando actualmente
    {
        disparando = true; // Indica que se está iniciando el proceso de disparo
        InvokeRepeating("Shoot", 0f, intervaloEntreDisparos*0.01f); // Comienza a llamar a la función Shoot() repetidamente con el intervalo dado
    }
    }

    void Shoot()
{
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 direction = (mousePosition - transform.position).normalized;

    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    rb.velocity = direction * bulletSpeed;

    // Detiene la repetición de disparo si ya no se está presionando el botón
    if (!Input.GetButton("Fire1")) 
    {
        CancelInvoke("Shoot");
        disparando = false; // Restablece el estado de disparando
    }
}
}
