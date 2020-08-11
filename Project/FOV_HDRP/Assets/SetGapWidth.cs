using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SetGapWidth : MonoBehaviour
{
    public GameObject Gap;
    public float StartGapPosX = 0f;
    public float StartGapScaleX = 1.5f;

    public SteamVR_Input_Sources handType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) || SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch").GetStateDown(handType))
    //    {
    //        float CurrentGapWidth = TrialController.GetCurrentGapWidth();
    //        Gap.transform.localScale = new Vector3(CurrentGapWidth, Gap.transform.localScale.y, Gap.transform.localScale.z);
    //        Gap.transform.position = new Vector3((StartGapPosX - StartGapScaleX/2 + CurrentGapWidth/2), Gap.transform.position.y, Gap.transform.position.z);
    //    }
    //}

    public void _SetGapWidth()
    {
        float CurrentGapWidth = TrialController.GetCurrentGapWidth();
        Gap.transform.localScale = new Vector3(CurrentGapWidth, Gap.transform.localScale.y, Gap.transform.localScale.z);
        Gap.transform.position = new Vector3((StartGapPosX - StartGapScaleX / 2 + CurrentGapWidth / 2), Gap.transform.position.y, Gap.transform.position.z);
    }
}
