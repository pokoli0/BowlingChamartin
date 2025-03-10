using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoloComponent : MonoBehaviour
{
    [SerializeField] private bool fallen = false;

    void Update()
    {
        float anguloX = transform.localEulerAngles.x;
        if (anguloX > 180f)
        {
            anguloX -= 360f; // Ajustar valores entre -180° y 180°
        }
        Debug.Log("Angulo X global: " + anguloX);


        if (!fallen && (anguloX > 45f || anguloX < -45f))
        {
            fallen = true;
            Debug.Log(gameObject.name + " ha caido");

            // suma bolos tirados al level manager
            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.BoloCaido();
            }
        }
    }
}
