using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int iID;
    public bool bOpen;
    public bool bBomb;
    public bool bFlag;
    public int iNumber;

    public GameObject Text;

    public Sprite Button;
    public Sprite Open;
    public Sprite Bomb;
    public Sprite Flag;

    private int iX;
    private int iY;

    private bool bPointGiven = false;

    void Start()
    {
        iX = GameObject.FindGameObjectWithTag("Map").GetComponent<MapGenerator>().iX;
        iY = GameObject.FindGameObjectWithTag("Map").GetComponent<MapGenerator>().iY;

        iNumber = GetBombs();
    }

    // Update is called once per frame
    void Update()
    {
        //iNumber = GetBombs();

        if (bFlag)
        {
            GetComponent<Image>().sprite = Flag;
            Text.GetComponent<Text>().text = null;
        }
        else if (bOpen)
        {
            if (bBomb == true)
            {
                GetComponent<Image>().sprite = Bomb;
                Text.GetComponent<Text>().text = null;

                GameObject.FindGameObjectWithTag("WinManager").GetComponent<WinChecker>().bDidExplode = true;
            }
            else
            {
                GetComponent<Image>().sprite = Open;
                Text.GetComponent<Text>().text = iNumber.ToString();

                if (bPointGiven == false)
                {
                    GameObject.FindGameObjectWithTag("WinManager").GetComponent<WinChecker>().iPoints++;
                    bPointGiven = true;
                }
            }
        }
        else
        {
            GetComponent<Image>().sprite = Button;
            Text.GetComponent<Text>().text = null;
        }

        if (bOpen && iNumber == 0)
        {
            ZeroOpen();
        }
    }

    public void LeftClick()
    {
        if (bFlag == false)
        {
            bOpen = true;
        }
    }

    public void RightClick()
    {
        if (bOpen != true)
        {
            bFlag = !bFlag;
        }
    }

    public void MiddleClick()
    {
         
    }

    private void ZeroOpen()
    {
        if (iID == 0)
        {
            GetUnit(GetE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetSE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetS(iID)).GetComponent<Unit>().bOpen = true;
        }
        else if (iID == iX - 1)
        {
            GetUnit(GetW(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetSW(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetS(iID)).GetComponent<Unit>().bOpen = true;
        }
        else if (iID > 0 && iID < iX - 1)
        {
            GetUnit(GetE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetSE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetS(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetSW(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetW(iID)).GetComponent<Unit>().bOpen = true;
        }
        else if (iID == (iX * iY) - iX)
        {
            GetUnit(GetN(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetNE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetE(iID)).GetComponent<Unit>().bOpen = true;
        }
        else if (iID == (iX * iY) - 1)
        {
            GetUnit(GetN(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetNW(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetW(iID)).GetComponent<Unit>().bOpen = true;
        }
        else if (iID > (iX * iY) - iX && iID < (iX * iY) - 1)
        {
            GetUnit(GetE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetNE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetN(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetNW(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetW(iID)).GetComponent<Unit>().bOpen = true;
        }
        else if (iID % iX == 0)
        {
            GetUnit(GetE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetSE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetS(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetNE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetN(iID)).GetComponent<Unit>().bOpen = true;
        }
        else if (iID % iX == iX - 1)
        {
            GetUnit(GetW(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetSW(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetS(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetNW(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetN(iID)).GetComponent<Unit>().bOpen = true;
        }
        else
        {
            GetUnit(GetW(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetSW(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetS(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetNW(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetN(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetNE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetE(iID)).GetComponent<Unit>().bOpen = true;
            GetUnit(GetSE(iID)).GetComponent<Unit>().bOpen = true;
        }
    }

    private int GetBombs()
    {
        if (iID == 0)
        {
            return CheckOne();
        }
        else if (iID == iX - 1)
        {
            return CheckThree();
        }
        else if (iID > 0 && iID < iX - 1)
        {
            return CheckTwo();
        }
        else if (iID == (iX * iY) - iX)
        {
            return CheckSeven();
        }
        else if (iID == (iX * iY) - 1)
        {
            return CheckNine();
        }
        else if (iID > (iX * iY) - iX && iID < (iX * iY) - 1)
        {
            return CheckEight();
        }
        else if (iID % iX == 0)
        {
            return CheckFour();
        }
        else if (iID % iX == iX - 1)
        {
            return CheckSix();
        }
        else
        {
            return CheckFive();
        }
    }

    //Checker

    private int CheckOne()
    {
        int i = 0;
        if (CheckBomb(GetUnit(GetE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetSE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetS(iID))))
        {
            i++;
        }

        return i;
    }
    private int CheckTwo()
    {
        int i = 0;
        if (CheckBomb(GetUnit(GetE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetSE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetS(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetSW(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetW(iID))))
        {
            i++;
        }

        return i;
    }
    private int CheckThree()
    {
        int i = 0;
        if (CheckBomb(GetUnit(GetS(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetSW(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetW(iID))))
        {
            i++;
        }

        return i;
    }
    private int CheckFour()
    {
        int i = 0;
        if (CheckBomb(GetUnit(GetN(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetNE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetSE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetS(iID))))
        {
            i++;
        }

        return i;
    }
    private int CheckFive()
    {
        int i = 0;
        if (CheckBomb(GetUnit(GetN(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetNE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetSE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetS(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetSW(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetW(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetNW(iID))))
        {
            i++;
        }

        return i;
    }
    private int CheckSix()
    {
        int i = 0;
        if (CheckBomb(GetUnit(GetSW(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetW(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetNW(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetS(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetN(iID))))
        {
            i++;
        }

        return i;
    }
    private int CheckSeven()
    {
        int i = 0;
        if (CheckBomb(GetUnit(GetN(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetNE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetE(iID))))
        {
            i++;
        }

        return i;
    }
    private int CheckEight()
    {
        int i = 0;
        if (CheckBomb(GetUnit(GetN(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetNE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetE(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetNW(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetW(iID))))
        {
            i++;
        }

        return i;
    }
    private int CheckNine()
    {
        int i = 0;
        if (CheckBomb(GetUnit(GetN(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetNW(iID))))
        {
            i++;
        }
        if (CheckBomb(GetUnit(GetW(iID))))
        {
            i++;
        }

        return i;
    }

    private bool CheckBomb(GameObject go)
    {
        if (go.GetComponent<Unit>().bBomb)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private GameObject GetUnit(int x)
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Units");

        for (int i = 0; i < gos.Length; i++)
        {
            if (gos[i].GetComponent<Unit>().iID == x)
            {
                return gos[i];
            }
        }

        Debug.Log("No Unit Found with ID" + x);
        return null;
    }

    private int GetN(int i)
    {
        return i - iX;
    }
    private int GetNE(int i)
    {
        return i - (iX - 1);
    }
    private int GetE(int i)
    {
        return i + 1;
    }
    private int GetSE(int i)
    {
        return (i + iX + 1);
    }
    private int GetS(int i)
    {
        return i + iX;
    }
    private int GetSW(int i)
    {
        return (i + (iX - 1));
    }
    private int GetW(int i)
    {
        return i - 1;
    }
    private int GetNW(int i)
    {
        return i - (iX + 1);
    }
}