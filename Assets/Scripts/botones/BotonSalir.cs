using UnityEngine;

public class BotonSalir : MonoBehaviour
{
    public GameObject cartelControl;
    public GameObject botonControl;
    public GameObject botonPlay;
    public GameObject botonExit;
    public GameObject botonControles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void cerrarVentana()
    {
        cartelControl.SetActive(false);
        botonControl.SetActive(false);
        botonPlay.SetActive(true);
        botonExit.SetActive(true);
        botonControles.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
