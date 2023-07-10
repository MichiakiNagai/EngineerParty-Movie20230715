using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
    #region DefObj
    public GameObject part_CountDown;
    public GameObject part_Title;
    public GameObject train;
//    public GameObject presidentVoice;

    public GameObject seto_Bridge;
    public GameObject tunnel_A;
    public GameObject tunnel_B;
    public GameObject sus_Kyoto;
    public GameObject telsaHall;

    public GameObject[] textList;

    public Animator cameraAnimator;
    public AudioSource MainTrainSE;
    public AudioSource bridgeSE;

    public float time = -10.0f;

    float exitCountDownTime = 30.20f;  // è]óàtime(25.20f) ÇÊÇË +5.0f ÇµÇΩ
    float switchModelTime = 49.50f;
    int text_i = 0;

    bool istunnel_B_ON_Flag = false;
    string isArrived_AnimationFlag = "isArrived";
    #endregion DefObj

    void Start()
    {
        part_CountDown.SetActive(true);
        part_Title.SetActive(false);
        train.SetActive(false);

        ResetArrayCondition(textList, false);
        tunnel_A.SetActive(true);
        tunnel_B.SetActive(false);
        sus_Kyoto.SetActive(false);
        telsaHall.SetActive(false);
    }

    
    void Update()
    {
        time = Time.time;

        if (exitCountDownTime -5.0f < time && time < exitCountDownTime)
        {
            part_CountDown.SetActive(false);
            part_Title.SetActive(true);
        }
        else if (exitCountDownTime + 5.0f < time && time < 85.0f)
        {
            part_Title.SetActive(false);
            SwitchModels();
            TimingUIProcess();
        }
        else
        {
            cameraAnimator.SetBool(isArrived_AnimationFlag, true);
        }

    }

    public void ResetArrayCondition(GameObject[] array, bool flag)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i].SetActive(flag);
        }
    }

    void SwitchModels()
    {
        if (exitCountDownTime < time)  // 35.20f
        {
            train.SetActive(true);
//            presidentVoice.SetActive(true);
            part_CountDown.SetActive(false);

            if (switchModelTime +4.0f <= time)  // 49.50f
            {
                seto_Bridge.SetActive(false);

                if (switchModelTime +10.00f <= time) // 59.50f
                {
                    if (!istunnel_B_ON_Flag)
                    {
                        tunnel_B.SetActive(true);
                        istunnel_B_ON_Flag = true;
                    }

                    if (switchModelTime + 12.00f <= time)  // 61.50f
                    {
                        tunnel_A.SetActive(false);

                        if (switchModelTime + 13.50f <= time)  // 63.00f
                        {
                            sus_Kyoto.SetActive(true);

                            if (time < switchModelTime + 30.50f)  // 80.00f
                            {
                                if (switchModelTime + 18.30f < time)  // 67.80f
                                {
                                    tunnel_B.SetActive(false);
                                    telsaHall.SetActive(true);
                                }
                            }
                            else
                            {
                                sus_Kyoto.SetActive(false);
                            }
                        }

                    }
                }
            }
        }

    }

    public void TimingUIProcess()
    {
        if (exitCountDownTime <= time && time < 37.00f)
        {
            DisplayTexts(0);
        }
        else if (37.00f <= time && time < 43.00f)
        {
            DisplayTexts(1);
        }
        else if (43.00f <= time && time < 50.00f)
        {
            DisplayTexts(2);
        }
        else if (50.00f <= time && time < 57.00f)
        {
            DisplayTexts(3);
        }
        else if (57.00f <= time && time < 64.00f)
        {
            DisplayTexts(4);
        }
        else if (64.00f <= time && time < 71.00f)
        {
            DisplayTexts(5);
        }
        else if (71.00f <= time && time < 78.00f)
        {
            DisplayTexts(6);
        }
        else if (78.00f <= time && time < 85.00f)
        {
            DisplayTexts(7);
        }
        /*
        else if (80.00f <= time && time < 85.00f)
        {
            DisplayTexts(8);
        }*/
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
