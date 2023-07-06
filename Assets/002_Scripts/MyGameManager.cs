using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    #region Singleton
    public static MyGameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion Singleton

    public GameObject part_CountDown;
    public GameObject train;

    public GameObject tunnel;
    public GameObject sus_Kyoto;
    public GameObject theater;

    public GameObject[] textList;

    public float time = -10.0f;

    float exitCountDownTime = 25.20f;
    int text_i = 0;

    void Start()
    {
        part_CountDown.SetActive(true);
        train.SetActive(false);

        for (int i = 0; i < textList.Length; i++)
        {
            textList[i].SetActive(false);
        }
        tunnel.SetActive(true);
        sus_Kyoto.SetActive(false);
        theater.SetActive(false);
    }

    
    void Update()
    {
        time = Time.time;

        SwitchModels();

        if (exitCountDownTime <= time && time < 32.00f)
        {
            DisplayTexts(0);
        }
        else if (32.00f <= time && time < 38.00f)
        {
            DisplayTexts(1);
        }
        else if (38.00f <= time && time < 45.00f)
        {
            DisplayTexts(2);
        }
        else if (45.00f <= time && time < 50.00f)
        {
            DisplayTexts(3);
        }/*
        else if (50.00f <= time && time < 50.00f)
        {
            DisplayTexts(4);
        }*/
        else if (53.00f <= time && time < 58.00f)
        {
            DisplayTexts(4);
        }
        else if (61.50f <= time && time < 68.00f)
        {
            DisplayTexts(5);
        }
    }

    void SwitchModels()
    {
        if (exitCountDownTime < time)
        {
            train.SetActive(true);
            part_CountDown.SetActive(false);

            if (51.2f <= time)
            {
                if (time < 65.0f)
                {
                    sus_Kyoto.SetActive(true);
                    if (54.8f < time)
                    {
                        tunnel.SetActive(false);
                        theater.SetActive(true);
                    }
                }
                else
                {
                    sus_Kyoto.SetActive(false);
                }
                
            }/*
            else if (68.0f <= time)
            {
                sus_Kyoto.SetActive(false);
            }*/
        }
        
        
    }

    void DisplayTexts(int idx)
    {
        if (idx != 0)
        {
            textList[idx -1].SetActive(false);
        }
        textList[idx].SetActive(true);
        idx++;
    }
}
