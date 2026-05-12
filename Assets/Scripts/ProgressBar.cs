using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;

    public Vector2 puntoFinal;
    public Vector2 puntoInicial;
    public GameObject puntoPersonaje;

    private float maxDistance;
    private float playerDistance;
    private float distanceAmount;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        maxDistance = Vector2.Distance(puntoInicial, puntoFinal);
    }

    void Update()
    {
        Vector2 posicionPersonaje = puntoPersonaje.transform.position;

        playerDistance = Vector2.Distance(posicionPersonaje, puntoFinal);

        distanceAmount = 1 - (playerDistance / maxDistance);

        slider.value = distanceAmount;

    }
}
