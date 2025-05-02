using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    int nBolosTirados;

    [SerializeField] int nBolos;
    [SerializeField] TMPro.TextMeshProUGUI bolosText;

    public void Restart()
    {
        nBolosTirados = 0;
        UpdateTextoBolos();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BoloCaido()
    {
        nBolosTirados++;
        UpdateTextoBolos();

        //Debug.Log("Bolos tirados: " + nBolosTirados);

        if (nBolosTirados >= nBolos)
        {
            Debug.Log("Todos los bolos han caido");
        }
    }

    public void RegisterBolo()
    {
        nBolos++;
    }
    private void UpdateTextoBolos()
    {
        bolosText.text = nBolosTirados.ToString();
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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
