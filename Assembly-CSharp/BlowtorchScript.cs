using System;
using UnityEngine;

// Token: 0x020000ED RID: 237
public class BlowtorchScript : MonoBehaviour
{
	// Token: 0x06000A49 RID: 2633 RVA: 0x0005B407 File Offset: 0x00059607
	private void Start()
	{
		this.Flame.localScale = Vector3.zero;
		base.enabled = false;
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x0005B420 File Offset: 0x00059620
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

	// Token: 0x04000BB6 RID: 2998
	public YandereScript Yandere;

	// Token: 0x04000BB7 RID: 2999
	public RagdollScript Corpse;

	// Token: 0x04000BB8 RID: 3000
	public PickUpScript PickUp;

	// Token: 0x04000BB9 RID: 3001
	public PromptScript Prompt;

	// Token: 0x04000BBA RID: 3002
	public Transform Flame;

	// Token: 0x04000BBB RID: 3003
	public float Timer;
}
