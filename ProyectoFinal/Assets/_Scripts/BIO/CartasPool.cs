using System.Collections.Generic;
using UnityEngine;

public class CartasPool : MonoBehaviour
{
    public static CartasPool instance;
    public GameObject img;

    [SerializeField] int cantidad;
    [SerializeField] bool puedeCrecer = true;

    [SerializeField] List<GameObject> CartasImg = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < cantidad; i++)
        {
            GameObject go = Instantiate(img, transform);
            go.SetActive(false);
            CartasImg.Add(go);
        }
    }

    public GameObject GetPoolImg()
    {
        for (int i = 0; i < CartasImg.Count; i++)
        {
            if (CartasImg[i].activeInHierarchy) //if (!CartasImg[i].activeInHierarchy)
            {
                return CartasImg[i];
            }
        }

        if (puedeCrecer)
        {
            GameObject go = Instantiate(img, transform);
            go.SetActive(false);
            CartasImg.Add(go);
            return go;
        }

        return null;
    }
}