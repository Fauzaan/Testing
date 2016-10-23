using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public GameObject HostUI;
	public bool paused = false;

	void Start()
	{
		HostUI.SetActive (false);
	}

	void Update()
	{
		if (Input.GetButtonDown ("Pause")) {
			paused = !paused;
		}

		if (paused) 
		{
			HostUI.SetActive (true);
			Time.timeScale = 0;
		}
		if (!paused) {
			HostUI.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Resume()
	{
		paused = false;
	}

	public void Restart()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void mainMenu()
	{
		Application.LoadLevel (1);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
