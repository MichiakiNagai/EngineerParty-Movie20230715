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
    public GameObject mainGuide;
    public GameObject shachoComment001;
    public GameObject shachoComment002;
    public GameObject shachoVoice001;
    public GameObject shachoVoice002;
    public Animator shachoAnimator;
    public Animator cameraAnimator;
    public Animator markOkayamaAnimator;
    public AudioSource trainSE;
    public AudioSource mainBGM;

    public float time = -10.0f;

    float exitCountDownTime = 30.20f;  // è]óàtime(25.20f) ÇÊÇË +5.0f ÇµÇΩ
    float jumpingOkayamaPanelTime = 54.00f;
    float switchModelTime = 57.50f;  // 53.5+4
    float textStartTime = 41.50f;  // 53.5+4

    bool istunnel_B_ON_Flag = false;
    string isJump_AnimationFlag = "Jump";
    string isArrived_AnimationFlag = "isArrived";
    string isZooming_AnimationFlag = "isZooming";
    string isFinal_AnimationFlag = "isFinal";
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
        shachoComment001.SetActive(false);
        shachoComment002.SetActive(false);
        shachoVoice002.SetActive(false);
        shachoVoice002.SetActive(false);
//        fadeOut.SetActive(false);
//        endScreenColor = endSlide.GetComponent<MeshRenderer>();
//        endSlide.SetActive(false);
        selfFader.SetActive(true);  // ONÇµñYÇÍñhé~ÅFÉJÉÅÉâà íuïœçXÇ…ÇÊÇËPositionçƒí≤êÆïKóv
    }

    
    void Update()
    {
        time = Time.time;

        if (exitCountDownTime -5.0f < time && time < exitCountDownTime)
        {
            part_CountDown.SetActive(false);
            part_Title.SetActive(true);
        }
        else if (exitCountDownTime + 5.0f < time && time < 95.0f)
        {
            part_Title.SetActive(false);
            if (jumpingOkayamaPanelTime < time)
            {
                markOkayamaAnimator.SetBool(isJump_AnimationFlag, true);
            }
            SwitchModels();
            TimingUIProcess();
        }
        else if(95.00f < time) // 85.0 ïbà»è„
        {
            if (116.00f < time)  // 103.0+13
            {
                cameraAnimator.SetBool("isFadeOut", true);
            }
            else if (111.00f < time)  // 98.0+13
            {
                cameraAnimator.SetBool("isEnd", true);
                mainBGM.volume -= Time.deltaTime * 0.2f;
            }
            else if (107.00f < time)  // 94.0+13
            {
                cameraAnimator.SetBool(isFinal_AnimationFlag, true);
            }
            else if (104.50f < time)  // 91.5+13
            {
                shachoComment001.SetActive(false);
                shachoComment002.SetActive(true);
                shachoVoice002.SetActive(true);
            }
            else if (101.50f < time)  //88.5+13
            {
                shachoComment001.SetActive(true);
                shachoVoice001.SetActive(true);
            }
            else if (99.50f < time)  // 86.5+13
            {
                cameraAnimator.SetBool(isZooming_AnimationFlag, true);
            }
            else if (97.50f < time)  // 84.5+13
            {
                mainGuide.SetActive(false);
                trainSE.volume = 0.0f;
                cameraAnimator.SetBool(isArrived_AnimationFlag, true);
            }
            /*
            if (86.00f < time)
            {
                worldCanvas.SetActive(false);
                cameraAnimator.SetBool(isArrived_AnimationFlag, true);
            }
            if (89.00f < time)
            {
                cameraAnimator.SetBool(isZooming_AnimationFlag, true);
            }
            if (93.00f < time)
            {
                cameraAnimator.SetBool(isFinal_AnimationFlag, true);
            }
            */
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
            part_CountDown.SetActive(false);

            if (switchModelTime <= time)  // 57.50f
            {
                seto_Bridge.SetActive(false);

                if (switchModelTime + 6.00f <= time) // 63.50f
                {
                    if (!istunnel_B_ON_Flag)
                    {
                        tunnel_B.SetActive(true);
                        istunnel_B_ON_Flag = true;
                    }

                    if (switchModelTime + 11.00f <= time)  // 68.50f
                    {
                        tunnel_A.SetActive(false);

                        if (switchModelTime + 13.50f <= time)  // 71.00f
                        {
                            sus_Kyoto.SetActive(true);

                            if (time < switchModelTime + 25.50f)  // 84.00f
                            {
                                if (switchModelTime + 17.30f < time)  // 74.80f
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
        if (exitCountDownTime <= time && time < textStartTime)  // tST_41.50
        {
            DisplayTexts(0);
        }
        else if (textStartTime <= time && time < textStartTime + 7.50f)  // 49.00f
        {
            DisplayTexts(1);
        }
        else if (textStartTime + 7.50f <= time && time < textStartTime + 15.00f)  // 56.50f
        {
            DisplayTexts(2);
        }
        else if (textStartTime + 15.00f <= time && time < textStartTime + 25.00f)  // 66.50f
        {
            DisplayTexts(3);
        }
        else if (textStartTime + 25.00f <= time && time < textStartTime + 32.00f)  // 73.50
        {
            DisplayTexts(4);
        }
        else if (textStartTime + 32.00f <= time && time < textStartTime + 39.00f)  // 80.50f
        {
            DisplayTexts(5);
        }
        else if (textStartTime + 39.00f <= time && time < textStartTime + 47.00f)  // 88.50f
        {
            DisplayTexts(6);
        }
        else if (textStartTime + 47.00f <= time && time < textStartTime + 54.00f)  // 96.50f
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
