using System;
using UnityEngine;

// Token: 0x02000382 RID: 898
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A37 RID: 6711 RVA: 0x00114C40 File Offset: 0x00112E40
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

	// Token: 0x06001A38 RID: 6712 RVA: 0x00114CD0 File Offset: 0x00112ED0
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

	// Token: 0x04002ADF RID: 10975
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002AE0 RID: 10976
	public UISprite[] Icon;

	// Token: 0x04002AE1 RID: 10977
	public UIPanel Panel;

	// Token: 0x04002AE2 RID: 10978
	public UILabel Label;

	// Token: 0x04002AE3 RID: 10979
	public bool Display;

	// Token: 0x04002AE4 RID: 10980
	public float Timer;

	// Token: 0x04002AE5 RID: 10981
	public int ID;
}
