using UnityEngine;
using DG.Tweening;

public class Carta : MonoBehaviour
{
    [SerializeField]
    int cartaId;
    MemoryManager memoryManager;

    private void Start()
    {
        memoryManager = FindFirstObjectByType<MemoryManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Grabber")
        {
            memoryManager.EvaluarCartas(this.gameObject);
            //rotar carta
        }
    }

    public int GetId()
    {
        return cartaId;
    }

    public void RegresarCartas()
    {
        print("Volver al inicio");
        //VOLVER A GIRAR LA CARTA     ESTADO INICIAL
    }
}
