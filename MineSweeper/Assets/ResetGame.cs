using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGame : MonoBehaviour
{
    public void ResetFunction()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Units");

        for (int i = 0; i < gos.Length; i++)
        {
            Destroy(gos[i]);
        }

        GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().ResetTimer();
        GameObject.FindGameObjectWithTag("WinManager").GetComponent<WinChecker>().ResetWin();
        GameObject.FindGameObjectWithTag("Map").GetComponent<MapGenerator>().GenerateWorld();
    }
}
