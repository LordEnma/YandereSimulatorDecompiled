using System;
using UnityEngine;

// Token: 0x020000EE RID: 238
public class BlowtorchScript : MonoBehaviour
{
	// Token: 0x06000A4B RID: 2635 RVA: 0x0005BB73 File Offset: 0x00059D73
	private void Start()
	{
		this.Flame.localScale = Vector3.zero;
		base.enabled = false;
	}

	// Token: 0x06000A4C RID: 2636 RVA: 0x0005BB8C File Offset: 0x00059D8C
	private void Update()
	{
		this.Timer = Mathf.MoveTowards(this.Timer, 5f, Time.deltaTime);
		float num = UnityEngine.Random.Range(0.9f, 1f);
		this.Flame.localScale = new Vector3(num, num, num);
		if (this.Timer == 5f)
		{
			this.Flame.localScale = Vector3.zero;
			this.Yandere.Cauterizing = false;
			this.Yandere.CanMove = true;
			base.enabled = false;
			base.GetComponent<AudioSource>().Stop();
			this.Timer = 0f;
		}
	}

	// Token: 0x04000BCC RID: 3020
	public YandereScript Yandere;

	// Token: 0x04000BCD RID: 3021
	public RagdollScript Corpse;

	// Token: 0x04000BCE RID: 3022
	public PickUpScript PickUp;

	// Token: 0x04000BCF RID: 3023
	public PromptScript Prompt;

	// Token: 0x04000BD0 RID: 3024
	public Transform Flame;

	// Token: 0x04000BD1 RID: 3025
	public float Timer;
}
