using System;
using UnityEngine;

// Token: 0x02000381 RID: 897
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A2D RID: 6701 RVA: 0x001147F4 File Offset: 0x001129F4
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

	// Token: 0x06001A2E RID: 6702 RVA: 0x00114884 File Offset: 0x00112A84
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

	// Token: 0x04002AD4 RID: 10964
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002AD5 RID: 10965
	public UISprite[] Icon;

	// Token: 0x04002AD6 RID: 10966
	public UIPanel Panel;

	// Token: 0x04002AD7 RID: 10967
	public UILabel Label;

	// Token: 0x04002AD8 RID: 10968
	public bool Display;

	// Token: 0x04002AD9 RID: 10969
	public float Timer;

	// Token: 0x04002ADA RID: 10970
	public int ID;
}
