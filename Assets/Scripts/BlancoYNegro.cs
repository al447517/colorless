using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SocialPlatforms.Impl; // Si usas URP
public class BlancoYNegro : MonoBehaviour
{
    Volume volume;
    ColorAdjustments colorAdjustments;
    public ScoreController Score;
    public int scoreAnterior;

    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out colorAdjustments);
        scoreAnterior = 0;
    }

    void Update()
    {
        if (Score.Score > scoreAnterior && colorAdjustments.saturation.value <= 100) 
        {
            // Cambiar saturacion
            colorAdjustments.saturation.value += 10f;
            scoreAnterior = Score.Score;
        }
    }
}
