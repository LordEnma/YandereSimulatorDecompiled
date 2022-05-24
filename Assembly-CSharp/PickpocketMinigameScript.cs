using System;
using UnityEngine;

// Token: 0x020003AC RID: 940
public class PickpocketMinigameScript : MonoBehaviour
{
	// Token: 0x06001ADA RID: 6874 RVA: 0x00124220 File Offset: 0x00122420
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		this.ButtonPrompts[1].alpha = 0f;
		this.ButtonPrompts[2].alpha = 0f;
		this.ButtonPrompts[3].alpha = 0f;
		this.ButtonPrompts[4].alpha = 0f;
		this.Circle.enabled = false;
		this.BG.enabled = false;
	}

	// Token: 0x06001ADB RID: 6875 RVA: 0x001242D8 File Offset: 0x001224D8
	private void Update()
	{
		if (this.Show)
		{
			if (this.PickpocketSpot != null)
			{
				this.Yandere.MoveTowardsTarget(this.PickpocketSpot.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.PickpocketSpot.rotation, Time.deltaTime * 10f);
			}
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				if (this.ButtonID == 0 && this.Yandere.Alerts == this.StartingAlerts)
				{
					this.ChooseButton();
					this.Timer = 0f;
					return;
				}
				this.Yandere.Caught = true;
				this.Failure = true;
				this.End();
				return;
			}
			else if (this.ButtonID > 0)
			{
				this.Circle.fillAmount = 1f - this.Timer / 1f;
				if ((Input.GetButtonDown("A") && this.CurrentButton != "A") || (Input.GetButtonDown("B") && this.CurrentButton != "B") || (Input.GetButtonDown("X") && this.CurrentButton != "X") || (Input.GetButtonDown("Y") && this.CurrentButton != "Y"))
				{
					this.Yandere.Caught = true;
					this.Failure = true;
					this.End();
					return;
				}
				if (Input.GetButtonDown(this.CurrentButton))
				{
					this.ButtonPrompts[this.ButtonID].enabled = false;
					this.ButtonPrompts[this.ButtonID].alpha = 0f;
					this.Circle.enabled = false;
					this.BG.enabled = false;
					this.ButtonID = 0;
					this.Timer = 0f;
					this.Progress++;
					if (this.Progress == 5)
					{
						if (this.Sabotage)
						{
							this.Yandere.NotificationManager.CustomText = "Sabotage Success";
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						else
						{
							this.Yandere.NotificationManager.CustomText = "Pickpocket Success";
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						this.Yandere.Pickpocketing = false;
						this.Yandere.CanMove = true;
						this.Success = true;
						this.End();
						return;
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

	// Token: 0x06001ADC RID: 6876 RVA: 0x00124620 File Offset: 0x00122820
	private void ChooseButton()
	{
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		this.ButtonPrompts[1].alpha = 0f;
		this.ButtonPrompts[2].alpha = 0f;
		this.ButtonPrompts[3].alpha = 0f;
		this.ButtonPrompts[4].alpha = 0f;
		int buttonID = this.ButtonID;
		while (this.ButtonID == buttonID)
		{
			this.ButtonID = UnityEngine.Random.Range(1, 5);
		}
		if (this.ButtonID == 1)
		{
			this.CurrentButton = "A";
		}
		else if (this.ButtonID == 2)
		{
			this.CurrentButton = "B";
		}
		else if (this.ButtonID == 3)
		{
			this.CurrentButton = "X";
		}
		else if (this.ButtonID == 4)
		{
			this.CurrentButton = "Y";
		}
		this.ButtonPrompts[this.ButtonID].enabled = true;
		this.ButtonPrompts[this.ButtonID].alpha = 1f;
		this.Circle.enabled = true;
		this.BG.enabled = true;
	}

	// Token: 0x06001ADD RID: 6877 RVA: 0x00124764 File Offset: 0x00122964
	public void End()
	{
		Debug.Log("Ending minigame.");
		this.ButtonPrompts[1].enabled = false;
		this.ButtonPrompts[2].enabled = false;
		this.ButtonPrompts[3].enabled = false;
		this.ButtonPrompts[4].enabled = false;
		this.ButtonPrompts[1].alpha = 0f;
		this.ButtonPrompts[2].alpha = 0f;
		this.ButtonPrompts[3].alpha = 0f;
		this.ButtonPrompts[4].alpha = 0f;
		this.Circle.enabled = false;
		this.BG.enabled = false;
		this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
		this.Progress = 0;
		this.ButtonID = 0;
		this.Show = false;
		this.Timer = 0f;
	}

	// Token: 0x04002CF7 RID: 11511
	public Transform PickpocketSpot;

	// Token: 0x04002CF8 RID: 11512
	public UISprite[] ButtonPrompts;

	// Token: 0x04002CF9 RID: 11513
	public UISprite Circle;

	// Token: 0x04002CFA RID: 11514
	public UISprite BG;

	// Token: 0x04002CFB RID: 11515
	public YandereScript Yandere;

	// Token: 0x04002CFC RID: 11516
	public string CurrentButton = string.Empty;

	// Token: 0x04002CFD RID: 11517
	public bool NotNurse;

	// Token: 0x04002CFE RID: 11518
	public bool Sabotage;

	// Token: 0x04002CFF RID: 11519
	public bool Failure;

	// Token: 0x04002D00 RID: 11520
	public bool Success;

	// Token: 0x04002D01 RID: 11521
	public bool Show;

	// Token: 0x04002D02 RID: 11522
	public int StartingAlerts;

	// Token: 0x04002D03 RID: 11523
	public int ButtonID;

	// Token: 0x04002D04 RID: 11524
	public int Progress;

	// Token: 0x04002D05 RID: 11525
	public int ID;

	// Token: 0x04002D06 RID: 11526
	public float Timer;
}
