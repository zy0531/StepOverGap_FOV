using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadNewScene : MonoBehaviour
{
    [SerializeField] private InputField NameInputField;
    [SerializeField] private InputField AgeInputField;
    [SerializeField] private Dropdown GenderDropdown;
    [SerializeField] private InputField HeightInputField;
    [SerializeField] private InputField EyeHeightInputField;
    [SerializeField] private InputField LegLengthInputField;
    [SerializeField] private InputField MaxStrideInputField;

    [SerializeField] private Dropdown Condition1Dropdown;
    [SerializeField] private Dropdown Condition2Dropdown;
    [SerializeField] private Dropdown Condition3Dropdown;
    [SerializeField] private Dropdown Condition4Dropdown;

    public static string[][] TrialVariableCross; // 2x2    use array of array, not use multiarray - private static int[,] TrialVariable;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToVRScene()
    {
        ReadUIInput();
        InitializeOrder();
        Log_Control.logToFile("VRScene Start");
        SceneManager.LoadScene("VRScene");
    }

    private void ReadUIInput()
    {
        Log_Control.logToFile("Name/ID:  " + NameInputField.text);
        Log_Control.logToFile("Age:  " + AgeInputField.text);
        Log_Control.logToFile("Gender:  " + GenderDropdown.options[GenderDropdown.value].text);
        Log_Control.logToFile("Height:  " + HeightInputField.text);
        Log_Control.logToFile("Eye Height:  " + EyeHeightInputField.text);
        Log_Control.logToFile("Leg Length:  " + LegLengthInputField.text);
        Log_Control.logToFile("Max Stride:  " + MaxStrideInputField.text);

        Log_Control.logToFile("Condition 1:  " + Condition1Dropdown.options[Condition1Dropdown.value].text);
        Log_Control.logToFile("Condition 2:  " + Condition2Dropdown.options[Condition2Dropdown.value].text);
        Log_Control.logToFile("Condition 3:  " + Condition3Dropdown.options[Condition3Dropdown.value].text);
        Log_Control.logToFile("Condition 4:  " + Condition4Dropdown.options[Condition4Dropdown.value].text);

    }

    private void InitializeOrder()
    {
        TrialVariableCross = new string[4][];
        switch(Condition1Dropdown.value)
        {
            case 0:
                TrialVariableCross[0] = new string[2] { "Natural", "Direction0" };
                break;
            case 1:
                TrialVariableCross[0] = new string[2] { "HoloLens", "Direction0" };
                break;
            case 2:
                TrialVariableCross[0] = new string[2] { "Natural", "Direction90" };
                break;
            case 3:
                TrialVariableCross[0] = new string[2] { "HoloLens", "Direction90" };
                break;

        }
        switch (Condition2Dropdown.value)
        {
            case 0:
                TrialVariableCross[1] = new string[2] { "Natural", "Direction0" };
                break;
            case 1:
                TrialVariableCross[1] = new string[2] { "HoloLens", "Direction0" };
                break;
            case 2:
                TrialVariableCross[1] = new string[2] { "Natural", "Direction90" };
                break;
            case 3:
                TrialVariableCross[1] = new string[2] { "HoloLens", "Direction90" };
                break;

        }
        switch (Condition3Dropdown.value)
        {
            case 0:
                TrialVariableCross[2] = new string[2] { "Natural", "Direction0" };
                break;
            case 1:
                TrialVariableCross[2] = new string[2] { "HoloLens", "Direction0" };
                break;
            case 2:
                TrialVariableCross[2] = new string[2] { "Natural", "Direction90" };
                break;
            case 3:
                TrialVariableCross[2] = new string[2] { "HoloLens", "Direction90" };
                break;

        }
        switch (Condition4Dropdown.value)
        {
            case 0:
                TrialVariableCross[3] = new string[2] { "Natural", "Direction0" };
                break;
            case 1:
                TrialVariableCross[3] = new string[2] { "HoloLens", "Direction0" };
                break;
            case 2:
                TrialVariableCross[3] = new string[2] { "Natural", "Direction90" };
                break;
            case 3:
                TrialVariableCross[3] = new string[2] { "HoloLens", "Direction90" };
                break;

        }
    }

    
}
