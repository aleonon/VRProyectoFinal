using System.Collections.Generic;
using UnityEngine;

public class ZonaReceta : MonoBehaviour
{
    public SlotRecetaa[] slots;

    public List<int> recetaActual = new List<int>();

    public void LeerReceta()
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
}