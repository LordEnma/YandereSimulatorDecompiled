using System;
using UnityEngine;

// Token: 0x0200046A RID: 1130
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001EA3 RID: 7843 RVA: 0x001AF6A6 File Offset: 0x001AD8A6
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001EA4 RID: 7844 RVA: 0x001AF6C8 File Offset: 0x001AD8C8
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

	// Token: 0x04003F6D RID: 16237
	public PromptScript Prompt;

	// Token: 0x04003F6E RID: 16238
	public MechaScript Mecha;

	// Token: 0x04003F6F RID: 16239
	public AudioClip Tarp;

	// Token: 0x04003F70 RID: 16240
	public float PreviousSpeed;

	// Token: 0x04003F71 RID: 16241
	public float Speed;

	// Token: 0x04003F72 RID: 16242
	public bool Unwrap;
}
