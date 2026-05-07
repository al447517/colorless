using System;
using System.Net;
using UnityEngine;
//visto en un video de youtube
public class PlataformaMovil : MonoBehaviour 
{
    public GameObject objetoAmover;

    public Transform puntoInicial;
    public Transform puntoFinal;

    private float velocidad= 4f;

    private bool direccionderecha;

    public Vector2 velocidadPlataforma;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direccionderecha=true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (direccionderecha)
        {
            velocidadPlataforma = new Vector2(velocidad, 0);
            rb.linearVelocity = velocidadPlataforma;
            if (transform.position.x >= puntoFinal.position.x)
            {
                Girar();
                direccionderecha=false;
            }
        }
        else 
        {
            velocidadPlataforma = new Vector2(-velocidad, 0);
            rb.linearVelocity = velocidadPlataforma;
            if (transform.position.x <= puntoInicial.position.x)
            {
                Girar();
                direccionderecha=true;
            }
        }

    }


    void Girar()
    {
        Vector3 escala = objetoAmover.transform.localScale;
        escala.x *= -1;
        objetoAmover.transform.localScale = escala;
    }
}
