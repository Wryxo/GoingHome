using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel1()
    {
        Application.LoadLevel("Tutorial1");
    }

    public void Exit()
    {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
        Application.Quit();
    }

}
