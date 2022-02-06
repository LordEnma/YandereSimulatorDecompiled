using System;
using UnityEngine;

// Token: 0x0200037E RID: 894
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A0C RID: 6668 RVA: 0x0011257C File Offset: 0x0011077C
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

	// Token: 0x06001A0D RID: 6669 RVA: 0x0011260C File Offset: 0x0011080C
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

	// Token: 0x04002A6C RID: 10860
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002A6D RID: 10861
	public UISprite[] Icon;

	// Token: 0x04002A6E RID: 10862
	public UIPanel Panel;

	// Token: 0x04002A6F RID: 10863
	public UILabel Label;

	// Token: 0x04002A70 RID: 10864
	public bool Display;

	// Token: 0x04002A71 RID: 10865
	public float Timer;

	// Token: 0x04002A72 RID: 10866
	public int ID;
}
