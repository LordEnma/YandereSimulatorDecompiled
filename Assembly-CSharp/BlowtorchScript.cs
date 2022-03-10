using System;
using UnityEngine;

// Token: 0x020000ED RID: 237
public class BlowtorchScript : MonoBehaviour
{
	// Token: 0x06000A49 RID: 2633 RVA: 0x0005B533 File Offset: 0x00059733
	private void Start()
	{
		this.Flame.localScale = Vector3.zero;
		base.enabled = false;
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x0005B54C File Offset: 0x0005974C
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

	// Token: 0x04000BBF RID: 3007
	public YandereScript Yandere;

	// Token: 0x04000BC0 RID: 3008
	public RagdollScript Corpse;

	// Token: 0x04000BC1 RID: 3009
	public PickUpScript PickUp;

	// Token: 0x04000BC2 RID: 3010
	public PromptScript Prompt;

	// Token: 0x04000BC3 RID: 3011
	public Transform Flame;

	// Token: 0x04000BC4 RID: 3012
	public float Timer;
}
