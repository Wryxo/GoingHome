using UnityEngine;
using System.Collections;

public class EndGameMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartLevel()
    {
        PlayerStats stats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        stats.RestartLevel();
    }

    public void GoToMainMenu()
    {
        Application.LoadLevel("Menu");
    }
}
