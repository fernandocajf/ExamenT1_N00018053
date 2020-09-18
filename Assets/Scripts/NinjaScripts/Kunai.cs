using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    public float velocidad = 20;
    public Vector2 direccion;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movimiento = direccion.normalized * velocidad * Time.deltaTime;

        transform.Translate(movimiento);

    }
}
