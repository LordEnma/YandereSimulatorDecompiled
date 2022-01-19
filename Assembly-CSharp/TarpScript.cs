using System;
using UnityEngine;

// Token: 0x02000466 RID: 1126
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001E7A RID: 7802 RVA: 0x001ABEBE File Offset: 0x001AA0BE
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001E7B RID: 7803 RVA: 0x001ABEE0 File Offset: 0x001AA0E0
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

	// Token: 0x04003EE3 RID: 16099
	public PromptScript Prompt;

	// Token: 0x04003EE4 RID: 16100
	public MechaScript Mecha;

	// Token: 0x04003EE5 RID: 16101
	public AudioClip Tarp;

	// Token: 0x04003EE6 RID: 16102
	public float PreviousSpeed;

	// Token: 0x04003EE7 RID: 16103
	public float Speed;

	// Token: 0x04003EE8 RID: 16104
	public bool Unwrap;
}
