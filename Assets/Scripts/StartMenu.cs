using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Spiel starten
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Spiel beenden
    public void QuitGame()
    {
        Application.Quit();
    }
}