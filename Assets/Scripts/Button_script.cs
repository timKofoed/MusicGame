using UnityEngine;
using System.Collections;

public class Button_script : MonoBehaviour {

    public string LevelToLoad;



    void OnTouchDown()
        {
            Application.LoadLevel  ("" + LevelToLoad);
        }

}
