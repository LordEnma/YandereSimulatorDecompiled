using System;
using UnityEngine;

// Token: 0x020003A5 RID: 933
public class PickpocketMinigameScript : MonoBehaviour
{
	// Token: 0x06001A9E RID: 6814 RVA: 0x0011FE28 File Offset: 0x0011E028
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

	// Token: 0x06001A9F RID: 6815 RVA: 0x0011FEE0 File Offset: 0x0011E0E0
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

	// Token: 0x06001AA0 RID: 6816 RVA: 0x00120228 File Offset: 0x0011E428
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

	// Token: 0x06001AA1 RID: 6817 RVA: 0x0012036C File Offset: 0x0011E56C
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

	// Token: 0x04002C4A RID: 11338
	public Transform PickpocketSpot;

	// Token: 0x04002C4B RID: 11339
	public UISprite[] ButtonPrompts;

	// Token: 0x04002C4C RID: 11340
	public UISprite Circle;

	// Token: 0x04002C4D RID: 11341
	public UISprite BG;

	// Token: 0x04002C4E RID: 11342
	public YandereScript Yandere;

	// Token: 0x04002C4F RID: 11343
	public string CurrentButton = string.Empty;

	// Token: 0x04002C50 RID: 11344
	public bool NotNurse;

	// Token: 0x04002C51 RID: 11345
	public bool Sabotage;

	// Token: 0x04002C52 RID: 11346
	public bool Failure;

	// Token: 0x04002C53 RID: 11347
	public bool Success;

	// Token: 0x04002C54 RID: 11348
	public bool Show;

	// Token: 0x04002C55 RID: 11349
	public int StartingAlerts;

	// Token: 0x04002C56 RID: 11350
	public int ButtonID;

	// Token: 0x04002C57 RID: 11351
	public int Progress;

	// Token: 0x04002C58 RID: 11352
	public int ID;

	// Token: 0x04002C59 RID: 11353
	public float Timer;
}
