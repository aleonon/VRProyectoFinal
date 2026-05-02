using UnityEngine;

public class SlotRecetaa : MonoBehaviour
{
    public Ingrediente ingredienteActual;

    private void OnTriggerEnter(Collider other)
    {
        Ingrediente ing = other.GetComponent<Ingrediente>();

        if (ing != null)
        {
            ingredienteActual = ing;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Ingrediente ing = other.GetComponent<Ingrediente>();

        if (ing != null && ingredienteActual == ing)
        {
            ingredienteActual = null;
        }
    }
}