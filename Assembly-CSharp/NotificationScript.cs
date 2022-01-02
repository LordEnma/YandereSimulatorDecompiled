using System;
using UnityEngine;

// Token: 0x0200037D RID: 893
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A05 RID: 6661 RVA: 0x00111A9C File Offset: 0x0010FC9C
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

	// Token: 0x06001A06 RID: 6662 RVA: 0x00111B2C File Offset: 0x0010FD2C
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

	// Token: 0x04002A59 RID: 10841
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002A5A RID: 10842
	public UISprite[] Icon;

	// Token: 0x04002A5B RID: 10843
	public UIPanel Panel;

	// Token: 0x04002A5C RID: 10844
	public UILabel Label;

	// Token: 0x04002A5D RID: 10845
	public bool Display;

	// Token: 0x04002A5E RID: 10846
	public float Timer;

	// Token: 0x04002A5F RID: 10847
	public int ID;
}
