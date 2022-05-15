using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001ECD RID: 7885 RVA: 0x001B3E72 File Offset: 0x001B2072
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001ECE RID: 7886 RVA: 0x001B3E94 File Offset: 0x001B2094
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

	// Token: 0x04003FDF RID: 16351
	public PromptScript Prompt;

	// Token: 0x04003FE0 RID: 16352
	public MechaScript Mecha;

	// Token: 0x04003FE1 RID: 16353
	public AudioClip Tarp;

	// Token: 0x04003FE2 RID: 16354
	public float PreviousSpeed;

	// Token: 0x04003FE3 RID: 16355
	public float Speed;

	// Token: 0x04003FE4 RID: 16356
	public bool Unwrap;
}
