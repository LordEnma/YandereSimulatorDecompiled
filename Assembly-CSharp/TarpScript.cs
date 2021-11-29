using System;
using UnityEngine;

// Token: 0x02000462 RID: 1122
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001E61 RID: 7777 RVA: 0x001A962E File Offset: 0x001A782E
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001E62 RID: 7778 RVA: 0x001A9650 File Offset: 0x001A7850
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

	// Token: 0x04003E91 RID: 16017
	public PromptScript Prompt;

	// Token: 0x04003E92 RID: 16018
	public MechaScript Mecha;

	// Token: 0x04003E93 RID: 16019
	public AudioClip Tarp;

	// Token: 0x04003E94 RID: 16020
	public float PreviousSpeed;

	// Token: 0x04003E95 RID: 16021
	public float Speed;

	// Token: 0x04003E96 RID: 16022
	public bool Unwrap;
}
