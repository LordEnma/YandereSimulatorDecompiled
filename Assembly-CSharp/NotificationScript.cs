using System;
using UnityEngine;

// Token: 0x0200037E RID: 894
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A0A RID: 6666 RVA: 0x00112464 File Offset: 0x00110664
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

	// Token: 0x06001A0B RID: 6667 RVA: 0x001124F4 File Offset: 0x001106F4
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

	// Token: 0x04002A69 RID: 10857
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002A6A RID: 10858
	public UISprite[] Icon;

	// Token: 0x04002A6B RID: 10859
	public UIPanel Panel;

	// Token: 0x04002A6C RID: 10860
	public UILabel Label;

	// Token: 0x04002A6D RID: 10861
	public bool Display;

	// Token: 0x04002A6E RID: 10862
	public float Timer;

	// Token: 0x04002A6F RID: 10863
	public int ID;
}
