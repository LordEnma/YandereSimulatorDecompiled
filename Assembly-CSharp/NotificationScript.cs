using System;
using UnityEngine;

// Token: 0x0200037E RID: 894
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A09 RID: 6665 RVA: 0x00111DFC File Offset: 0x0010FFFC
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

	// Token: 0x06001A0A RID: 6666 RVA: 0x00111E8C File Offset: 0x0011008C
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

	// Token: 0x04002A5F RID: 10847
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002A60 RID: 10848
	public UISprite[] Icon;

	// Token: 0x04002A61 RID: 10849
	public UIPanel Panel;

	// Token: 0x04002A62 RID: 10850
	public UILabel Label;

	// Token: 0x04002A63 RID: 10851
	public bool Display;

	// Token: 0x04002A64 RID: 10852
	public float Timer;

	// Token: 0x04002A65 RID: 10853
	public int ID;
}
