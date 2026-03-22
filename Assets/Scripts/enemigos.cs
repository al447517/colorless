using UnityEngine;
 

public class enemigos : MonoBehaviour
{
    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public int contador=0;
        void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.CompareTag("Player")) 
        {
            
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
