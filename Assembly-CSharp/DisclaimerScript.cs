using UnityEngine;
using UnityEngine.SceneManagement;

public class DisclaimerScript : MonoBehaviour
{
	public InputDeviceScript InputDevice;

	public UISprite Darkness;

	public bool AnyButton;

	public bool Fade;

	public int SceneID = 1;

	private void Start()
	{
		Darkness.alpha = 1f;
	}

	private void Update()
	{
		if (!Fade)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime * 2f);
			if (!(Darkness.alpha < 0.0001f))
			{
				return;
			}
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
			else if ((AnyButton && Input.anyKeyDown) || (!AnyButton && Input.GetButtonDown(InputNames.Xbox_A)))
			{
				if (SceneID == 2)
				{
					Darkness.color = new Color(1f, 1f, 1f, 0f);
				}
				Fade = true;
			}
			return;
		}
		Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime * 2f);
		if (Darkness.alpha > 0.999f)
		{
			GameGlobals.LastInputType = (int)InputDevice.Type;
			if (SceneID == 1)
			{
				SceneManager.LoadScene("YouTubeWarningScene");
			}
			else
			{
				SceneManager.LoadScene("WelcomeScene");
			}
		}
	}
}
