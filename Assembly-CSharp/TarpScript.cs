using System;
using UnityEngine;

// Token: 0x02000466 RID: 1126
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001E7B RID: 7803 RVA: 0x001AC352 File Offset: 0x001AA552
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001E7C RID: 7804 RVA: 0x001AC374 File Offset: 0x001AA574
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

	// Token: 0x04003EEA RID: 16106
	public PromptScript Prompt;

	// Token: 0x04003EEB RID: 16107
	public MechaScript Mecha;

	// Token: 0x04003EEC RID: 16108
	public AudioClip Tarp;

	// Token: 0x04003EED RID: 16109
	public float PreviousSpeed;

	// Token: 0x04003EEE RID: 16110
	public float Speed;

	// Token: 0x04003EEF RID: 16111
	public bool Unwrap;
}
