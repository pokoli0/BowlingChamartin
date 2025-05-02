using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoloComponent : MonoBehaviour
{
    [SerializeField] private bool fallen = false;

    private void Start()
    {
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.RegisterBolo();
        }
    }

    void Update()
    {
        float anguloX = transform.localEulerAngles.x;
        if (anguloX > 180f)
        {
            anguloX -= 360f;
        }

        float anguloRelativo = anguloX + 90f; // porque empiezan en -90º

        //Debug.Log($"{gameObject.name} -> Ángulo relativo: {anguloRelativo}");

        if (!fallen && (anguloRelativo > 45f || anguloRelativo < -45f))
        {
            fallen = true;
            //Debug.Log(gameObject.name + " ha caído");

            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.BoloCaido();
            }
        }
    }
}
