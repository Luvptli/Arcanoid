using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenScript : MonoBehaviour
{

    [SerializeField]
    GameObject pantallaI;
    [SerializeField]
    public GameObject pantallaG;
    [SerializeField]
    GameObject pantallaP;
    [SerializeField]
    GameObject pantallaO;
    [SerializeField]
    LeanTweenType animCurve;
    [SerializeField]
    GameObject pantallaInfo;
    [SerializeField]
    public GameObject canvasJuego;
    [SerializeField]
    GameObject canvasPausa;

    [SerializeField]
    MovimientoJugador movimientoJugador;
    [SerializeField]
    MovimientoPelota movimientoPelota;

    [SerializeField]
    Slider slideVolume;
    [SerializeField]
    float valueVolume;
    [SerializeField]
    Image imagenMuteO;
    [SerializeField]
    Image imagenMuteJ;

    [SerializeField]
    Slider slideBrillo;
    [SerializeField]
    float valueBrillo;
    [SerializeField]
    Image imagenBrillo;

    [SerializeField]
    Toggle pantallaCompleta;

    [SerializeField]
    TMP_Dropdown resolutionDropdown;
    Resolution[] resoluciones;

    [SerializeField]
    public GameObject pantallaNewG;


    bool estaJugando;

    [SerializeField]
    public GameObject canvasPowerUp;

    void Start()
    {
        estaJugando = false;
        pantallaI.SetActive(true);
        pantallaG.SetActive(false);
        pantallaP.SetActive(false);
        pantallaO.SetActive(false);
        pantallaInfo.SetActive(false);
        movimientoJugador.enabled = false;
        movimientoPelota.enabled = false;
        canvasJuego.SetActive(false);
        canvasPausa.SetActive(false);
        pantallaNewG.SetActive(false);
        slideVolume.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slideVolume.value;
        Mute();
        slideBrillo.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        imagenBrillo.color = new Color(imagenBrillo.color.r, imagenBrillo.color.g, imagenBrillo.color.b, slideBrillo.value);
        if (Screen.fullScreen)
        {
            pantallaCompleta.isOn = true;
        }
        else
        {
            pantallaCompleta.isOn = false;
        }
        RevisarResolucion();
    }

    void Update()
    {
        if (estaJugando & Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPausa.SetActive(true);
           
            Time.timeScale = 0f;
        }   
    }

    public void Continuar()
    {
        estaJugando = true;
        canvasPausa.SetActive(false);
        Time.timeScale=1f;
    }

    public void StartButton()
    {
        estaJugando = false;
        pantallaI.SetActive(false);
        pantallaInfo.SetActive(true);
        canvasJuego.SetActive(true);
        LeanTween.scale(pantallaInfo, Vector3.one * 0.9f, 0.5f).setEase(animCurve).setOnComplete(() =>
        {
            LeanTween.scale(pantallaInfo, Vector3.one * 1f, 0.5f);
        });
    }

    public void ListoButton()
    {
        pantallaInfo.SetActive(false);
        estaJugando = true;
        pantallaNewG.SetActive(false);
        //tiempoSinFuncionar += Time.deltaTime;
        //if (tiempoSinFuncionar>=5.0f)
        //{
            movimientoJugador.enabled = true;
            movimientoPelota.enabled=true;
        
        //}
    }

    public void OptionButton()
    {
        estaJugando = false;

        pantallaNewG.SetActive(false);
        pantallaO.SetActive(true);
            pantallaI.SetActive(false);

        
    }

    public void VolumenSlide(float valor)
    {
        estaJugando = false;
        valueVolume = valor;
        PlayerPrefs.SetFloat("volumenAudio", valueVolume);
        AudioListener.volume = valueVolume;
        Mute();
    }

    public void Mute()
    {
        if (valueVolume == 0)
        {
            imagenMuteO.enabled = true;
            imagenMuteJ.enabled = true;
        }
        else
        {
            imagenMuteO.enabled = false;
            imagenMuteJ.enabled = false;
        }
    }

    public void BrilloSlide (float valor)
    {
        valueBrillo = valor;
        PlayerPrefs.SetFloat("brillo", valueBrillo);
        imagenBrillo.color = new Color(imagenBrillo.color.r, imagenBrillo.color.g, imagenBrillo.color.b, slideBrillo.value);
    }
    
    public void ActivarPantallaCompleta (bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    public void RevisarResolucion()
    {
        resoluciones = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i< resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + "x" + resoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }
        resolutionDropdown.AddOptions(opciones);
        resolutionDropdown.value = resolucionActual;
        resolutionDropdown.RefreshShownValue();
    }

    public void CambiarResolucion (int indiceResolucion)
    {
        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }

    public void ReturnButton()
    {   
           pantallaO.SetActive(false);
        pantallaInfo.SetActive(false);
        pantallaI.SetActive(true);
        pantallaNewG.SetActive(true);

    }

    public void SalirButton()
    {
        Debug.Log("Salir");
        Application.Quit();
    }

    public void PantallaDeInicioButton()
    {
        estaJugando = false;
        canvasPausa.SetActive(false);
        pantallaG.SetActive(false);
        pantallaP.SetActive(false);
        canvasJuego.SetActive(false);
        pantallaI.SetActive(false);
        pantallaNewG.SetActive(true);
    }
    public void ReintentarButton()
    {
        estaJugando = false;
        pantallaG.SetActive(false);
        pantallaP.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pantallaI.SetActive(false);
    }

    public void NuevoJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<Bloques>().GenerarMapa();
    }

    public void ContinuarJuego()
    {
        estaJugando = true;
        pantallaG.SetActive(false);
        canvasJuego.SetActive(true);
        FindObjectOfType<Bloques>().GenerarMapa();
        Time.timeScale = 1f;
    }

}

