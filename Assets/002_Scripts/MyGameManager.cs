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

    int text_i = 0;

    void Start()
    {
        part_CountDown.SetActive(true);
        train.SetActive(false);

        for (int i = 0; i < textList.Length; i++)
        {
            textList[i].SetActive(false);
        }
    }

    
    void Update()
    {
        time = Time.time;

        SwitchModels();

        if (26.50f <= time && time < 34.00f)
        {
            DisplayTexts(0);
        }
        else if (34.00f <= time && time < 40.00f)
        {
            DisplayTexts(1);
        }
        else if (40.00f <= time && time < 47.00f)
        {
            DisplayTexts(2);
        }
        else if (47.00f <= time && time < 52.00f)
        {
            DisplayTexts(3);
        }/*
        else if (50.00f <= time && time < 50.00f)
        {
            DisplayTexts(4);
        }*/
        else if (55.00f <= time && time < 60.00f)
        {
            DisplayTexts(4);
        }
        else if (63.50f <= time && time < 70.00f)
        {
            DisplayTexts(5);
        }
    }

    void SwitchModels()
    {
        if (26.5f < time)
        {
            part_CountDown.SetActive(false);
            train.SetActive(true);

            if (time < 50.0f)
            {
                tunnel.SetActive(true);
                sus_Kyoto.SetActive(false);
                theater.SetActive(false);
            }
            else if (50.0f <= time && time < 70.0f)
            {
                sus_Kyoto.SetActive(true);
                if (60.0f < time)
                {
                    tunnel.SetActive(false);
                    theater.SetActive(true);
                }
            }
            else if (70.0f <= time)
            {
                sus_Kyoto.SetActive(false);
            }
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
