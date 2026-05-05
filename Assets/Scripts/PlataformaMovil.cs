using System;
using System.Net;
using UnityEngine;
//visto en un video de youtube
public class PlataformaMovil : MonoBehaviour //sacado de video de youtube
{
    public GameObject objetoAmover;

    public Transform puntoInicial;
    public Transform puntoFinal;

    public float velocidad;

    private Vector3 direccion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direccion=puntoFinal.position;
    }

    // Update is called once per frame
    void Update()
    {
        objetoAmover.transform.position=Vector3.MoveTowards(objetoAmover.transform.position,direccion,velocidad*Time.deltaTime);

        if (objetoAmover.transform.position == puntoFinal.position)
        {
            direccion=puntoInicial.position;
            Girar();
        }
        if (objetoAmover.transform.position == puntoInicial.position)
        {
            direccion=puntoFinal.position;
            Girar();
        }

    }

    void Girar()
    {
        Vector3 escala = objetoAmover.transform.localScale;
        escala.x *= -1;
        objetoAmover.transform.localScale = escala;
    }
}
