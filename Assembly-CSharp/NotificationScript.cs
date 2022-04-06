using System;
using UnityEngine;

// Token: 0x02000382 RID: 898
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A33 RID: 6707 RVA: 0x00114960 File Offset: 0x00112B60
	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			this.Icon[0].color = new Color(1f, 1f, 1f, 1f);
			this.Icon[1].color = new Color(1f, 1f, 1f, 1f);
			this.Label.color = new Color(1f, 1f, 1f, 1f);
			this.Label.applyGradient = false;
		}
	}

	// Token: 0x06001A34 RID: 6708 RVA: 0x001149F0 File Offset: 0x00112BF0
	private void Update()
	{
		if (!this.Display)
		{
			this.Panel.alpha -= Time.deltaTime * ((this.NotificationManager.NotificationsSpawned > this.ID + 2) ? 3f : 1f);
			if (this.Panel.alpha <= 0f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 4f)
			{
				this.Display = false;
			}
			if (this.NotificationManager.NotificationsSpawned > this.ID + 2)
			{
				this.Display = false;
			}
		}
	}

	// Token: 0x04002AD7 RID: 10967
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002AD8 RID: 10968
	public UISprite[] Icon;

	// Token: 0x04002AD9 RID: 10969
	public UIPanel Panel;

	// Token: 0x04002ADA RID: 10970
	public UILabel Label;

	// Token: 0x04002ADB RID: 10971
	public bool Display;

	// Token: 0x04002ADC RID: 10972
	public float Timer;

	// Token: 0x04002ADD RID: 10973
	public int ID;
}
