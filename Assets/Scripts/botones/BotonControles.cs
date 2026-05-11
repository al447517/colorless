using UnityEngine;

public class BotonControles : MonoBehaviour
{
    public GameObject cartelControl;
    public GameObject botonControl;
    public GameObject botonPlay;
    public GameObject botonExit;
    public GameObject botonControles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void VerCartel()
    {
        cartelControl.SetActive(true);
        botonControl.SetActive(true);
        botonPlay.SetActive(false);
        botonExit.SetActive(false);
        botonControles.SetActive(false);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
