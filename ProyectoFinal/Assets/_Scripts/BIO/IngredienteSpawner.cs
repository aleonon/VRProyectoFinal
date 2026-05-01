using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredienteSpawner : MonoBehaviour
{
    public GameObject ingredientePrefab;

    [SerializeField] int cantidadPool;
    [SerializeField] float tiempoRespawn = 5f;

    private List<GameObject> pool = new List<GameObject>();
    private GameObject objetoActual;
    private bool esperandoRespawn = false;
    private bool objetoEnZona = false;

    private void Start()
    {
        for (int i = 0; i < cantidadPool; i++)
        {
            GameObject obj = Instantiate(ingredientePrefab, transform);
            obj.SetActive(false);

            Ingrediente ing = obj.GetComponent<Ingrediente>();
            if (ing != null)
            {
                ing.spawner = this;
            }

            pool.Add(obj);
        }

        SpawnIngrediente();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objetoActual)
        {
            objetoEnZona = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objetoActual)
        {
            objetoEnZona = false;

            if (!esperandoRespawn)
            {
                esperandoRespawn = true;
                Invoke(nameof(SpawnIngrediente), tiempoRespawn);
            }
        }
    }
    void SpawnIngrediente()
    {
        GameObject obj = ObtenerDelPool();

        if (obj == null)
        {
            Debug.LogWarning("No hay objetos disponibles en el pool");
            return;
        }

        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;

        obj.SetActive(true);

        objetoActual = obj;
        esperandoRespawn = false;
    }

    GameObject ObtenerDelPool()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        return null;
    }

    public void NotificarObjetoDesaparecido(GameObject obj)
    {
        if (obj == objetoActual && !esperandoRespawn)
        {
            esperandoRespawn = true;
        }
    }
}