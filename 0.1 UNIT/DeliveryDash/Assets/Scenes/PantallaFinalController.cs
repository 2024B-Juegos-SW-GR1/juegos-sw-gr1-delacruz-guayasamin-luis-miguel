using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PantallaFinalController : MonoBehaviour
{
    [SerializeField] private TMP_Text mensajeFinalText;
    [SerializeField] private TMP_Text puntajeFinalText;
    [SerializeField] private UnityEngine.UI.Button botonReiniciar;
    [SerializeField] private UnityEngine.UI.Button botonSalir;

    private void Start()
    {
        // Recuperar los datos
        string mensajeFinal = PlayerPrefs.GetString("Resultado", "¡Juego Terminado!");
        int puntajeFinal = PlayerPrefs.GetInt("PuntajeFinal", 0);

        // Mostrar los datos
        mensajeFinalText.text = mensajeFinal;
        puntajeFinalText.text = "Puntaje Final: " + puntajeFinal;

        // Asignar funcionalidades a los botones
        botonReiniciar.onClick.AddListener(ReiniciarJuego);
        botonSalir.onClick.AddListener(SalirDelJuego);
    }

    public void ReiniciarJuego()
    {
        // Cargar la escena inicial
        SceneManager.LoadScene("SampleScene");
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}