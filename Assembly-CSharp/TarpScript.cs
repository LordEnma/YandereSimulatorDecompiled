using System;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001EB5 RID: 7861 RVA: 0x001B0EB6 File Offset: 0x001AF0B6
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001EB6 RID: 7862 RVA: 0x001B0ED8 File Offset: 0x001AF0D8
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

	// Token: 0x04003F9B RID: 16283
	public PromptScript Prompt;

	// Token: 0x04003F9C RID: 16284
	public MechaScript Mecha;

	// Token: 0x04003F9D RID: 16285
	public AudioClip Tarp;

	// Token: 0x04003F9E RID: 16286
	public float PreviousSpeed;

	// Token: 0x04003F9F RID: 16287
	public float Speed;

	// Token: 0x04003FA0 RID: 16288
	public bool Unwrap;
}
