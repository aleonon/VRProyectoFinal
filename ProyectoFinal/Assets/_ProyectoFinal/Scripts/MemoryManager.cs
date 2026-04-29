using UnityEngine;

public class MemoryManager : MonoBehaviour
{

    GameObject carta1;
    GameObject carta2;

    int carta1Id;
    int carta2Id;

    int cantidadCartas = 0;

    public void EvaluarCartas (GameObject carta)
    {

        if (cantidadCartas == 0) {
            carta1 = carta;
            carta1Id = carta.GetComponent<Carta>().GetId();
  
            cantidadCartas++;
            print("Primera carta: "+ carta1Id);

        } else if (cantidadCartas == 1 && carta != carta1) { 
            carta2 = carta;
            carta2Id = carta.GetComponent<Carta>().GetId();
            cantidadCartas++;

            print("Segunda carta: " + carta2Id);
        }

        if (cantidadCartas == 2)
        {
            if (carta1Id == carta2Id)
            {
                print("Son iguales");
                //hacer algo al tener cartas iguales, destroy o algo
                Destroy(carta1);
                Destroy(carta2);
            } else
            {
                print("No son iguales");

                carta1.GetComponent<Carta>().RegresarCartas();
                carta2.GetComponent<Carta>().RegresarCartas();

            }

            cantidadCartas = 0;
        }
    }

}
