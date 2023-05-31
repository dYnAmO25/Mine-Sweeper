using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    public bool bDidExplode = false;
    public int iNeededPoints;

    public bool bWon = false;

    public int iPoints;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bDidExplode)
        {
            Debug.Log("Lost");
        }
        if (iPoints >= iNeededPoints)
        {
            Debug.Log("Won");
            bWon = true;
        }
    }

    public void ResetWin()
    {
        bDidExplode = false;
        iNeededPoints = 1;
        bWon = false;
        iPoints = 0;
    }
}