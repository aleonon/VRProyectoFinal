using System.Collections.Generic;
using UnityEngine;

public class ZonaReceta : MonoBehaviour
{
    public SlotRecetaa[] slots;

    public List<int> recetaActual = new List<int>();

    //refrencias aaaaaaaaaaaaaaaaaaaa
    public GeneradorPatrones generador;
    public GameManager gameManager;

    public void LeerReceta() //reune id de ingredientes
    {
        recetaActual.Clear();

        foreach (SlotRecetaa slot in slots)
        {
            if (slot.ingredienteActual != null)
            {
                recetaActual.Add(slot.ingredienteActual.idIngrediente);
            }
            else
            {
                recetaActual.Add(-1);
            }
        }

        Debug.Log("Receta jugador: " + string.Join(",", recetaActual));

        if (CompararReceta())
        {
            gameManager.RecetaCorrecta();
        }
        else
        {
            gameManager.RecetaIncorrecta();
        }
    }

    public void LimpiarSlots()
    {
        foreach (SlotRecetaa slot in slots)
        {
            if (slot.ingredienteActual != null)
            {
                slot.ingredienteActual.gameObject.SetActive(false);
                slot.ingredienteActual = null;
            }
        }

        recetaActual.Clear();
    }

    public bool CompararReceta()
    {
        List<int> patron = generador.patronActual;

        if (patron.Count != recetaActual.Count)
        {
            Debug.Log("Tamaños distintos");
            return false;
        }

        for (int i = 0; i < patron.Count; i++)
        {
            if (patron[i] != recetaActual[i])
            {
                Debug.Log("Receta incorrecta");
                return false;
            }
        }

        Debug.Log("Receta correcta");
        return true;

    }
    /*
    public void GenerarNuevaReceta()
    {
        CompararReceta();
        LimpiarSlots();
        generador.GenerarPatron();
    }
    */
}