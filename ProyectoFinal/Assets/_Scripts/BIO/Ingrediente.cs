using System.Collections;
using UnityEngine;

public class Ingrediente : MonoBehaviour
{
    public IngredienteSpawner spawner;

    private void OnEnable()
    {
        CancelInvoke();
    }

    void Desactivar()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {

        // Avisar al spawner que este objeto ya no está disponible
        if (spawner != null)
        {
            spawner.NotificarObjetoDesaparecido(gameObject);
        }
    }
}
