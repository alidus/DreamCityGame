using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class logicScript : MonoBehaviour {
    //console
    [SerializeField]
    Text console;

    List<string> consoleBuffer = new List<string>();
    int maxConsoleStrings = 5;

	// Use this for initialization
	void Start () {
    
        }
	
	// Update is called once per frame
	void Update () {

            

        }


    public void ClearConsole ()
        {
        consoleBuffer.Clear();
        console.text = "";
        }
   public void PrintToConsole(string msg)
        {
        if (consoleBuffer.Count >= maxConsoleStrings)
            {
            print("1");
            consoleBuffer.RemoveAt(0);
            }

        consoleBuffer.Add(msg);
        string resultString = "";
        foreach (string element in consoleBuffer)
            {
            resultString += element + "\n";
            }

        print(resultString);

        console.text = resultString;

        }
}
