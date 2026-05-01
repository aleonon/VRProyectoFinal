using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneradorPatrones : MonoBehaviour
{
    public List<GameObject> ingredientesPrefabs;

    public Transform[] espacios;

    public List<int> patronActual = new List<int>();
    public void GenerarPatron()
    {
        LimpiarEspacios();
        patronActual.Clear();


        for (int i = 0; i < espacios.Length; i++)
        {
            int randomIndex = Random.Range(0, ingredientesPrefabs.Count);
            patronActual.Add(randomIndex);

            GameObject obj = Instantiate(ingredientesPrefabs[randomIndex], espacios[i]);
        }

        Debug.Log("Patrón generado: " + string.Join(",", patronActual));
    }

    void LimpiarEspacios()
    {
        foreach (Transform espacio in espacios)
        {
            foreach (Transform hijo in espacio)
            {
                Destroy(hijo.gameObject);
            }
        }
    }
}