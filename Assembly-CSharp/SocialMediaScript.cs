using UnityEngine;

public class SocialMediaScript : MonoBehaviour
{
	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public GameObject ErrorMessage;

	public GameObject Menu;

	public Transform CurrentParent;

	public UILabel HeaderLabel;

	public UILabel DescLabel;

	public float[] ScrollLimitsH;

	public float[] ScrollLimits;

	public UITexture[] Shadows;

	public UITexture[] Icons;

	public GameObject[] Blogs;

	public bool[] BlogKnown;

	public string[] HeaderText;

	public string[] DescText;

	public float ScrollLimitH;

	public float ScrollLimit;

	public bool ViewingBlog;

	public int Selected;

	public int Column;

	public int Row;

	public Transform[] SocialMediaParents;

	public GameObject[] SocialMediaPosts;

	public string[] Titles;

	public string[] Dates;

	public string[] Texts;

	public Texture[] TraitImages;

	public string[] TraitNames;

	public int[] TraitIDs;

	public int[] TopicSet1;

	public int[] TopicSet2;

	public int[] TopicSet3;

	public int[] TopicSet4;

	public int[] TopicSet5;

	private void Start()
	{
		Menu.SetActive(value: true);
		Blogs[1].SetActive(value: false);
		Blogs[2].SetActive(value: false);
		Blogs[3].SetActive(value: false);
		Blogs[4].SetActive(value: false);
		if (!(PromptBar != null))
		{
			return;
		}
		UpdateHighlight();
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		for (int i = 1; i < 6; i++)
		{
			GameObject obj = Object.Instantiate(SocialMediaPosts[1], SocialMediaParents[1].position, Quaternion.identity);
			obj.transform.parent = SocialMediaParents[1];
			obj.transform.localPosition = new Vector3(0f, (i - 1) * -525, 0f);
			obj.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			obj.transform.localScale = new Vector3(1f, 1f, 1f);
			SocialMediaPostScript component = obj.GetComponent<SocialMediaPostScript>();
			component.SocialMedia = this;
			component.ID = i;
			switch (i)
			{
			case 1:
				component.Topics = TopicSet1;
				break;
			case 2:
				component.Topics = TopicSet2;
				break;
			case 3:
				component.Topics = TopicSet3;
				break;
			case 4:
				component.Topics = TopicSet4;
				break;
			case 5:
				component.Topics = TopicSet5;
				break;
			}
		}
		for (int i = 1; i < 7; i++)
		{
			GameObject obj2 = Object.Instantiate(SocialMediaPosts[2], SocialMediaParents[2].position, Quaternion.identity);
			obj2.transform.parent = SocialMediaParents[2];
			obj2.transform.localPosition = new Vector3(29.5f, -118.5f + (float)((i - 1) * -461), 0f);
			obj2.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			obj2.transform.localScale = new Vector3(1f, 1f, 1f);
			SocialMediaPostScript component2 = obj2.GetComponent<SocialMediaPostScript>();
			component2.SocialMedia = this;
			component2.ID = i;
		}
	}

