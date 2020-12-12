using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class TestFOV : MonoBehaviour
{

    [SerializeField] private TMP_Text Height;
    [SerializeField] private TMP_Text Width;
    [SerializeField] private TMP_Text VerticalFOV;
    [SerializeField] private TMP_Text HorizontalFOV;
    [SerializeField] private GameObject Dis5m;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("up")){
            transform.localScale = new Vector3(
                transform.localScale.x,
                transform.localScale.y,
                transform.localScale.z + 0.05f
            );
            Height.text = "Height : " + transform.localScale.z.ToString() + " m";
            var NewVerticalFOV = 2.0f * Mathf.Atan((transform.localScale.z / 2.0f) / Dis5m.transform.localScale.y);
            VerticalFOV.text = "Vertical FOV : " + NewVerticalFOV.ToString("F2") + "rad / " + (NewVerticalFOV * Mathf.Rad2Deg).ToString("F2")+"deg";
        }
        if (Input.GetKeyUp("down"))
        {
            transform.localScale = new Vector3(
                transform.localScale.x,
                transform.localScale.y,
                transform.localScale.z - 0.05f
            );
            Height.text = "Height : " + transform.localScale.z.ToString() + " m";
            var NewVerticalFOV = 2.0f * Mathf.Atan((transform.localScale.z / 2.0f) / Dis5m.transform.localScale.y);
            VerticalFOV.text = "Vertical FOV : " + NewVerticalFOV.ToString("F2") + "rad / " + (NewVerticalFOV * Mathf.Rad2Deg).ToString("F2") + "deg";
        }
        if (Input.GetKeyUp("right"))
        {
            transform.localScale = new Vector3(
                transform.localScale.x + 0.05f,
                transform.localScale.y,
                transform.localScale.z
            );
            Width.text = "Width : " + transform.localScale.x.ToString() + " m";
            var NewHorizontalFOV = 2.0f * Mathf.Atan((transform.localScale.x / 2.0f) / Dis5m.transform.localScale.y);
            HorizontalFOV.text = "Horizontal FOV : " + NewHorizontalFOV.ToString("F2") + "rad / " + (NewHorizontalFOV * Mathf.Rad2Deg).ToString("F2") + "deg";
        }
        if (Input.GetKeyUp("left"))
        {
            transform.localScale = new Vector3(
                transform.localScale.x - 0.05f,
                transform.localScale.y,
                transform.localScale.z
            );
            Width.text = "Width : " + transform.localScale.x.ToString() + " m";
            var NewHorizontalFOV = 2.0f * Mathf.Atan((transform.localScale.x / 2.0f) / Dis5m.transform.localScale.y);
            HorizontalFOV.text = "Horizontal FOV : " + NewHorizontalFOV.ToString("F2") + "rad / " + (NewHorizontalFOV * Mathf.Rad2Deg).ToString("F2") + "deg";
        }
    }
}
