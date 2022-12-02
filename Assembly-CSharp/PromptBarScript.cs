using UnityEngine;

public class PromptBarScript : MonoBehaviour
{
	public UISprite[] Button;

	public UILabel[] Label;

	public UILabel[] ButtonLabel;

	public UIPanel Panel;

	public bool Show;

	public int ID;

	private void Awake()
	{
		base.transform.localPosition = new Vector3(base.transform.localPosition.x, -627f, base.transform.localPosition.z);
		for (ID = 0; ID < Label.Length; ID++)
		{
			Label[ID].text = string.Empty;
		}
	}

	private void Start()
	{
		UpdateButtons();
	}

	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (!Show)
		{
			if (!Panel.enabled)
			{
				return;
			}
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, -628f, t), base.transform.localPosition.z);
			if (base.transform.localPosition.y < -627f)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, -628f, base.transform.localPosition.z);
				if (Panel != null)
				{
					Panel.enabled = false;
				}
			}
		}
		else
		{
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, -528.5f, t), base.transform.localPosition.z);
		}
	}

	public void UpdateButtons()
	{
		if (Panel != null)
		{
			Panel.enabled = true;
		}
		for (ID = 0; ID < Label.Length; ID++)
		{
			Button[ID].enabled = Label[ID].text.Length > 0;
			ButtonLabel[ID].enabled = Label[ID].text.Length > 0;
		}
	}

	public void ClearButtons()
	{
		for (ID = 0; ID < Label.Length; ID++)
		{
			ButtonLabel[ID].enabled = false;
			Label[ID].text = string.Empty;
			Button[ID].enabled = false;
		}
	}
}
