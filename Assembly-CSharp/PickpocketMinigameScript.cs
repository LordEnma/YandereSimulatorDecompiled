using System;
using UnityEngine;

// Token: 0x020003AB RID: 939
public class PickpocketMinigameScript : MonoBehaviour
{
	// Token: 0x06001AD3 RID: 6867 RVA: 0x00123664 File Offset: 0x00121864
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

	// Token: 0x06001AD4 RID: 6868 RVA: 0x0012371C File Offset: 0x0012191C
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

	// Token: 0x06001AD5 RID: 6869 RVA: 0x00123A64 File Offset: 0x00121C64
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

	// Token: 0x06001AD6 RID: 6870 RVA: 0x00123BA8 File Offset: 0x00121DA8
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

	// Token: 0x04002CDD RID: 11485
	public Transform PickpocketSpot;

	// Token: 0x04002CDE RID: 11486
	public UISprite[] ButtonPrompts;

	// Token: 0x04002CDF RID: 11487
	public UISprite Circle;

	// Token: 0x04002CE0 RID: 11488
	public UISprite BG;

	// Token: 0x04002CE1 RID: 11489
	public YandereScript Yandere;

	// Token: 0x04002CE2 RID: 11490
	public string CurrentButton = string.Empty;

	// Token: 0x04002CE3 RID: 11491
	public bool NotNurse;

	// Token: 0x04002CE4 RID: 11492
	public bool Sabotage;

	// Token: 0x04002CE5 RID: 11493
	public bool Failure;

	// Token: 0x04002CE6 RID: 11494
	public bool Success;

	// Token: 0x04002CE7 RID: 11495
	public bool Show;

	// Token: 0x04002CE8 RID: 11496
	public int StartingAlerts;

	// Token: 0x04002CE9 RID: 11497
	public int ButtonID;

	// Token: 0x04002CEA RID: 11498
	public int Progress;

	// Token: 0x04002CEB RID: 11499
	public int ID;

	// Token: 0x04002CEC RID: 11500
	public float Timer;
}
