using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    int currentLevel;

    int nBolosTirados;
    int currentTiros;

    [SerializeField] int tirosMax;
    [SerializeField] int nBolos;

    public void NextLevel()
    {
        currentLevel++;

        // reset de nTiros

        // tp
    }

    public void BoloCaido()
    {
        nBolosTirados++;
        Debug.Log("Bolos tirados: " + nBolosTirados);

        if (nBolosTirados >= nBolos)
        {
            Debug.Log("Todos los bolos han caido");
            NextLevel();
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
        currentTiros = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTiros >= tirosMax)
        {
            Debug.Log("tirosMaximos alcanzados");
            NextLevel();
        }
    }
}
