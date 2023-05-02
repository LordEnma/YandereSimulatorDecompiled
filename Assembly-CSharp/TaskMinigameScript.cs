using UnityEngine;

public class TaskMinigameScript : MonoBehaviour
{
	public GravurePhotoShootScript GravurePhotoShoot;

	public UISprite[] ButtonPrompts;

	public UISprite Circle;

	public UISprite BG;

	public YandereScript Yandere;

	public AudioClip SuccessSFX;

	public AudioClip FailSFX;

	public AudioSource MyAudio;

	public string CurrentButton = string.Empty;

	public bool Failure;

	public bool Success;

	public bool Show;

	public int ButtonID;

	public int Progress;

	public int Limit;

	public int ID;

	public float Timer;

	public string[] GravureAnims;

	public int GravureID;

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
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				if (ButtonID == 0)
				{
					ChooseButton();
					Timer = 0f;
					return;
				}
				MyAudio.clip = FailSFX;
				MyAudio.Play();
				Yandere.NotificationManager.CustomText = "Failure!";
				Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Failure = true;
				End();
			}
			else
			{
				if (ButtonID <= 0)
				{
					return;
				}
				Circle.fillAmount = 1f - Timer / 1f;
				if ((Input.GetButtonDown(InputNames.Xbox_A) && CurrentButton != "A") || (Input.GetButtonDown(InputNames.Xbox_B) && CurrentButton != "B") || (Input.GetButtonDown(InputNames.Xbox_X) && CurrentButton != "X") || (Input.GetButtonDown(InputNames.Xbox_Y) && CurrentButton != "Y"))
				{
					MyAudio.clip = FailSFX;
					MyAudio.Play();
					Yandere.NotificationManager.CustomText = "Failure!";
					Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
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
					if (Progress == Limit)
					{
						MyAudio.clip = SuccessSFX;
						MyAudio.Play();
						Yandere.NotificationManager.CustomText = "Success!";
						Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						Success = true;
						End();
						if (GravurePhotoShoot != null)
						{
							GravurePhotoShoot.gameObject.SetActive(value: false);
							GravurePhotoShoot.Complete = true;
							GravurePhotoShoot.Prompt.enabled = false;
							GravurePhotoShoot.Prompt.Hide();
						}
					}
					else if (GravurePhotoShoot != null)
					{
						GravureID++;
						if (GravureID == GravureAnims.Length)
						{
							GravureID = 1;
						}
						Yandere.CharacterAnimation.CrossFade(GravureAnims[GravureID]);
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
			CurrentButton = "A";
		}
		else if (ButtonID == 2)
		{
			CurrentButton = "B";
		}
		else if (ButtonID == 3)
		{
			CurrentButton = "X";
		}
		else if (ButtonID == 4)
		{
			CurrentButton = "Y";
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
		Progress = 0;
		ButtonID = 0;
		Show = false;
		Timer = 0f;
		Limit = 5;
		Yandere.RPGCamera.enabled = true;
		Yandere.CanMove = true;
	}
}
