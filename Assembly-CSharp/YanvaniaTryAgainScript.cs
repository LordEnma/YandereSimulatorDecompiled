using UnityEngine;
using UnityEngine.SceneManagement;

public class YanvaniaTryAgainScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public GameObject ButtonEffect;

	public Transform Highlight;

	public UISprite Darkness;

	public bool FadeOut;

	public int Selected = 1;

	private void Start()
	{
		base.transform.localScale = Vector3.zero;
	}

	private void Update()
	{
		if (!FadeOut)
		{
			if (base.transform.localScale.x > 0.9f)
			{
				if (InputManager.TappedLeft)
				{
					Selected = 1;
				}
				if (InputManager.TappedRight)
				{
					Selected = 2;
				}
				if (Selected == 1)
				{
					Highlight.localPosition = new Vector3(Mathf.Lerp(Highlight.localPosition.x, -100f, Time.deltaTime * 10f), Highlight.localPosition.y, Highlight.localPosition.z);
					Highlight.localScale = new Vector3(Mathf.Lerp(Highlight.localScale.x, -1f, Time.deltaTime * 10f), Highlight.localScale.y, Highlight.localScale.z);
				}
				else
				{
					Highlight.localPosition = new Vector3(Mathf.Lerp(Highlight.localPosition.x, 100f, Time.deltaTime * 10f), Highlight.localPosition.y, Highlight.localPosition.z);
					Highlight.localScale = new Vector3(Mathf.Lerp(Highlight.localScale.x, 1f, Time.deltaTime * 10f), Highlight.localScale.y, Highlight.localScale.z);
				}
				if (Input.GetButtonDown(InputNames.Xbox_A) || Input.GetKeyDown("z") || Input.GetKeyDown("x"))
				{
					GameObject obj = Object.Instantiate(ButtonEffect, Highlight.position, Quaternion.identity);
					obj.transform.parent = Highlight;
					obj.transform.localPosition = Vector3.zero;
					FadeOut = true;
				}
			}
			return;
		}
		Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Darkness.color.a + Time.deltaTime);
		if (Darkness.color.a >= 1f)
		{
			if (Selected == 1)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
			else
			{
				SceneManager.LoadScene("YanvaniaTitleScene");
			}
		}
	}
}
