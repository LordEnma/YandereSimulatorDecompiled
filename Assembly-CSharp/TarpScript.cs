using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001ECE RID: 7886 RVA: 0x001B4302 File Offset: 0x001B2502
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001ECF RID: 7887 RVA: 0x001B4324 File Offset: 0x001B2524
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

	// Token: 0x04003FE8 RID: 16360
	public PromptScript Prompt;

	// Token: 0x04003FE9 RID: 16361
	public MechaScript Mecha;

	// Token: 0x04003FEA RID: 16362
	public AudioClip Tarp;

	// Token: 0x04003FEB RID: 16363
	public float PreviousSpeed;

	// Token: 0x04003FEC RID: 16364
	public float Speed;

	// Token: 0x04003FED RID: 16365
	public bool Unwrap;
}
