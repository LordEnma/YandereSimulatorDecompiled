using UnityEngine;
using UnityEngine.SceneManagement;

public class DisclaimerScript : MonoBehaviour
{
	public InputDeviceScript InputDevice;

	public UISprite Darkness;

	public bool Fade;

	private void Start()
	{
		Darkness.alpha = 1f;
	}

	private void Update()
	{
		if (!Fade)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha < 0.0001f)
			{
				if (Input.GetKeyDown(KeyCode.Escape))
				{
					Application.Quit();
				}
				else if (Input.anyKeyDown)
				{
					Darkness.color = new Color(1f, 1f, 1f, 0f);
					Fade = true;
				}
			}
		}
		else
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
			if (Darkness.alpha > 0.999f)
			{
				GameGlobals.LastInputType = (int)InputDevice.Type;
				SceneManager.LoadScene("WelcomeScene");
			}
		}
	}
}
