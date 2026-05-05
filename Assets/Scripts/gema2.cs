using UnityEngine;
using UnityEngine.SceneManagement;

public class gema2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene("HasGanado");
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
