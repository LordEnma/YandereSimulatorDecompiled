using System;
using UnityEngine;

// Token: 0x02000468 RID: 1128
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001E90 RID: 7824 RVA: 0x001AD872 File Offset: 0x001ABA72
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001E91 RID: 7825 RVA: 0x001AD894 File Offset: 0x001ABA94
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			AudioSource.PlayClipAtPoint(this.Tarp, base.transform.position);
			this.Unwrap = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Mecha.enabled = true;
			this.Mecha.Prompt.enabled = true;
		}
		if (this.Unwrap)
		{
			this.Speed += Time.deltaTime * 10f;
			base.transform.localEulerAngles = Vector3.Lerp(base.transform.localEulerAngles, new Vector3(90f, 90f, 0f), Time.deltaTime * this.Speed);
			if (base.transform.localEulerAngles.x > 45f)
			{
				if (this.PreviousSpeed == 0f)
				{
					this.PreviousSpeed = this.Speed;
				}
				this.Speed += Time.deltaTime * 10f;
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 0.0001f), (this.Speed - this.PreviousSpeed) * Time.deltaTime);
			}
		}
	}

	// Token: 0x04003F0C RID: 16140
	public PromptScript Prompt;

	// Token: 0x04003F0D RID: 16141
	public MechaScript Mecha;

	// Token: 0x04003F0E RID: 16142
	public AudioClip Tarp;

	// Token: 0x04003F0F RID: 16143
	public float PreviousSpeed;

	// Token: 0x04003F10 RID: 16144
	public float Speed;

	// Token: 0x04003F11 RID: 16145
	public bool Unwrap;
}
