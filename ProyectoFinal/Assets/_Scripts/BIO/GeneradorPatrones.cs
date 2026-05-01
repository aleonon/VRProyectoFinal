using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneradorPatrones : MonoBehaviour
{
    public List<GameObject> ingredientesPrefabs;

    public Transform[] espacios;
    public void GenerarPatron()
    {
        LimpiarEspacios();

        for (int i = 0; i < espacios.Length; i++)
        {
            int randomIndex = Random.Range(0, ingredientesPrefabs.Count);

            GameObject obj = Instantiate(ingredientesPrefabs[randomIndex], espacios[i]);
        }
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