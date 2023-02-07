using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30f;
    private float forwardInput;
    private Rigidbody _rigidbody; //empuje, ***

    private GameObject focalPoint; //asignar el focal point
    
    private float powerupForce = 15f;
    public bool hasPowerup;//comprobar si lo ha tocado o no (on/off)
    
    public GameObject[] powerupIndicators;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>(); //asignar variable ***
        focalPoint = GameObject.Find("Focal_Point");  //asignar
    }

    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical"); //dirección del empuje que damos
        /*_rigidbody.AddForce(Vector3.forward * speed * forwardInput); //el empuje y su velocidad */

        _rigidbody.AddForce(focalPoint.transform.forward * speed * forwardInput); //adceder a las propiedades(+coorde locales)
    }

    private void OnTriggerEnter(Collider other)//trigger qu al chocar desaparezca
    {
        if (other.gameObject.CompareTag("PowerUp")) //
        {
            hasPowerup = true; //se activa
            Destroy(other.gameObject);

            StartCoroutine(PowerupCountDown());
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup) //lo repele
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =(other.gameObject.transform.position - transform.position).normalized; //que la distancia sea 1
            enemyRigidbody.AddForce(awayFromPlayer * powerupForce, ForceMode.Impulse);
        }
    }
    private IEnumerator PowerupCountDown() //IE = interface/ es una corrutina
    {
        //yield return new WaitForSeconds(6); //yield =esperar y devuelve 6s
        for (int i = 0; i < powerupIndicators.Length; i++)
        {
            powerupIndicators[i].SetActive(true); //activa el 1r elemento, pasan 2 segundos desactiva, despues el 2 y 3 y luego se va desvanece
            yield return new WaitForSeconds(2);
            powerupIndicators[i].SetActive(false);
            hasPowerup = false;
        }


    }
}
