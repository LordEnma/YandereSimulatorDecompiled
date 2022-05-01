using System;
using UnityEngine;

// Token: 0x020003CF RID: 975
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B7D RID: 7037 RVA: 0x00135F7A File Offset: 0x0013417A
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B7E RID: 7038 RVA: 0x00135F94 File Offset: 0x00134194
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B7F RID: 7039 RVA: 0x00135FC7 File Offset: 0x001341C7
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002F2B RID: 12075
	public string[] AnimationNames;

	// Token: 0x04002F2C RID: 12076
	public string CurrentAnim = string.Empty;
}
