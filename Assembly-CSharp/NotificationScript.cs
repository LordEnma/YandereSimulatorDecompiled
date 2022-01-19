using System;
using UnityEngine;

// Token: 0x0200037E RID: 894
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A09 RID: 6665 RVA: 0x00111F64 File Offset: 0x00110164
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

	// Token: 0x06001A0A RID: 6666 RVA: 0x00111FF4 File Offset: 0x001101F4
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

	// Token: 0x04002A62 RID: 10850
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002A63 RID: 10851
	public UISprite[] Icon;

	// Token: 0x04002A64 RID: 10852
	public UIPanel Panel;

	// Token: 0x04002A65 RID: 10853
	public UILabel Label;

	// Token: 0x04002A66 RID: 10854
	public bool Display;

	// Token: 0x04002A67 RID: 10855
	public float Timer;

	// Token: 0x04002A68 RID: 10856
	public int ID;
}
