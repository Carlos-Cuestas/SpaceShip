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
        
        //disparo
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
