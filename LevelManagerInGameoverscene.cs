using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class LevelManagerInGameoverscene : MonoBehaviour
{
    public void startgame()
    {
        SceneManager.LoadScene("WARIIII");
    }

    public void quit()
    {
        Application.Quit();
    }


}
