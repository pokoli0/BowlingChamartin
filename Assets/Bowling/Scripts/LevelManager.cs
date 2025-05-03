using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    int nBolosTirados;

    [Header("Bolos")]
    [SerializeField] int nBolos;
    [SerializeField] TMPro.TextMeshProUGUI bolosText;

    [Header("Nombre del Jugador")]
    [SerializeField] TMP_InputField inputFieldNombre;
    [SerializeField] TMPro.TextMeshProUGUI textoResultado;

    [Header("Música")]
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] AudioSource musicaAmbiente;
    [SerializeField] AudioClip jazzMusic;
    [SerializeField] AudioClip rockMusic;
    [SerializeField] AudioClip retroMusic;

    [Header("Volumen")]
    [SerializeField] List<AudioSource> todosLosAudioSources;
    [SerializeField] Slider volumenSlider;

    public int GetBolosTirados()
    {
        return nBolosTirados;
    }

    public void Restart()
    {
        // Guardar tiempo actual de la canción
        PlayerPrefs.SetFloat("TiempoMusica", musicaAmbiente.time);

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

    public void GuardarNombre()
    {
        string nombre = inputFieldNombre.text;
        textoResultado.text = nombre;

        PlayerPrefs.SetString("NombreJugador", nombre); // Guardamos el nombre
    }

    void CambiarCancion(int index)
    {
        PlayerPrefs.SetInt("MusicaSeleccionada", index); //guarda la musica q estaba

        switch (index)
        {
            case 0:
                musicaAmbiente.clip = jazzMusic;
                break;
            case 1:
                musicaAmbiente.clip = rockMusic;
                break;
            case 2:
                musicaAmbiente.clip = retroMusic;
                break;
        }

        musicaAmbiente.Play();
    }



    public void CambiarVolumen(float volumen)
    {
        foreach (AudioSource source in todosLosAudioSources)
        {
            source.volume = volumen;
        }

        PlayerPrefs.SetFloat("VolumenGeneral", volumen); // guarda el volumen
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
        // Música
        int musicaIndex = PlayerPrefs.GetInt("MusicaSeleccionada", 0);
        dropdown.value = musicaIndex;
        CambiarCancion(musicaIndex);

        // Tiempo de la música
        if (PlayerPrefs.HasKey("TiempoMusica"))
        {
            float tiempoMusica = PlayerPrefs.GetFloat("TiempoMusica");
            musicaAmbiente.time = tiempoMusica;
            musicaAmbiente.Play();
        }

        dropdown.onValueChanged.AddListener(delegate { CambiarCancion(dropdown.value); });

        // Volumen
        float volumenGuardado = PlayerPrefs.GetFloat("VolumenGeneral", 1f); // por defecto 1 (volumen completo)
        volumenSlider.value = volumenGuardado; // actualiza el slider visualmente
        CambiarVolumen(volumenGuardado); // aplica el volumen


        // Nombre
        if (PlayerPrefs.HasKey("NombreJugador"))
        {
            string nombreGuardado = PlayerPrefs.GetString("NombreJugador");
            inputFieldNombre.text = nombreGuardado;
            textoResultado.text = nombreGuardado;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
