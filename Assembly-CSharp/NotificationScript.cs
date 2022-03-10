using System;
using UnityEngine;

// Token: 0x02000380 RID: 896
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A1D RID: 6685 RVA: 0x0011368C File Offset: 0x0011188C
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

	// Token: 0x06001A1E RID: 6686 RVA: 0x0011371C File Offset: 0x0011191C
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

	// Token: 0x04002A98 RID: 10904
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002A99 RID: 10905
	public UISprite[] Icon;

	// Token: 0x04002A9A RID: 10906
	public UIPanel Panel;

	// Token: 0x04002A9B RID: 10907
	public UILabel Label;

	// Token: 0x04002A9C RID: 10908
	public bool Display;

	// Token: 0x04002A9D RID: 10909
	public float Timer;

	// Token: 0x04002A9E RID: 10910
	public int ID;
}
