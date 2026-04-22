using UnityEngine;

public class BotonControles : MonoBehaviour
{
    public GameObject cartelControl;
    public GameObject botonControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void VerCartel()
    {
        cartelControl.SetActive(true);
        botonControl.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
