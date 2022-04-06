using System;
using UnityEngine;

// Token: 0x02000104 RID: 260
public class CabinetDoorScript : MonoBehaviour
{
	// Token: 0x06000A9F RID: 2719 RVA: 0x000618CF File Offset: 0x0005FACF
	private void Start()
	{
		this.Eighties = GameGlobals.Eighties;
	}

	// Token: 0x06000AA0 RID: 2720 RVA: 0x000618DC File Offset: 0x0005FADC
	private void Update()
	{
		if (this.Locked)
		{
			if (this.Prompt.Circle[0].fillAmount < 1f)
			{
				this.Prompt.Label[0].text = "     Locked";
				this.Prompt.Circle[0].fillAmount = 1f;
			}
			if (this.Prompt.Yandere.Inventory.LockPick)
			{
				this.Prompt.HideButton[2] = false;
				if (this.Prompt.Circle[2].fillAmount == 0f)
				{
					this.Prompt.Circle[2].fillAmount = 1f;
					if (this.Eighties)
					{
						this.Prompt.Yandere.Inventory.LockPick = false;
						this.Prompt.Label[0].text = "     Open";
						this.Prompt.HideButton[2] = true;
						this.Locked = false;
					}
					else
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "Cannot be lockpicked!";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
			}
			else if (!this.Prompt.HideButton[2])
			{
				this.Prompt.HideButton[2] = true;
			}
		}
		else if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.TheftTimer = 0.1f;
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Open = !this.Open;
			this.UpdateLabel();
			this.Timer = 0f;
		}
		if (this.Open)
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0.41775f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
		}
		else
		{
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
		}
		if (this.Timer < 2f)
		{
			this.Timer += Time.deltaTime;
			if (this.Open)
			{
				base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0.41775f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
				return;
			}
			base.transform.localPosition = new Vector3(Mathf.Lerp(base.transform.localPosition.x, 0f, Time.deltaTime * 10f), base.transform.localPosition.y, base.transform.localPosition.z);
		}
	}

	// Token: 0x06000AA1 RID: 2721 RVA: 0x00061C28 File Offset: 0x0005FE28
	private void UpdateLabel()
	{
		if (this.Open)
		{
			this.Prompt.Label[0].text = "     Close";
			return;
		}
		this.Prompt.Label[0].text = "     Open";
	}

	// Token: 0x04000CC1 RID: 3265
	public PromptScript Prompt;

	// Token: 0x04000CC2 RID: 3266
	public bool Eighties;

	// Token: 0x04000CC3 RID: 3267
	public bool Locked;

	// Token: 0x04000CC4 RID: 3268
	public bool Open;

	// Token: 0x04000CC5 RID: 3269
	public float Timer;
}
