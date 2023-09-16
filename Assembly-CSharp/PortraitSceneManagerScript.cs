using UnityEngine;
using UnityEngine.SceneManagement;

public class PortraitSceneManagerScript : MonoBehaviour
{
	public int X;

	public int Y;

	private void Start()
	{
		X = Screen.currentResolution.width;
		Y = Screen.currentResolution.height;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Screen.SetResolution(X, Y, FullScreenMode.Windowed);
			SceneManager.LoadScene("NewTitleScene");
		}
	}
}