	private void Update()
	{
		if (!ViewingBlog)
		{
			for (int i = 1; i < Icons.Length; i++)
			{
				if (i != Selected)
				{
					Icons[i].transform.localScale = Vector3.Lerp(Icons[i].transform.localScale, new Vector3(1f, 1f, 1f), Time.unscaledDeltaTime * 10f);
				}
				else
				{
					Icons[i].transform.localScale = Vector3.Lerp(Icons[i].transform.localScale, new Vector3(1.5f, 1.5f, 1.5f), Time.unscaledDeltaTime * 10f);
				}
			}
			if (PauseScreen.InputManager.TappedRight || PauseScreen.InputManager.TappedLeft)
			{
				if (Column == 1)
				{
					Column = 2;
				}
				else
				{
					Column = 1;
				}
				UpdateHighlight();
			}
			else if (PauseScreen.InputManager.TappedUp || PauseScreen.InputManager.TappedDown)
			{
				if (Row == 1)
				{
					Row = 2;
				}
				else
				{
					Row = 1;
				}
				UpdateHighlight();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (BlogKnown[Selected])
				{
					PromptBar.ClearButtons();
					PromptBar.Label[1].text = "Back";
					PromptBar.Label[2].text = "Zoom";
					PromptBar.Label[3].text = "Move Phone";
					PromptBar.Label[4].text = "Scroll";
					PromptBar.UpdateButtons();
					CurrentParent = SocialMediaParents[Selected];
					ScrollLimitH = ScrollLimitsH[Selected];
					ScrollLimit = ScrollLimits[Selected];
					Blogs[Selected].SetActive(value: true);
					Menu.SetActive(value: false);
					ViewingBlog = true;
					if (Selected == 4 && !PauseScreen.Police.EndOfDay.LearnedRival2Info[2])
					{
						PauseScreen.Police.EndOfDay.LearnedRival2Info[2] = true;
						PauseScreen.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
					}
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[1].text = "Exit";
				PromptBar.Label[4].text = "Choose";
				PromptBar.Label[5].text = "Choose";
				PromptBar.UpdateButtons();
				PauseScreen.MainMenu.SetActive(value: true);
				PauseScreen.PressedB = true;
				base.gameObject.SetActive(value: false);
			}
			return;
		}
		if (PauseScreen.InputManager.DPadUp || Input.GetKey("w") || Input.GetKey("up") || Input.GetAxis("Vertical") > 0.5f || PauseScreen.InputManager.StickUp)
		{
			if (Selected != 3)
			{
				CurrentParent.localPosition -= new Vector3(0f, Time.unscaledDeltaTime * 1000f, 0f);
				if (Selected == 1)
				{
					if (CurrentParent.localPosition.y < 150f)
					{
						CurrentParent.localPosition = new Vector3(0f, 150f, 0f);
					}
				}
				else if (CurrentParent.localPosition.y < 0f)
				{
					CurrentParent.localPosition = new Vector3(0f, 0f, 0f);
				}
			}
		}
		else if ((PauseScreen.InputManager.DPadDown || Input.GetKey("s") || Input.GetKey("down") || Input.GetAxis("Vertical") < -0.5f || PauseScreen.InputManager.StickDown) && Selected != 3)
		{
			CurrentParent.localPosition += new Vector3(0f, Time.unscaledDeltaTime * 1000f, 0f);
			if (CurrentParent.localPosition.y > ScrollLimit)
			{
				CurrentParent.localPosition = new Vector3(0f, ScrollLimit, 0f);
			}
		}
		if ((PauseScreen.InputManager.DPadLeft || Input.GetKey("a") || Input.GetKey("left") || Input.GetAxis("Horizontal") < -0.5f || PauseScreen.InputManager.StickLeft) && Selected == 3)
		{
			CurrentParent.localPosition += new Vector3(Time.unscaledDeltaTime * 1000f, 0f, 0f);
			if (CurrentParent.localPosition.x > 0f)
			{
				CurrentParent.localPosition = new Vector3(0f, 0f, 0f);
			}
		}
		if (PauseScreen.InputManager.DPadRight || Input.GetKey("d") || Input.GetKey("right") || Input.GetAxis("Horizontal") > 0.5f || PauseScreen.InputManager.StickRight)
		{
			if (Selected != 3)
			{
				return;
			}
			Debug.Log("Movin' right.");
			CurrentParent.localPosition -= new Vector3(Time.unscaledDeltaTime * 1000f, 0f, 0f);
			if (CurrentParent.localPosition.x < ScrollLimitH)
			{
				if (!PauseScreen.Yandere.StudentManager.EmbarassingSecret)
				{
					PauseScreen.Yandere.StudentManager.EmbarassingSecret = true;
					PauseScreen.Yandere.NotificationManager.CustomText = "Learned an embarrassing secret!";
					PauseScreen.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				CurrentParent.localPosition = new Vector3(ScrollLimitH, 0f, 0f);
			}
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			PromptBar.ClearButtons();
			PromptBar.Label[0].text = "Accept";
			PromptBar.Label[1].text = "Exit";
			PromptBar.Label[4].text = "Choose";
			PromptBar.Label[5].text = "Choose";
			PromptBar.UpdateButtons();
			Blogs[Selected].SetActive(value: false);
			PauseScreen.Zoom = false;
			Menu.SetActive(value: true);
			ViewingBlog = false;
		}
		else if (Input.GetButtonDown(InputNames.Xbox_X))
		{
			PauseScreen.Zoom = !PauseScreen.Zoom;
		}
		else if (Input.GetButtonDown(InputNames.Xbox_Y))
		{
			PauseScreen.Focus++;
			if (PauseScreen.Focus > 3)
			{
				PauseScreen.Focus = 0;
			}
		}
	}

	public void UpdateHighlight()
	{
		Selected = Column + (Row - 1) * 2;
		PromptBar.ClearButtons();
		if (BlogKnown[Selected])
		{
			PromptBar.Label[0].text = "View";
		}
		else
		{
			PromptBar.Label[0].text = "";
		}
		PromptBar.Label[1].text = "Back";
		PromptBar.Label[4].text = "Change Selection";
		PromptBar.Label[5].text = "Change Selection";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
		HeaderLabel.text = HeaderText[Selected];
		DescLabel.text = DescText[Selected];
		ErrorMessage.SetActive(!BlogKnown[Selected]);
		for (int i = 1; i < 5; i++)
		{
			Icons[i].color = (BlogKnown[i] ? new Color(1f, 1f, 1f, 1f) : new Color(0.5f, 0.5f, 0.5f, 0.5f));
			Shadows[i].enabled = (BlogKnown[i] ? true : false);
		}
	}
}
