using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public int puntos=0;

	public static bool created;

    public GameObject pauseIndicator;

	private static GameController instance;

	public static GameController getInstance(){
		return instance;
	}

	public GameObject enemy;
	public GameObject position;

    void Awake()
    {
		if (!created)
		{
			DontDestroyOnLoad(this.gameObject);
			created = true;
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
        pauseIndicator.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RestartLevel();
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            pauseIndicator.SetActive(true);
        }
        else
        {
            pauseIndicator.SetActive(false);
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
    }

	public void RestartLevel()
	{
		puntos = 0;
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
	}

	public void IncreaseLevel()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		puntos++;
	}
}
