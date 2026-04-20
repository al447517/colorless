using UnityEngine;

public class BotonSalir : MonoBehaviour
{
    public GameObject cartelControl;
    public GameObject botonControl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void cerrarVentana()
    {
        cartelControl.SetActive(false);
        botonControl.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
