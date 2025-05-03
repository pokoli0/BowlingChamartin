using UnityEngine;
using System.Collections;

public class AlleyComponent : MonoBehaviour
{
    [SerializeField] ParticleSystem celebracionParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball")) return;

        int bolosTirados = LevelManager.Instance.GetBolosTirados();
        if (bolosTirados == 0) return;

        if (celebracionParticles != null)
        {
            var emission = celebracionParticles.emission;
            var main = celebracionParticles.main;

            // Ajustes por rango
            if (bolosTirados <= 4)
            {
                emission.rateOverTime = 15;
                main.startColor = Color.white;
                main.startSize = 0.3f;
            }
            else if (bolosTirados <= 7)
            {
                emission.rateOverTime = 40;
                main.startColor = Color.cyan;
                main.startSize = 0.5f;
            }
            else
            {
                emission.rateOverTime = 80;
                main.startColor = Color.yellow;
                main.startSize = 0.8f;
            }

            celebracionParticles.Play();

            // Detenemos automáticamente después de un tiempo
            StartCoroutine(DetenerParticulasTrasTiempo(2f)); // 2 segundos de efecto
        }
    }

    private IEnumerator DetenerParticulasTrasTiempo(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        if (celebracionParticles != null)
        {
            celebracionParticles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}
