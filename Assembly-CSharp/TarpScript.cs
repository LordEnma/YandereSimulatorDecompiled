using System;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class TarpScript : MonoBehaviour
{
	// Token: 0x06001EBB RID: 7867 RVA: 0x001B188E File Offset: 0x001AFA8E
	private void Start()
	{
		base.transform.localScale = new Vector3(1f, 1f, 1f);
	}

	// Token: 0x06001EBC RID: 7868 RVA: 0x001B18B0 File Offset: 0x001AFAB0
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

	// Token: 0x04003FAB RID: 16299
	public PromptScript Prompt;

	// Token: 0x04003FAC RID: 16300
	public MechaScript Mecha;

	// Token: 0x04003FAD RID: 16301
	public AudioClip Tarp;

	// Token: 0x04003FAE RID: 16302
	public float PreviousSpeed;

	// Token: 0x04003FAF RID: 16303
	public float Speed;

	// Token: 0x04003FB0 RID: 16304
	public bool Unwrap;
}
