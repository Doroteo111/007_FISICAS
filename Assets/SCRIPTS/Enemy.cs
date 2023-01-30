using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody _rigidbody;
    private GameObject player;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); //asignación de las variables
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;  
        //el enemigo persigue al player, coge dos puntos y dibuja una línea
        _rigidbody.AddForce(direction * speed); //aplicas un empuje en direccion  al player
        
    }
}
