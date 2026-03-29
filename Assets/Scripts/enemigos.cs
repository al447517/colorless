using UnityEngine;

 

public class enemigos : MonoBehaviour
{
    //que desaparezca cuando ataque
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ataque"))
        {
            this.gameObject.SetActive(false);
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
