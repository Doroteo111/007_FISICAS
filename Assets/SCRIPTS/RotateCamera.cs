using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private float rotationSpeed= 35f;
    private float horizontalInput; //valor por codigo

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); //detectar (input) interaccion del player
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * horizontalInput); //rotatra a partir de ese input
    }
}
