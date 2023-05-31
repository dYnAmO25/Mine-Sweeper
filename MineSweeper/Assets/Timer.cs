using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text tTimeText;
    
    private float fTime;

    private string sTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("WinManager").GetComponent<WinChecker>().bDidExplode == false)
        {
            if (GameObject.FindGameObjectWithTag("WinManager").GetComponent<WinChecker>().bWon == false)
            {
                fTime += Time.deltaTime;

                sTime = GetTime(fTime);

                tTimeText.text = sTime;
            }
        }
    }

    private string GetTime(float f)
    {
        int s = ((int)f % 60);
        int m = ((int)f / 60 % 60);
        int h = ((int)f / 60 / 60 % 60);

        string ss;
        string sm;
        string sh;

        if (s >= 10)
        {
            //s ohne 0
            ss = s.ToString();
        }
        else
        {
            //s mit 0
            ss = "0" + s.ToString();
        }

        if (m >= 10)
        {
            //m ohne 0
            sm = m.ToString();
        }
        else
        {
            //m mit 0
            sm = "0" + m.ToString();
        }

        if (h >= 10)
        {
            //h ohne 0
            sh = h.ToString();
        }
        else
        {
            //h mit 0
            sh = "0" + h.ToString();
        }

        return sh + ":" + sm + ":" + ss;
    }

    public void ResetTimer()
    {
        fTime = 0;
    }
}