using UnityEngine;
using UnityEngine.SceneManagement;

public class NoAnimationWarningScript : MonoBehaviour
{
	public UISprite Darkness;

	public bool FadeOut;

	public float Alpha;

	private void Start()
	{
		Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	private void Update()
	{
		if (!FadeOut)
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime);
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
			if (Alpha == 0f && Input.GetButtonDown("A"))
			{
				FadeOut = true;
			}
		}
		else
		{
			Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime);
			Darkness.color = new Color(0f, 0f, 0f, Alpha);
			if (Alpha == 1f)
			{
				SceneManager.LoadScene("BusStopScene");
			}
		}
	}
}
