using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{
    //Needs to be Even
    public int iX;
    public int iY;

    [SerializeField] int iBombP;

    [SerializeField] int iSize;

    [SerializeField] int iOffset;

    [SerializeField] GameObject goBackground;
    [SerializeField] GameObject goButton;

    [SerializeField] GameObject goX;
    [SerializeField] GameObject goY;
    [SerializeField] GameObject goBP;

    void Start()
    {
        GenerateWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateWorld()
    {
        SetXYB();
        
        int iBombs = Mathf.RoundToInt((float)iX * (float)iY / 100 * (float)iBombP);

        GameObject.FindGameObjectWithTag("WinManager").GetComponent<WinChecker>().iNeededPoints = iX * iY - iBombs;

        //Calculating Size and scaling BG
        int iXSize = iSize * iX;
        int iYSize = iSize * iY;

        goBackground.GetComponent<RectTransform>().sizeDelta = new Vector2(iXSize + iOffset, iYSize + iOffset);

        //Calculating starting Position
        Vector3 v3Position = new Vector3(0 - (iSize / 2) - (iSize * (iX / 2 - 1)), 0 + (iSize / 2) + (iSize * (iY / 2 - 1)), 0);

        int iID = 0;

        for (int i = 0; i < iY; i++)
        {
            for (int j = 0; j < iX; j++)
            {
                //Debug.Log(i + " | " + j);

                GameObject goSpawn = Instantiate(goButton, Vector3.zero, Quaternion.identity, goBackground.transform);
                goSpawn.GetComponent<RectTransform>().localPosition = v3Position;
                goSpawn.GetComponent<Unit>().iID = iID;

                v3Position = new Vector3(v3Position.x + iSize, v3Position.y, 0);
                iID++;
            }

            v3Position = new Vector3(0 - (iSize / 2) - (iSize * (iX / 2 - 1)), v3Position.y - iSize, 0);
        }

        PlaceBombs(iBombs);
    }

    private void PlaceBombs(int i)
    {
        GameObject[] goUnits = GameObject.FindGameObjectsWithTag("Units");
        do
        {
            int iRandom = Random.Range(0, goUnits.Length);

            if (goUnits[iRandom].GetComponent<Unit>().bBomb == false)
            {
                goUnits[iRandom].GetComponent<Unit>().bBomb = true;

                i--;
            }

        } while (i > 0);
    }

    private void SetXYB()
    {
        //X
        if (goX.GetComponent<Dropdown>().value == 4)
        {
            iX = 46;
        }
        else
        {
            iX = (goX.GetComponent<Dropdown>().value + 1) * 10;
        }

        //Y
        if (goY.GetComponent<Dropdown>().value == 2)
        {
            iY = 26;
        }
        else
        {
            iY = (goX.GetComponent<Dropdown>().value + 1) * 10;
        }


        //BP
        iBombP = (goBP.GetComponent<Dropdown>().value + 1) * 10;
    }
}