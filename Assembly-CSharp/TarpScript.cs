using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001EAD RID: 7853 RVA: 0x001B09C2 File Offset: 0x001AEBC2
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001EAE RID: 7854 RVA: 0x001B09E4 File Offset: 0x001AEBE4
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

	// Token: 0x04003F98 RID: 16280
	public PromptScript Prompt;

	// Token: 0x04003F99 RID: 16281
	public MechaScript Mecha;

	// Token: 0x04003F9A RID: 16282
	public AudioClip Tarp;

	// Token: 0x04003F9B RID: 16283
	public float PreviousSpeed;

	// Token: 0x04003F9C RID: 16284
	public float Speed;

	// Token: 0x04003F9D RID: 16285
	public bool Unwrap;
}
