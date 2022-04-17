using System;
using UnityEngine;

// Token: 0x020000ED RID: 237
public class BlowtorchScript : MonoBehaviour
{
	// Token: 0x06000A49 RID: 2633 RVA: 0x0005B6D7 File Offset: 0x000598D7
	private void Start()
	{
		this.Flame.localScale = Vector3.zero;
		base.enabled = false;
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x0005B6F0 File Offset: 0x000598F0
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

	// Token: 0x04000BC5 RID: 3013
	public YandereScript Yandere;

	// Token: 0x04000BC6 RID: 3014
	public RagdollScript Corpse;

	// Token: 0x04000BC7 RID: 3015
	public PickUpScript PickUp;

	// Token: 0x04000BC8 RID: 3016
	public PromptScript Prompt;

	// Token: 0x04000BC9 RID: 3017
	public Transform Flame;

	// Token: 0x04000BCA RID: 3018
	public float Timer;
}
