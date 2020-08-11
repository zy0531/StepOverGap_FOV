using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using Valve.VR;
using Valve.VR.InteractionSystem.Sample;





public class TrialController : MonoBehaviour
{
    private static int condition;
    private static int TrialNumber;
    private static int TotalTrialNumber;
    private static string[][] TrialVariableCross; // 2x2    use array of array, not use multiarray - private static int[,] TrialVariable;
    private static float[] GapWidths;
    private static string FOV;
    private static string Direction;
    private int InstructionCountDown = 1;
    private bool FinishTrialBool = true;
    private bool hasRecorded;

    public GameObject FOVCanvas;
    public GameObject Room;
    public GameObject YesGreenButton;
    public GameObject NoRedButton;

    public GameObject PanelNext;
    public GameObject PanelYesNo;

    public TMP_Text TrialText;

    public SteamVR_Input_Sources handType;


    public GameObject textHintPrefab;
    //public Transform righthandTransform;
    //public Transform VRCamera;

    
    void Awake()
    {
        condition = 0; // 0,1,2,3
        TotalTrialNumber = 0; // [0]1-96
        TrialNumber = 0; // 0-23
        InitiateGapWidths();
        InitiateTrialVariable();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch").GetStateDown(handType))
        {
            if (TotalTrialNumber > 96)
            {
                StartCoroutine(WaitAndQuit(4.0f));
            }
        }
    }

