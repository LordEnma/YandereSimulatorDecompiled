using UnityEngine;

public class AppearanceWindowScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public Transform Highlight;

	public Transform Window;

	public UISprite[] Checks;

	public int Selected;

	public bool Ready;

	public bool Show;

	private void Start()
	{
		Window.localScale = Vector3.zero;
		for (int i = 1; i < 10; i++)
		{
			Checks[i].enabled = DatingGlobals.GetSuitorCheck(i);
		}
	}

	private void Update()
	{
		if (!Show)
		{
			if (Window.gameObject.activeInHierarchy)
			{
				if (Window.localScale.x > 0.1f)
				{
					Window.localScale = Vector3.Lerp(Window.localScale, Vector3.zero, Time.deltaTime * 10f);
					return;
				}
				Window.localScale = Vector3.zero;
				Window.gameObject.SetActive(value: false);
			}
			return;
		}
		Window.localScale = Vector3.Lerp(Window.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		if (Ready)
		{
			if (InputManager.TappedUp)
			{
				Selected--;
				if (Selected == 10)
				{
					Selected = 9;
				}
				UpdateHighlight();
			}
			if (InputManager.TappedDown)
			{
				Selected++;
				if (Selected == 10)
				{
					Selected = 11;
				}
				UpdateHighlight();
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (Selected == 1)
				{
					if (!Checks[1].enabled)
					{
						if (Yandere.TargetStudent.Male)
						{
							StudentManager.LoveManager.CustomSuitorHair = 55;
						}
						else
						{
							StudentManager.LoveManager.CustomSuitorHair = 56;
						}
						Checks[1].enabled = true;
						Checks[2].enabled = false;
					}
					else
					{
						StudentManager.LoveManager.CustomSuitorHair = 0;
						Checks[1].enabled = false;
					}
				}
				else if (Selected == 2)
				{
					if (!Checks[2].enabled)
					{
						if (Yandere.TargetStudent.Male)
						{
							StudentManager.LoveManager.CustomSuitorHair = 56;
						}
						else
						{
							StudentManager.LoveManager.CustomSuitorHair = 22;
						}
						Checks[1].enabled = false;
						Checks[2].enabled = true;
					}
					else
					{
						StudentManager.LoveManager.CustomSuitorHair = 0;
						Checks[2].enabled = false;
					}
				}
				else if (Selected == 3)
				{
					if (!Checks[3].enabled)
					{
						StudentManager.LoveManager.CustomSuitorAccessory = 17;
						Checks[3].enabled = true;
						Checks[4].enabled = false;
					}
					else
					{
						StudentManager.LoveManager.CustomSuitorAccessory = 0;
						Checks[3].enabled = false;
					}
				}
				else if (Selected == 4)
				{
					if (!Checks[4].enabled)
					{
						if (Yandere.TargetStudent.Male)
						{
							StudentManager.LoveManager.CustomSuitorAccessory = 1;
						}
						else
						{
							StudentManager.LoveManager.CustomSuitorAccessory = 18;
						}
						Checks[3].enabled = false;
						Checks[4].enabled = true;
					}
					else
					{
						StudentManager.LoveManager.CustomSuitorAccessory = 0;
						Checks[4].enabled = false;
					}
				}
				else if (Selected == 5)
				{
					if (!Checks[5].enabled)
					{
						StudentManager.LoveManager.CustomSuitorEyewear = 6;
						Checks[5].enabled = true;
						Checks[6].enabled = false;
					}
					else
					{
						StudentManager.LoveManager.CustomSuitorEyewear = 0;
						Checks[5].enabled = false;
					}
				}
				else if (Selected == 6)
				{
					if (!Checks[6].enabled)
					{
						StudentManager.LoveManager.CustomSuitorEyewear = 3;
						Checks[5].enabled = false;
						Checks[6].enabled = true;
					}
					else
					{
						StudentManager.LoveManager.CustomSuitorEyewear = 0;
						Checks[6].enabled = false;
					}
				}
				else if (Selected == 7)
				{
					if (!Checks[7].enabled)
					{
						StudentManager.LoveManager.CustomSuitorTan = true;
						Checks[7].enabled = true;
					}
					else
					{
						StudentManager.LoveManager.CustomSuitorTan = false;
						Checks[7].enabled = false;
					}
				}
				else if (Selected == 8)
				{
					if (!Checks[8].enabled)
					{
						StudentManager.LoveManager.CustomSuitorBlack = true;
						Checks[8].enabled = true;
					}
					else
					{
						StudentManager.LoveManager.CustomSuitorBlack = false;
						Checks[8].enabled = false;
					}
				}
				else if (Selected == 9)
				{
					if (!Checks[9].enabled)
					{
						StudentManager.LoveManager.CustomSuitorJewelry = 1;
						Checks[9].enabled = true;
					}
					else
					{
						StudentManager.LoveManager.CustomSuitorJewelry = 0;
						Checks[9].enabled = false;
					}
				}
				else if (Selected == 11)
				{
					Debug.Log("The game believes that we just exited the Appearance Window.");
					StudentManager.LoveManager.CustomSuitor = true;
					PromptBar.ClearButtons();
					PromptBar.UpdateButtons();
					PromptBar.Show = false;
					Yandere.Interaction = YandereInteractionType.ChangingAppearance;
					Yandere.TalkTimer = 3f;
					Ready = false;
					Show = false;
				}
			}
		}
		if (Input.GetButtonUp(InputNames.Xbox_A))
		{
			Ready = true;
		}
	}

	private void UpdateHighlight()
	{
		if (Selected < 1)
		{
			Selected = 11;
		}
		else if (Selected > 11)
		{
			Selected = 1;
		}
		Highlight.transform.localPosition = new Vector3(Highlight.transform.localPosition.x, 300f - 50f * (float)Selected, Highlight.transform.localPosition.z);
	}

	private void Exit()
	{
		Selected = 1;
		UpdateHighlight();
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		Show = false;
	}
}
