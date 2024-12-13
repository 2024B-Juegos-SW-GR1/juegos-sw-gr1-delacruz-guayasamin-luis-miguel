using UnityEngine;
using UnityEngine.SceneManagement;

public class Colision : MonoBehaviour
{
    private bool hasPackage = false;
    [SerializeField] private float destroyDelay = 0.5f;

    // Vidas y puntaje
    [SerializeField] private int vidas = 3;
    private int puntaje = 0;
    private float tiempoInicio;

    // Paquetes
    [SerializeField] private int totalPaquetes = 3;
    private int paquetesEntregados = 0;

    private void Start()
    {
        tiempoInicio = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            vidas--;
            Debug.Log("Colisión con obstáculo. Vidas restantes: " + vidas);

            if (vidas <= 0)
            {
                Debug.Log("¡Juego Terminado! No quedan vidas.");
                FinalizarJuego(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paquete" && !hasPackage)
        {
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Cliente" && hasPackage)
        {
            hasPackage = false;
            paquetesEntregados++;

            // Incrementar puntaje basado en tiempo
            float tiempoActual = Time.time;
            int puntosGanados = Mathf.Max(100 - (int)(tiempoActual - tiempoInicio), 10);
            puntaje += puntosGanados;

            tiempoInicio = Time.time;

            // Si se entregaron todos los paquetes, cargar la pantalla final
            if (paquetesEntregados >= totalPaquetes)
            {
                FinalizarJuego(true);
            }
        }
    }

    private void FinalizarJuego(bool completado)
    {
        // Guardar puntaje para la pantalla final
        PlayerPrefs.SetInt("PuntajeFinal", puntaje);
        PlayerPrefs.SetString("Resultado", completado ? "¡Felicidades, Completaste el Juego!" : "¡Juego Terminado!");

        // Cargar la escena de pantalla final
        SceneManager.LoadScene("Final");
    }

    private void OnGUI()
    {
        // Mostrar vidas, puntaje y paquetes entregados en pantalla
        GUI.Label(new Rect(10, 10, 150, 20), "Vidas: " + vidas);
        GUI.Label(new Rect(10, 30, 150, 20), "Puntaje: " + puntaje);
        GUI.Label(new Rect(10, 50, 150, 20), "Paquetes: " + paquetesEntregados + "/" + totalPaquetes);
    }
}