    private IEnumerator WaitAndQuit(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void InitiateTrialVariable()
    {
        // Variable FOV : Natural  [first variable == Natural]
        // Variable FOV : HoloLens [first variable == HoloLens]
        // Variable Direction : 0  [second variable == Direction0]
        // Variable Direction : 90 [second variable == Direction90]
        TrialVariableCross = new string[4][];
        TrialVariableCross[0] = new string[2] { "Natural", "Direction0" };
        TrialVariableCross[1] = new string[2] { "HoloLens", "Direction0" };
        TrialVariableCross[2] = new string[2] { "Natural", "Direction90" };
        TrialVariableCross[3] = new string[2] { "HoloLens", "Direction90" };
        TrialVariableCross = RandomizeArrayT<string[]>(TrialVariableCross);
    }

    private void InitiateGapWidths()
    {
        GapWidths = new float[24];
        for(int i = 0; i < 24; i++)
        {
            if ((i+1) % 8 == 1)
                GapWidths[i] = 0.45f;
            else if ((i + 1) % 8 == 2)
                GapWidths[i] = 0.60f;
            else if ((i + 1) % 8 == 3)
                GapWidths[i] = 0.75f;
            else if ((i + 1) % 8 == 4)
                GapWidths[i] = 0.90f;
            else if ((i + 1) % 8 == 5)
                GapWidths[i] = 1.05f;
            else if ((i + 1) % 8 == 6)
                GapWidths[i] = 1.20f;
            else if ((i + 1) % 8 == 7)
                GapWidths[i] = 1.35f;
            else if ((i + 1) % 8 == 0)
                GapWidths[i] = 1.50f;
        }
            
        GapWidths = RandomizeArray(GapWidths);
    }

    private static float[] RandomizeArray(float[] array)
    {

        for (int i = 0; i < array.Length; i++)
        {
            int random = Random.Range(0, array.Length -1);
            float current = array[i];
            array[i] = array[random];
            array[random] = current;
        }
        return array;
    }

    private static T[] RandomizeArrayT<T>(T[] array)
    {

        for (int i = 0; i < array.Length; i++)
        {
            int random = Random.Range(0, array.Length - 1);
            T current = array[i];
            array[i] = array[random];
            array[random] = current;
        }
        return array;
    }

    public static float GetCurrentGapWidth()
    {
        return GapWidths[TrialNumber];
    }

    public void IncrementTrial()
    {
        TotalTrialNumber++;
        if (TrialNumber < 23)
        {
            TrialNumber++;
        }
        else
            TrialNumber = 0;
    }

    public void EnableHoloLensFOV()
    {
        FOVCanvas.SetActive(true);
    }

    public void DisableHoloLensFOV()
    {
        FOVCanvas.SetActive(false);
    }

    private Quaternion Rotate(GameObject gameObject, float Eular)
    {
         return Quaternion.Euler(0f, Eular, 0f);
    }



    //private void ShowHint()
    //{
    //    Vector3 hintStartPos = righthandTransform.position + (righthandTransform.forward * 0.01f);
    //    Quaternion hintRotation = righthandTransform.rotation; 
    //    GameObject textHintObject = GameObject.Instantiate(textHintPrefab, hintStartPos, hintRotation) as GameObject;
    //    textHintObject.transform.Rotate(0, 180f, 0, Space.Self);
    //    textHintObject.transform.LookAt(VRCamera);
    //    var textCanvas = textHintObject.GetComponentInChildren<Canvas>();
    //    var Text = textCanvas.GetComponentInChildren<Text>();
    //    Text.text = "use your index finger to pull trigger to continue";
    //    Destroy(textHintObject, 3f);
    //}

    ////attach to "hoverbutton" - RED & GREEN respectively 
    //public void onButtonPressedRecord()
    //{
    //    if(!hasRecorded)
    //    {
    //        Log_Control.logToFile(System.DateTime.Now.ToString());
    //        Log_Control.logToFile("TotalTrialNumber:" + TotalTrialNumber);
    //        Log_Control.logToFile("TrialNumber:" + TrialNumber);
    //        Log_Control.logToFile("FOV:" + FOV);
    //        Log_Control.logToFile("Direction:" + Direction);
    //        Log_Control.logToFile("GapWidths:" + GetCurrentGapWidth());
    //        //if (NoRedButton.GetComponent<ButtonEffect>().CrossableFeedback)
    //        //{
    //        //    Debug.Log(NoRedButton.name);
    //        //    Debug.Log(NoRedButton.GetComponent<ButtonEffect>().PressNumber);
    //        //    Log_Control.logToFile("Yes/No:" + NoRedButton.name);
    //        //}
    //        //if (YesGreenButton.GetComponent<ButtonEffect>().CrossableFeedback)
    //        //{
    //        //    Debug.Log(YesGreenButton.name);
    //        //    Debug.Log(YesGreenButton.GetComponent<ButtonEffect>().PressNumber);
    //        //    Log_Control.logToFile("Yes/No:" + YesGreenButton.name);
    //        //}
    //        hasRecorded = true;
    //        //ShowHint();
    //    }
        
    //    TrialText.text = "You finished this trial! \nLet's pull the trigger on hand controller to start next tiral!";
    //    FinishTrialBool = true;
    //}


    public void OnClickNext()
    {
        if ((TotalTrialNumber-1)%24 == 0)
        {
            Log_Control.logToFile(System.Environment.NewLine);
            FOV = TrialVariableCross[condition][0];
            Direction = TrialVariableCross[condition][1];
            //if(TotalTrialNumber == 25 || TotalTrialNumber == 49 || TotalTrialNumber == 73)
            condition++; // initial==0  0-3
        }
        if (TotalTrialNumber == 0)
        {
            TotalTrialNumber++;
            TrialText.text = "Trial: " + TotalTrialNumber + "\nAlign the tip of your toe to the red line on the floor. \nWhen you are ready for this trial, Click on \"Next\". ";
        }
        else
        {
            Log_Control.logToFile(System.DateTime.Now.ToString());
            Log_Control.logToFile("TotalTrialNumber:" + TotalTrialNumber);
            Log_Control.logToFile("TrialNumber:" + TrialNumber);
            Log_Control.logToFile("FOV:" + FOV);
            Log_Control.logToFile("Direction:" + Direction);
            Log_Control.logToFile("GapWidths:" + GetCurrentGapWidth());

            PanelNext.SetActive(false);
            PanelYesNo.SetActive(true);
        }


        //change conditions
        if (FOV == "Natural")
        {
            DisableHoloLensFOV();
        }
        else if (FOV == "HoloLens")
        {
            EnableHoloLensFOV();
        }

        if (Direction == "Direction0")
        {
            Room.transform.rotation = Rotate(Room, 0);
        }
        else if (Direction == "Direction90")
        {
            Room.transform.rotation = Rotate(Room, 90);
        }

    }
    public void OnClickYes()
    {
        //Debug.Log("Yes");
        Log_Control.logToFile("Yes" + System.Environment.NewLine);
        IncrementTrial();
        TrialText.text = "Trial: " + TotalTrialNumber + "\nAlign the tip of your toe to the red line on the floor. \nWhen you are ready for this trial, Click on \"Next\". ";
        PanelYesNo.SetActive(false);
        PanelNext.SetActive(true);
        if(TotalTrialNumber == 97)
        {
            TrialText.text = "You have finished all trials! Thanks for your participation!";
        }
    }

    public void OnClickNo()
    {
        //Debug.Log("No");
        Log_Control.logToFile("No" + System.Environment.NewLine);
        IncrementTrial();
        TrialText.text = "Trial: " + TotalTrialNumber + "\nAlign the tip of your toe to the red line on the floor. \nWhen you are ready for this trial, Click on \"Next\". ";
        PanelYesNo.SetActive(false);
        PanelNext.SetActive(true);
        if (TotalTrialNumber == 97)
        {
            TrialText.text = "You have finished all trials! Thanks for your participation!";
        }
    }

}

