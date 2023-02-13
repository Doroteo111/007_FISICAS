using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed=1f;
    private float yMin = -2;
    private Rigidbody _rigidbody;
    private GameObject player;

    private void Awake() //es como start, pero para cosas propias
    {
        _rigidbody = GetComponent<Rigidbody>(); //asignación de las variables
    }
    private void Start()
    {
       
        player = GameObject.Find("Player");
    }

    void Update()
    {
        //calculo dirección  enemigo persigue al player, coge dos puntos y dibuja una línea

        Vector3 direction = (player.transform.position - transform.position).normalized;  
        _rigidbody.AddForce(direction * speed); //aplicas un empuje/fuerza en direccion  al player a la misma velocidad

        if (transform.position.y < yMin) //si el enemigo cae (al tirarlo)
        {
            Destroy(gameObject);
        }

    }
}
