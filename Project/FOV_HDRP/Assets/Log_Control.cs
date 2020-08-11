using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Log_Control : MonoBehaviour {

	public string initialFile;
	static string fileName;

	void Awake(){

		fileName = initialFile;
		var logFile = File.CreateText (fileName);
		logFile.WriteLine (System.DateTime.Now + System.Environment.NewLine);
		logFile.Close ();

	}

	public static void logToFile(string text){

		File.AppendAllText (fileName, text + System.Environment.NewLine);

	}
}
