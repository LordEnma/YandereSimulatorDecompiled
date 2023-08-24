using UnityEngine;

public class PickpocketMinigameScript : MonoBehaviour
{
	public Transform PickpocketSpot;

	public UISprite[] ButtonPrompts;

	public UISprite Circle;

	public UISprite BG;

	public YandereScript Yandere;

	public string CurrentButton = string.Empty;

	public bool NotNurse;

	public bool Sabotage;

	public bool Failure;

	public bool Success;

	public bool Show;

	public int StartingAlerts;

	public int ButtonID;

	public int Progress;

	public int ID;

	public float Timer;

	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		ButtonPrompts[1].enabled = false;
		ButtonPrompts[2].enabled = false;
		ButtonPrompts[3].enabled = false;
		ButtonPrompts[4].enabled = false;
		ButtonPrompts[1].alpha = 0f;
		ButtonPrompts[2].alpha = 0f;
		ButtonPrompts[3].alpha = 0f;
		ButtonPrompts[4].alpha = 0f;
		Circle.enabled = false;
		BG.enabled = false;
	}

	private void Update()
	{
		if (Show)
		{
			if (PickpocketSpot != null)
			{
				Yandere.MoveTowardsTarget(PickpocketSpot.position);
				Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, PickpocketSpot.rotation, Time.deltaTime * 10f);
			}
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				if (ButtonID == 0 && Yandere.Alerts == StartingAlerts)
				{
					ChooseButton();
					Timer = 0f;
				}
				else
				{
					Yandere.Caught = true;
					Failure = true;
					End();
				}
			}
			else
			{
				if (ButtonID <= 0)
				{
					return;
				}
				Circle.fillAmount = 1f - Timer / 1f;
				if ((Input.GetButtonDown(InputNames.Xbox_A) && CurrentButton != InputNames.Xbox_A) || (Input.GetButtonDown(InputNames.Xbox_B) && CurrentButton != InputNames.Xbox_B) || (Input.GetButtonDown(InputNames.Xbox_X) && CurrentButton != InputNames.Xbox_X) || (Input.GetButtonDown(InputNames.Xbox_Y) && CurrentButton != InputNames.Xbox_Y))
				{
					Yandere.Caught = true;
					Failure = true;
					End();
				}
				else
				{
					if (!Input.GetButtonDown(CurrentButton))
					{
						return;
					}
					ButtonPrompts[ButtonID].enabled = false;
					ButtonPrompts[ButtonID].alpha = 0f;
					Circle.enabled = false;
					BG.enabled = false;
					ButtonID = 0;
					Timer = 0f;
					Progress++;
					if (Progress == 5)
					{
						if (Sabotage)
						{
							Yandere.NotificationManager.CustomText = "Sabotage Success";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						else
						{
							Yandere.NotificationManager.CustomText = "Pickpocket Success";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						Yandere.Pickpocketing = false;
						Yandere.CanMove = true;
						Success = true;
						End();
					}
				}
			}
		}
		else if (base.transform.localScale.x > 0.1f)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (base.transform.localScale.x < 0.1f)
			{
				base.transform.localScale = Vector3.zero;
			}
		}
	}

	private void ChooseButton()
	{
		ButtonPrompts[1].enabled = false;
		ButtonPrompts[2].enabled = false;
		ButtonPrompts[3].enabled = false;
		ButtonPrompts[4].enabled = false;
		ButtonPrompts[1].alpha = 0f;
		ButtonPrompts[2].alpha = 0f;
		ButtonPrompts[3].alpha = 0f;
		ButtonPrompts[4].alpha = 0f;
		int buttonID = ButtonID;
		while (ButtonID == buttonID)
		{
			ButtonID = Random.Range(1, 5);
		}
		if (ButtonID == 1)
		{
			CurrentButton = InputNames.Xbox_A;
		}
		else if (ButtonID == 2)
		{
			CurrentButton = InputNames.Xbox_B;
		}
		else if (ButtonID == 3)
		{
			CurrentButton = InputNames.Xbox_X;
		}
		else if (ButtonID == 4)
		{
			CurrentButton = InputNames.Xbox_Y;
		}
		ButtonPrompts[ButtonID].enabled = true;
		ButtonPrompts[ButtonID].alpha = 1f;
		Circle.enabled = true;
		BG.enabled = true;
	}

	public void End()
	{
		Debug.Log("Ending minigame.");
		ButtonPrompts[1].enabled = false;
		ButtonPrompts[2].enabled = false;
		ButtonPrompts[3].enabled = false;
		ButtonPrompts[4].enabled = false;
		ButtonPrompts[1].alpha = 0f;
		ButtonPrompts[2].alpha = 0f;
		ButtonPrompts[3].alpha = 0f;
		ButtonPrompts[4].alpha = 0f;
		Circle.enabled = false;
		BG.enabled = false;
		Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
		Progress = 0;
		ButtonID = 0;
		Show = false;
		Timer = 0f;
	}
}
