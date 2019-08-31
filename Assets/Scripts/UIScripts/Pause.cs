using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Canvas GameCanvas;
    public Canvas PauseCanvas;
    public bool IsPause;
    private void Start()
    {
        IsPause = false;
    }
    void Update()
    {
        if (Input.GetButton("Cancel") && !IsPause)
        {
            IsPause = true;
            Time.timeScale = 0;
            GameCanvas.gameObject.SetActive(false);
            PauseCanvas.gameObject.SetActive(true);
        }
    }
    public void ContinueGame()
    {
        IsPause = false;
        Time.timeScale = 1;
        GameCanvas.gameObject.SetActive(true);
        PauseCanvas.gameObject.SetActive(false);
    }
    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
