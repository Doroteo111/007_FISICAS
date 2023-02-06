using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bucle : MonoBehaviour
{
    public string[] names;

    public Vector3[] positions;
    public GameObject prefab;

    public int value = 9;
    void Start()
    {

        /*  //Multiplicacion
          for(int i=1; i<=10; i++)
          {
              Debug.Log($"10 x {i} = {i * 10}");
          }

          // Por array
          for (int i = 0; i < names.Length; i++)
          {
              Debug.Log(names[i]);
          }

          //instanciar elementos
          for (int i = 0; i < positions.Length; i++)
          {
              Instantiate(prefab, positions[i], Quaternion.identity);
          
        foreach (Vector3 p in positions)
        {
            Instantiate(prefab, p, Quaternion.identity);
        }
        */
       /* int i = 1;
        while (i < 10)
        {
            Debug.Log($"{i} x {value} = {value * i}");
            i++;
        }
       */
    }

    
}
