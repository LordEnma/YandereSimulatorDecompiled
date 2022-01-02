using System;
using UnityEngine;

// Token: 0x02000463 RID: 1123
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001E6D RID: 7789 RVA: 0x001AA86E File Offset: 0x001A8A6E
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001E6E RID: 7790 RVA: 0x001AA890 File Offset: 0x001A8A90
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

	// Token: 0x04003EC8 RID: 16072
	public PromptScript Prompt;

	// Token: 0x04003EC9 RID: 16073
	public MechaScript Mecha;

	// Token: 0x04003ECA RID: 16074
	public AudioClip Tarp;

	// Token: 0x04003ECB RID: 16075
	public float PreviousSpeed;

	// Token: 0x04003ECC RID: 16076
	public float Speed;

	// Token: 0x04003ECD RID: 16077
	public bool Unwrap;
}
