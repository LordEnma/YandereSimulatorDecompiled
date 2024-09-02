using System;
using System.Linq;
using UnityEngine;

public class ModernRivalSabotageScript : MonoBehaviour
{
	public ModernRivalSabotageScript[] SabotageScripts;

	public ModernRivalEventScript SabotagedEvent;

	public ModernRivalEventScript OngoingEvent;

	public ModernRivalEventScript NormalEvent;

	public GameObject ObjectToDisable;

	public GameObject ObjectToEnable;

	public GameObject SabotageObject;

	public Renderer RendererToDisable;

	public BakeSaleScript BakeSale;

	public PromptScript Prompt;

	public Material TransMat;

	public UIPanel SabotageChecklist;

	public UISprite[] SabotageCheckmark;

	public Texture OriginalTexture;

	public bool[] SabotageCriteria;

	public bool Sabotaged;

	public bool Animate;

	public bool Checked;

	public float TimeLimit;

	public float Timer;

	public int Phase;

	public int ID;

	private void Start()
	{
		if (ID == 4)
		{
			ObjectToDisable.SetActive(value: false);
		}
		else if (ID == 6 && (DateGlobals.Week != 2 || GameGlobals.CustomMode))
		{
			Prompt.Hide();
			base.gameObject.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (ID == 1)
			{
				if (Prompt.Yandere.Inventory.EmeticPoisons == 0)
				{
					Prompt.Yandere.NotificationManager.CustomText = "Obtain emetic poison first.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (Prompt.Yandere.StudentManager.YandereVisible)
					{
						Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone can see you!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "Ingredients poisoned!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						Prompt.Yandere.Inventory.EmeticPoisons--;
						BakeSale.Poisoned = true;
						SabotagedEvent.gameObject.SetActive(value: true);
						NormalEvent.gameObject.SetActive(value: false);
						for (int i = 0; i < SabotageScripts.Length; i++)
						{
							SabotageScripts[i].Disable();
						}
					}
				}
			}
			else if (ID == 2)
			{
				if (!Prompt.Yandere.Inventory.PinkApron)
				{
					Prompt.Yandere.NotificationManager.CustomText = "Sew a pink apron in the Sewing Club.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (Prompt.Yandere.StudentManager.YandereVisible)
					{
						Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone can see you!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "Aprons swapped!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						Prompt.Yandere.Inventory.PinkApron = false;
						SabotagedEvent.gameObject.SetActive(value: true);
						NormalEvent.gameObject.SetActive(value: false);
						Disable();
					}
				}
			}
			else if (ID == 3)
			{
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (Prompt.Yandere.StudentManager.YandereVisible)
				{
					Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone can see you!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "Recipe Sabotaged!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					OngoingEvent.Instructions[9].Dialogue = "Ew! Yuck! This tastes awful...";
					SabotagedEvent.gameObject.SetActive(value: true);
					NormalEvent.gameObject.SetActive(value: false);
					Disable();
				}
			}
			else if (ID == 4)
			{
				if (!Prompt.Yandere.Inventory.Sugar)
				{
					Prompt.Yandere.NotificationManager.CustomText = "Grab some sugar from the Home Ec Room.";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
					if (Prompt.Yandere.StudentManager.YandereVisible)
					{
						Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone can see you!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "Sugar Spread!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						Prompt.Yandere.Inventory.Sugar = false;
						SabotagedEvent.gameObject.SetActive(value: true);
						NormalEvent.gameObject.SetActive(value: false);
						Disable();
					}
				}
			}
			else if (ID == 5)
			{
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (Prompt.Yandere.StudentManager.YandereVisible)
				{
					Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone can see you!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else if (Phase == 0)
				{
					Prompt.Label[0].text = "     Vandalize Cake";
					RendererToDisable.material = TransMat;
					Phase++;
				}
				else if (Phase == 1)
				{
					Prompt.Yandere.CharacterAnimation.Play(Prompt.Yandere.IdleAnim);
					Prompt.Yandere.transform.position = new Vector3(28.37667f, 0f, -15f);
					Prompt.Yandere.transform.eulerAngles = new Vector3(0f, 0f, 0f);
					Prompt.Yandere.RPGCamera.enabled = false;
					Prompt.Yandere.CanMove = false;
					Prompt.Yandere.MainCamera.transform.position = new Vector3(28.37667f, 1.76f, -14.31333f);
					Prompt.Yandere.MainCamera.transform.eulerAngles = new Vector3(90f, 0f, 0f);
					Prompt.Yandere.PromptBar.ClearButtons();
					Prompt.Yandere.PromptBar.Label[0].text = "Add Dollop";
					Prompt.Yandere.PromptBar.Label[1].text = "Exit";
					Prompt.Yandere.PromptBar.Label[4].text = "Move";
					Prompt.Yandere.PromptBar.Label[5].text = "Move";
					Prompt.Yandere.PromptBar.UpdateButtons();
					Prompt.Yandere.PromptBar.Show = true;
					Prompt.Yandere.CameraEffects.UpdateDOF(0.5f);
					ObjectToEnable.SetActive(value: true);
				}
				else if (!Prompt.Yandere.Inventory.RivalPhone)
				{
					Prompt.Yandere.NotificationManager.CustomText = "Steal the rival's phone first!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					Prompt.Yandere.CharacterAnimation.CrossFade("f02_Wednesday_2_TakePicture");
					Prompt.Yandere.transform.eulerAngles = new Vector3(0f, 0f, 0f);
					Prompt.Yandere.CanMove = false;
					Animate = true;
				}
			}
			else if (ID == 6)
			{
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (Prompt.Yandere.StudentManager.YandereVisible)
				{
					Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone can see you!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					bool flag = false;
					if (Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.WeaponID == 6)
					{
						flag = true;
					}
					if (!flag)
					{
						Prompt.Yandere.NotificationManager.CustomText = "Acquire a screwdriver first!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "Disabled the flame sensor!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						Prompt.HideButton[0] = true;
						SabotageCriteria[0] = true;
						CheckForSabotageSuccess();
					}
				}
			}
		}
		if (Prompt.ButtonActive[1] && Prompt.Circle[1].fillAmount == 0f)
		{
			Prompt.Circle[1].fillAmount = 1f;
			if (ID == 6)
			{
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (Prompt.Yandere.StudentManager.YandereVisible)
				{
					Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone can see you!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
				else
				{
					bool flag2 = false;
					if (Prompt.Yandere.Armed && Prompt.Yandere.EquippedWeapon.WeaponID == 24)
					{
						flag2 = true;
					}
					if (!flag2)
					{
						Prompt.Yandere.NotificationManager.CustomText = "Acquire a pipe wrench first!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else
					{
						Prompt.Yandere.NotificationManager.CustomText = "Swapped gas knob with ignition knob!";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						SabotageCriteria[1] = true;
						CheckForSabotageSuccess();
					}
				}
			}
		}
		if (Animate && ID == 5)
		{
			Prompt.Yandere.MoveTowardsTarget(new Vector3(28.37667f, 0f, -15f));
			Timer += Time.deltaTime;
			if (Timer >= Prompt.Yandere.CharacterAnimation["f02_Wednesday_2_TakePicture"].length)
			{
				Prompt.Yandere.NotificationManager.CustomText = "Put your rival's phone on her desk!";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				Prompt.Yandere.CanMove = true;
				if (Prompt.Yandere.StudentManager.Students[Prompt.Yandere.StudentManager.RivalID] != null)
				{
					Prompt.Yandere.StudentManager.Students[Prompt.Yandere.StudentManager.RivalID].EventToSabotage = SabotagedEvent;
				}
				Prompt.Yandere.Phone.GetComponent<Renderer>().material.mainTexture = Prompt.Yandere.YanderePhoneTexture;
				NormalEvent.gameObject.SetActive(value: false);
				Disable();
			}
			else if (Timer > 6.66666f)
			{
				Prompt.Yandere.Phone.SetActive(value: false);
			}
			else if (Timer > 5.33333f)
			{
				Prompt.Yandere.CameraFlash.SetActive(value: true);
			}
			else if (Timer > 1.25f)
			{
				Prompt.Yandere.Phone.transform.localPosition = new Vector3(-0.02f, -0.0025f, 0.025f);
				Prompt.Yandere.Phone.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
				Prompt.Yandere.Phone.transform.localPosition = new Vector3(0f, 0.005f, -0.01f);
				Prompt.Yandere.Phone.transform.localEulerAngles = new Vector3(7.33333f, -154f, 173.66666f);
				int rivalID = Prompt.Yandere.StudentManager.RivalID;
				Prompt.Yandere.Phone.GetComponent<Renderer>().material.mainTexture = Prompt.Yandere.StudentManager.Students[rivalID].SmartPhone.GetComponent<Renderer>().material.mainTexture;
				Prompt.Yandere.Phone.SetActive(value: true);
			}
		}
		if (SabotageChecklist != null)
		{
			if (Vector3.Distance(Prompt.Yandere.transform.position, base.transform.position) < 2f && !Sabotaged)
			{
				SabotageChecklist.alpha = Mathf.MoveTowards(SabotageChecklist.alpha, 1f, Time.deltaTime);
			}
			else
			{
				SabotageChecklist.alpha = Mathf.MoveTowards(SabotageChecklist.alpha, 0f, Time.deltaTime);
			}
			if (Prompt.Yandere.StudentManager.Clock.HourTime > TimeLimit)
			{
				Disable();
			}
			if (Prompt.Yandere.StudentManager.CameFromLoad && !Checked)
			{
				CheckForSabotageSuccess();
				Checked = true;
			}
		}
	}

	public void CheckForSabotageSuccess()
	{
		if (ID != 6)
		{
			return;
		}
		for (int i = 0; i < SabotageCheckmark.Length; i++)
		{
			SabotageCheckmark[i].spriteName = (SabotageCriteria[i] ? "Yes" : "No");
			Prompt.HideButton[i] = SabotageCriteria[i];
		}
		if (SabotageCriteria.All((bool x) => x))
		{
			if (DateGlobals.Weekday == DayOfWeek.Thursday)
			{
				SabotagedEvent.gameObject.SetActive(value: true);
				NormalEvent.gameObject.SetActive(value: false);
			}
			ObjectToEnable.SetActive(value: true);
			Disable();
		}
	}

	public void Disable()
	{
		if (SabotageChecklist != null)
		{
			SabotageChecklist.alpha = 0f;
		}
		Prompt.Hide();
		Prompt.enabled = false;
		Sabotaged = true;
		base.enabled = false;
	}

	public void Sabotage()
	{
		Debug.Log("Re-sabotaging an event after returning from a save.");
		SabotagedEvent.gameObject.SetActive(value: true);
		NormalEvent.gameObject.SetActive(value: false);
		if (ObjectToEnable != null)
		{
			ObjectToEnable.SetActive(value: true);
		}
		Disable();
	}
}
