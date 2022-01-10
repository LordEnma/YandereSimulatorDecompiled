using System;
using UnityEngine;

// Token: 0x02000465 RID: 1125
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001E78 RID: 7800 RVA: 0x001AB1EE File Offset: 0x001A93EE
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001E79 RID: 7801 RVA: 0x001AB210 File Offset: 0x001A9410
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

	// Token: 0x04003EDC RID: 16092
	public PromptScript Prompt;

	// Token: 0x04003EDD RID: 16093
	public MechaScript Mecha;

	// Token: 0x04003EDE RID: 16094
	public AudioClip Tarp;

	// Token: 0x04003EDF RID: 16095
	public float PreviousSpeed;

	// Token: 0x04003EE0 RID: 16096
	public float Speed;

	// Token: 0x04003EE1 RID: 16097
	public bool Unwrap;
}
