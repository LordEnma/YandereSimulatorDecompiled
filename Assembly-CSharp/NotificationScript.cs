using System;
using UnityEngine;

// Token: 0x0200037F RID: 895
public class NotificationScript : MonoBehaviour
{
	// Token: 0x06001A13 RID: 6675 RVA: 0x001128A0 File Offset: 0x00110AA0
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

	// Token: 0x06001A14 RID: 6676 RVA: 0x00112930 File Offset: 0x00110B30
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

	// Token: 0x04002A72 RID: 10866
	public NotificationManagerScript NotificationManager;

	// Token: 0x04002A73 RID: 10867
	public UISprite[] Icon;

	// Token: 0x04002A74 RID: 10868
	public UIPanel Panel;

	// Token: 0x04002A75 RID: 10869
	public UILabel Label;

	// Token: 0x04002A76 RID: 10870
	public bool Display;

	// Token: 0x04002A77 RID: 10871
	public float Timer;

	// Token: 0x04002A78 RID: 10872
	public int ID;
}
