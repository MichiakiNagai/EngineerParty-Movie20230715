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

    #region MainObj
    public GameObject part_CountDown;
    public GameObject part_Title;
    public GameObject train;
    //    public GameObject presidentVoice;
    #endregion MainObj
    #region PartObj
    public GameObject seto_Bridge;
    public GameObject tunnel_A;
    public GameObject tunnel_B;
    public GameObject sus_Kyoto;
    public GameObject telsaHall;
    #endregion PartObj
    public GameObject[] textList;

    public GameObject selfFader;
    public Animator cameraAnimator;
    public Animator markOkayamaAnimator;
    public AudioSource MainTrainSE;
    public AudioSource bridgeSE;

    public float time = -10.0f;

    float exitCountDownTime = 30.20f;  // 従来time(25.20f) より +5.0f した
    float jumpingOkayamaPanelTime = 49.50f;
    float switchModelTime = 53.50f;
    int text_i = 0;

    bool istunnel_B_ON_Flag = false;
    string isJump_AnimationFlag = "Jump";
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

//        selfFader.SetActive(true);  // ONし忘れ防止：カメラ位置変更によりPosition再調整必要
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
            if (jumpingOkayamaPanelTime < time)
            {
                markOkayamaAnimator.SetBool(isJump_AnimationFlag, true);
            }
            SwitchModels();
            TimingUIProcess();
        }
        else  // 85.0 秒以上
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

            if (switchModelTime <= time)  // 53.50f
            {
                seto_Bridge.SetActive(false);

                if (switchModelTime + 6.00f <= time) // 59.50f
                {
                    if (!istunnel_B_ON_Flag)
                    {
                        tunnel_B.SetActive(true);
                        istunnel_B_ON_Flag = true;
                    }

                    if (switchModelTime + 8.00f <= time)  // 61.50f
                    {
                        tunnel_A.SetActive(false);

                        if (switchModelTime + 9.50f <= time)  // 63.00f
                        {
                            sus_Kyoto.SetActive(true);

                            if (time < switchModelTime + 26.50f)  // 80.00f
                            {
                                if (switchModelTime + 14.30f < time)  // 67.80f
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
