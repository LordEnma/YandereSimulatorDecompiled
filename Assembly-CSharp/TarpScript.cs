using System;
using UnityEngine;

// Token: 0x02000467 RID: 1127
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001E87 RID: 7815 RVA: 0x001ACD36 File Offset: 0x001AAF36
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001E88 RID: 7816 RVA: 0x001ACD58 File Offset: 0x001AAF58
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

	// Token: 0x04003EFC RID: 16124
	public PromptScript Prompt;

	// Token: 0x04003EFD RID: 16125
	public MechaScript Mecha;

	// Token: 0x04003EFE RID: 16126
	public AudioClip Tarp;

	// Token: 0x04003EFF RID: 16127
	public float PreviousSpeed;

	// Token: 0x04003F00 RID: 16128
	public float Speed;

	// Token: 0x04003F01 RID: 16129
	public bool Unwrap;
}
