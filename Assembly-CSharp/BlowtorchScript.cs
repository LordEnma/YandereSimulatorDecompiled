using System;
using UnityEngine;

// Token: 0x020000EC RID: 236
public class BlowtorchScript : MonoBehaviour
{
	// Token: 0x06000A46 RID: 2630 RVA: 0x0005B23F File Offset: 0x0005943F
	private void Start()
	{
		this.Flame.localScale = Vector3.zero;
		base.enabled = false;
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x0005B258 File Offset: 0x00059458
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

	// Token: 0x04000BB2 RID: 2994
	public YandereScript Yandere;

	// Token: 0x04000BB3 RID: 2995
	public RagdollScript Corpse;

	// Token: 0x04000BB4 RID: 2996
	public PickUpScript PickUp;

	// Token: 0x04000BB5 RID: 2997
	public PromptScript Prompt;

	// Token: 0x04000BB6 RID: 2998
	public Transform Flame;

	// Token: 0x04000BB7 RID: 2999
	public float Timer;
}
