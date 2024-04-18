using UnityEngine;

public class PostcardScript : MonoBehaviour
{
	public HomeYandereScript HomeYandere;

	public PostcardScript OtherPostcard;

	public PromptBarScript PromptBar;

	public PromptScript Prompt;

	public Transform Postcard;

	public Renderer Front;

	public Renderer Back;

	public UILabel Label;

	public UIPanel Text;

	public GameObject[] HiddenMoney;

	public Texture[] Fronts;

	public Texture[] Backs;

	public string[] Texts;

	public bool CanAdvance;

	public bool ShowText;

	public bool Show;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			base.gameObject.SetActive(value: false);
		}
		else if (base.transform.position.y > -5f && DateGlobals.Week == 1)
		{
			Prompt.Label[0].text = "     Note from Mom";
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			OtherPostcard.enabled = false;
			UpdatePostcard();
			Postcard.transform.localEulerAngles = new Vector3(-75f, -90f, 90f);
			HomeYandere.CharacterAnimation.CrossFade(HomeYandere.IdleAnim);
			HomeYandere.CanMove = false;
			PromptBar.ClearButtons();
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[5].text = "Rotate";
			PromptBar.UpdateButtons();
			PromptBar.Show = true;
			Prompt.Hide();
			Prompt.enabled = false;
			Show = true;
		}
		if (ShowText)
		{
			Text.alpha = Mathf.MoveTowards(Text.alpha, 1f, Time.deltaTime);
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				PromptBar.Label[1].text = "Exit";
				PromptBar.Label[5].text = "Rotate";
				PromptBar.UpdateButtons();
				ShowText = false;
			}
			return;
		}
		Text.alpha = Mathf.MoveTowards(Text.alpha, 0f, Time.deltaTime);
		if (Show)
		{
			Postcard.transform.localPosition = Vector3.Lerp(Postcard.transform.localPosition, new Vector3(0f, 0.05f, 1f), Time.deltaTime * 10f);
			if (Input.GetAxis("Horizontal") > 0f || Input.GetKey("right"))
			{
				if (Input.GetAxis("Horizontal") > 0f)
				{
					Postcard.transform.localEulerAngles += new Vector3(0f, 0f, Time.deltaTime * 360f * Input.GetAxis("Horizontal"));
				}
				else
				{
					Postcard.transform.localEulerAngles += new Vector3(0f, 0f, Time.deltaTime * 360f);
				}
			}
			else if (Input.GetAxis("Horizontal") < 0f || Input.GetKey("left"))
			{
				if (Input.GetAxis("Horizontal") < 0f)
				{
					Postcard.transform.localEulerAngles += new Vector3(0f, 0f, Time.deltaTime * 360f * Input.GetAxis("Horizontal"));
				}
				else
				{
					Postcard.transform.localEulerAngles -= new Vector3(0f, 0f, Time.deltaTime * 360f);
				}
			}
			if (Postcard.transform.localEulerAngles.z > 225f && Postcard.transform.localEulerAngles.z < 315f)
			{
				PromptBar.Label[0].text = "Read";
				PromptBar.UpdateButtons();
				CanAdvance = true;
			}
			else
			{
				PromptBar.Label[0].text = "";
				PromptBar.UpdateButtons();
				CanAdvance = false;
			}
			if (Input.GetButtonDown(InputNames.Xbox_A) && CanAdvance)
			{
				PromptBar.Label[0].text = "";
				PromptBar.Label[1].text = "Back";
				PromptBar.Label[5].text = "";
				PromptBar.UpdateButtons();
				ShowText = true;
				if (HomeYandere.transform.position.y > -5f && HiddenMoney[DateGlobals.Week] != null)
				{
					HiddenMoney[DateGlobals.Week].SetActive(value: true);
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				OtherPostcard.enabled = true;
				HomeYandere.CanMove = true;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				Prompt.enabled = true;
				Show = false;
			}
		}
		else
		{
			Postcard.transform.localPosition = Vector3.Lerp(Postcard.transform.localPosition, new Vector3(0f, -1.1f, 1f), Time.deltaTime * 5f);
		}
	}

	private void UpdatePostcard()
	{
		if (base.transform.position.y > -5f)
		{
			if (DateGlobals.Week == 1)
			{
				Postcard.localScale = new Vector3(0.5f, 0.725f, 0.725f);
			}
			Front.material.color = new Color(0.5f, 0.5f, 0.5f, 1f);
			Back.material.color = new Color(0.5f, 0.5f, 0.5f, 1f);
			Front.material.mainTexture = Fronts[DateGlobals.Week];
			Back.material.mainTexture = Backs[DateGlobals.Week];
			Label.text = Texts[DateGlobals.Week];
		}
		else
		{
			Postcard.localScale = new Vector3(0.725f, 0.725f, 0.725f);
			Front.material.color = new Color(1f, 1f, 1f, 1f);
			Back.material.color = new Color(1f, 1f, 1f, 1f);
			Front.material.mainTexture = Fronts[0];
			Back.material.mainTexture = Backs[0];
			Label.text = Texts[0];
		}
		Label.text = Label.text.Replace('@', '\n');
	}
}
