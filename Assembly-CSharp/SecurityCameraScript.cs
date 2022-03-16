using System;
using UnityEngine;

// Token: 0x0200041C RID: 1052
public class SecurityCameraScript : MonoBehaviour
{
	// Token: 0x06001C7F RID: 7295 RVA: 0x0014D34C File Offset: 0x0014B54C
	private void Update()
	{
		this.Rotation += (float)this.Direction * 36f * Time.deltaTime;
		base.transform.parent.localEulerAngles = new Vector3(base.transform.parent.localEulerAngles.x, this.Rotation, base.transform.parent.localEulerAngles.z);
		if (this.Direction > 0)
		{
			if (this.Rotation > 86.5f)
			{
				this.Direction = -1;
				return;
			}
		}
		else if (this.Rotation < -86.5f)
		{
			this.Direction = 1;
		}
	}

	// Token: 0x06001C80 RID: 7296 RVA: 0x0014D3F0 File Offset: 0x0014B5F0
	private void OnTriggerStay(Collider other)
	{
		if (this.MissionMode.GameOverID == 0)
		{
			if (other.gameObject.layer == 13)
			{
				if ((this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious) || (this.Yandere.Bloodiness > 0f && !this.Yandere.RedPaint) || (this.Yandere.Sanity < 33.333f || this.Yandere.Attacking || this.Yandere.Struggling || this.Yandere.Dragging || this.Yandere.Lewd || this.Yandere.Dragging || this.Yandere.Carrying || (this.Yandere.Laughing && this.Yandere.LaughIntensity > 15f)) || (this.Yandere.PickUp != null && this.Yandere.PickUp.Clothing && this.Yandere.PickUp.Evidence && !this.Yandere.PickUp.RedPaint))
				{
					if (this.Yandere.Mask == null)
					{
						if (this.MissionMode.enabled)
						{
							this.MissionMode.GameOverID = 15;
							this.MissionMode.GameOver();
							this.MissionMode.Phase = 4;
							base.enabled = false;
							return;
						}
						if (!this.SecuritySystem.Evidence)
						{
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Evidence);
							this.SecuritySystem.Evidence = true;
							this.SecuritySystem.Masked = false;
							return;
						}
					}
					else if (!this.SecuritySystem.Masked)
					{
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Evidence);
						this.SecuritySystem.Evidence = true;
						this.SecuritySystem.Masked = true;
						return;
					}
				}
			}
			else if (other.gameObject.layer == 11 && this.MissionMode.enabled)
			{
				this.MissionMode.GameOverID = 15;
				this.MissionMode.GameOver();
				this.MissionMode.Phase = 4;
				base.enabled = false;
			}
		}
	}

	// Token: 0x040032B5 RID: 12981
	public SecuritySystemScript SecuritySystem;

	// Token: 0x040032B6 RID: 12982
	public MissionModeScript MissionMode;

	// Token: 0x040032B7 RID: 12983
	public YandereScript Yandere;

	// Token: 0x040032B8 RID: 12984
	public float Rotation;

	// Token: 0x040032B9 RID: 12985
	public int Direction = 1;
}
