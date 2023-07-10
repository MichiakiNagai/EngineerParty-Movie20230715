using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMonBridge : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Train")
        {
            MyGameManager.instance.bridgeSE.Play();
        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Train")
        {
            MyGameManager.instance.bridgeSE.Stop();
        }
    }
}
