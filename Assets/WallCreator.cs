using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCreator : MonoBehaviour
{
    public int pocetVRade = 15;
    public int pocetZdi = 3;
    public int pocetPater = 6;

    public GameObject[] prefabs;

    void Start()
    {
        Generuj();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Generuj();
        }
    }

    private void Generuj()
    {
        for (int i = -pocetVRade/2; i < pocetVRade/2; i++)
        {
            for(int j = 0; j < pocetPater; j++)
            {
                for(int k = 0; k < pocetZdi; k++)
                {
                    VytvorKosticku(i, j, k);
                }
            }
        }
    }

    private void VytvorKosticku(int x, int y, int z)
    {
        // TODO: implement me please!
        Vector3 pozice = transform.position;
        pozice.x += x;
        pozice.y += y;
        pozice.z += z;
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], pozice, Quaternion.identity);
        TranslateAssembler();
    }

    private void TranslateAssembler()
    {
        Debug.Log("Enough of that shet, Beny!");
    }
}
