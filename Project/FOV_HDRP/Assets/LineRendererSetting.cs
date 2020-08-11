using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

// https://learn.unity.com/tutorial/creating-a-vr-menu-2019-2#5e273940edbc2a030d3d3ef1
public class LineRendererSetting : MonoBehaviour
{
    [SerializeField] LineRenderer rend;
    Vector3[] points;
    public LayerMask layerMask;

    //public GameObject panel;
    private Button btn;
    //private Collider hitCollider;

    public SteamVR_Input_Sources handType;


    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<LineRenderer>();
        points = new Vector3[2];
        points[0] = Vector3.zero;
        points[1] = transform.position + new Vector3(0, 0, 10);
        rend.SetPositions(points);
        rend.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (AlignLineRenderer(rend) && SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch").GetStateDown(handType))
        //if (AlignLineRenderer(rend) && Input.GetAxis("Submit")>0)
        {
            Debug.Log(btn.ToString());
            btn.onClick.Invoke();
        }

    }

    public bool AlignLineRenderer(LineRenderer rend)
    {
        bool hitBtn = false;
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, layerMask))
        {
            //points[1] = transform.forward + new Vector3(0, 0, hit.distance);
            points[1] = Vector3.zero + new Vector3(0, 0, hit.distance);
            rend.startColor = new Color32(0, 245, 255, 255);
            rend.endColor = new Color32(128, 255, 128, 255);
            btn = hit.collider.gameObject.GetComponent<Button>();
            hitBtn = true;
        }
        else
        {
            //points[1] = transform.forward + new Vector3(0, 0, 20);
            points[1] = Vector3.zero + new Vector3(0, 0, 10);
            rend.startColor = Color.white;
            rend.endColor = Color.white;
            hitBtn = false;
        }
        rend.SetPositions(points);
        rend.material.color = rend.startColor;
        return hitBtn;
    }
}
