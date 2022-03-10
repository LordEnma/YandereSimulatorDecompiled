using System;
using UnityEngine;

// Token: 0x02000468 RID: 1128
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001E93 RID: 7827 RVA: 0x001ADF9A File Offset: 0x001AC19A
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001E94 RID: 7828 RVA: 0x001ADFBC File Offset: 0x001AC1BC
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

	// Token: 0x04003F23 RID: 16163
	public PromptScript Prompt;

	// Token: 0x04003F24 RID: 16164
	public MechaScript Mecha;

	// Token: 0x04003F25 RID: 16165
	public AudioClip Tarp;

	// Token: 0x04003F26 RID: 16166
	public float PreviousSpeed;

	// Token: 0x04003F27 RID: 16167
	public float Speed;

	// Token: 0x04003F28 RID: 16168
	public bool Unwrap;
}
