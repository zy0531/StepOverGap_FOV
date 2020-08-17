using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;



public class Log_Control : MonoBehaviour {

    public string initialFile;
    public static string fileName;

    // Send data to Google Form : FOVData
    [SerializeField]
    private static string BASE_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLScgeLOsoFd9O_bPiv_McYrf_JC2pnZzL7Z3Z2PTVry60EhoeQ/formResponse";
    [SerializeField]
    private static string entryID = "entry.528852114";



    //Create File in local
    void Awake()
    {
        if(SceneManager.GetActiveScene().name == "StartScene")
        {
            fileName = initialFile;
            if (!File.Exists(fileName))
            {
                var logFile = File.CreateText(fileName);
                logFile.WriteLine(System.DateTime.Now + System.Environment.NewLine);
                logFile.Close();
            }
            else
            {
                File.AppendAllText(fileName, System.Environment.NewLine + System.Environment.NewLine); 
                File.AppendAllText(fileName, "New Experiment"+ System.Environment.NewLine);
                File.AppendAllText(fileName, System.DateTime.Now + System.Environment.NewLine);
            }
        }
    }

    //Write to File in local
    public static void logToFile(string text){

		File.AppendAllText (fileName, text + System.Environment.NewLine);

	}







    //post data to Google Form 
    public static IEnumerator Post(string data)
    {
        WWWForm form = new WWWForm();
        form.AddField(entryID, data);

        UnityWebRequest www = UnityWebRequest.Post(BASE_URL, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    public static string readStringFromFile(string filename)//, int lineIndex )
    {
        if (File.Exists(filename))
        {
            FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file);

            string str = null;
            //str = sr.ReadLine();
            str = File.ReadAllText(filename);

            sr.Close();
            file.Close();

            return str;
        }

        else
        {
            return null;
        }
    }
}
