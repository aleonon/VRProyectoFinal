using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int recetasParaGanar = 5;
    public int erroresMaximos = 3;

    private int recetasCorrectas = 0;
    private int erroresSeguidos = 0;

    public bool juegoTerminado = false;

    //refrencias aaaaaaaaaaaaaaaaaaaa
    public GeneradorPatrones generador;
    public ZonaReceta zonaReceta;
    public Timer timer;

    public GameObject panelVictoria;
    public GameObject panelDerrota;

    private void Start()
    {
        IniciarJuego();
    }

    public void IniciarJuego()
    {
        juegoTerminado = false;
        recetasCorrectas = 0;
        erroresSeguidos = 0;

        panelVictoria?.SetActive(false);
        panelDerrota?.SetActive(false);

        generador.GenerarPatron();
    }

    public void RecetaCorrecta()
    {
        if (juegoTerminado) return;

        recetasCorrectas++;
        erroresSeguidos = 0;

        Debug.Log("Correctas: " + recetasCorrectas);

        if (recetasCorrectas >= recetasParaGanar)
        {
            Victoria();
            return;
        }

        SiguienteRonda();
    }

    public void RecetaIncorrecta()
    {
        if (juegoTerminado) return;

        erroresSeguidos++;

        Debug.Log("Errores seguidos: " + erroresSeguidos);

        if (erroresSeguidos >= erroresMaximos)
        {
            Derrota();
            return;
        }

        SiguienteRonda();
    }

    void SiguienteRonda()
    {
        zonaReceta.LimpiarSlots();
        generador.GenerarPatron();
    }

    void Victoria()
    {
        juegoTerminado = true;
        Debug.Log("GANASTE");

        panelVictoria?.SetActive(true);
        FinJuego();
    }

    void Derrota()
    {
        juegoTerminado = true;
        Debug.Log("PERDISTE");

        panelDerrota?.SetActive(true);
        FinJuego();
    }

    void FinJuego()
    {
        timer.PararTimer();
    }
}