using System;
using UnityEngine;

// Token: 0x0200046F RID: 1135
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001EC5 RID: 7877 RVA: 0x001B2CFA File Offset: 0x001B0EFA
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001EC6 RID: 7878 RVA: 0x001B2D1C File Offset: 0x001B0F1C
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

	// Token: 0x04003FC1 RID: 16321
	public PromptScript Prompt;

	// Token: 0x04003FC2 RID: 16322
	public MechaScript Mecha;

	// Token: 0x04003FC3 RID: 16323
	public AudioClip Tarp;

	// Token: 0x04003FC4 RID: 16324
	public float PreviousSpeed;

	// Token: 0x04003FC5 RID: 16325
	public float Speed;

	// Token: 0x04003FC6 RID: 16326
	public bool Unwrap;
}
