using System.Collections;
using System.Collections.Generic;
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

    public float time = -10.0f;

    void Start()
    {
        part_CountDown.SetActive(true);
        train.SetActive(false);
    }

    
    void Update()
    {
        time = Time.time;

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
                theater.SetActive(true);
                if (60.0f < time)
                {
                    tunnel.SetActive(false);
                }
            }
            else if (70.0f <= time)
            {
                sus_Kyoto.SetActive(false);
            }
        }
        

        
    }
}
