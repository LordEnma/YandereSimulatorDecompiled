using System;
using UnityEngine;

// Token: 0x02000380 RID: 896
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A1C RID: 6684 RVA: 0x001132B4 File Offset: 0x001114B4
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

	// Token: 0x06001A1D RID: 6685 RVA: 0x00113344 File Offset: 0x00111544
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

	// Token: 0x04002A82 RID: 10882
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002A83 RID: 10883
	public UISprite[] Icon;

	// Token: 0x04002A84 RID: 10884
	public UIPanel Panel;

	// Token: 0x04002A85 RID: 10885
	public UILabel Label;

	// Token: 0x04002A86 RID: 10886
	public bool Display;

	// Token: 0x04002A87 RID: 10887
	public float Timer;

	// Token: 0x04002A88 RID: 10888
	public int ID;
}
