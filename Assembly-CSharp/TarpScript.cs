using System;
using UnityEngine;

// Token: 0x02000466 RID: 1126
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001E80 RID: 7808 RVA: 0x001AC87E File Offset: 0x001AAA7E
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001E81 RID: 7809 RVA: 0x001AC8A0 File Offset: 0x001AAAA0
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

	// Token: 0x04003EF3 RID: 16115
	public PromptScript Prompt;

	// Token: 0x04003EF4 RID: 16116
	public MechaScript Mecha;

	// Token: 0x04003EF5 RID: 16117
	public AudioClip Tarp;

	// Token: 0x04003EF6 RID: 16118
	public float PreviousSpeed;

	// Token: 0x04003EF7 RID: 16119
	public float Speed;

	// Token: 0x04003EF8 RID: 16120
	public bool Unwrap;
}
