using System;
using UnityEngine;

// Token: 0x02000105 RID: 261
public class CabinetDoorScript : MonoBehaviour
{
	// Token: 0x06000AA1 RID: 2721 RVA: 0x00061ECB File Offset: 0x000600CB
	private void Start()
	{
		this.Eighties = GameGlobals.Eighties;
	}

	// Token: 0x06000AA2 RID: 2722 RVA: 0x00061ED8 File Offset: 0x000600D8
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

	// Token: 0x06000AA3 RID: 2723 RVA: 0x00062224 File Offset: 0x00060424
	private void UpdateLabel()
	{
		if (this.Open)
		{
			this.Prompt.Label[0].text = "     Close";
			return;
		}
		this.Prompt.Label[0].text = "     Open";
	}

	// Token: 0x04000CCA RID: 3274
	public PromptScript Prompt;

	// Token: 0x04000CCB RID: 3275
	public bool Eighties;

	// Token: 0x04000CCC RID: 3276
	public bool Locked;

	// Token: 0x04000CCD RID: 3277
	public bool Open;

	// Token: 0x04000CCE RID: 3278
	public float Timer;
}
