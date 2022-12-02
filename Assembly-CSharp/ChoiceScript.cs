using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoiceScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public Transform Highlight;

	public UISprite Darkness;

	public int Selected;

	public int Phase;

	private void Start()
	{
		Darkness.color = new Color(1f, 1f, 1f, 1f);
	}

	private void Update()
	{
		Highlight.transform.localPosition = Vector3.Lerp(Highlight.transform.localPosition, new Vector3(-360 + 720 * Selected, Highlight.transform.localPosition.y, Highlight.transform.localPosition.z), Time.deltaTime * 10f);
		if (Phase == 0)
		{
			Darkness.color = new Color(1f, 1f, 1f, Mathf.MoveTowards(Darkness.color.a, 0f, Time.deltaTime * 2f));
			if (Darkness.color.a == 0f)
			{
				Phase++;
			}
		}
		else if (Phase == 1)
		{
			if (InputManager.TappedLeft)
			{
				Darkness.color = new Color(1f, 1f, 1f, 0f);
				Selected = 0;
			}
			else if (InputManager.TappedRight)
			{
				Darkness.color = new Color(0f, 0f, 0f, 0f);
				Selected = 1;
			}
			if (Input.GetButtonDown("A"))
			{
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			Darkness.color = new Color(Darkness.color.r, Darkness.color.g, Darkness.color.b, Mathf.MoveTowards(Darkness.color.a, 1f, Time.deltaTime * 2f));
			if (Darkness.color.a == 1f)
			{
				GameGlobals.LoveSick = Selected == 1;
				SceneManager.LoadScene("NewTitleScene");
			}
		}
	}
}
