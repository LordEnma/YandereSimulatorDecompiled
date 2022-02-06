using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B47 RID: 6983 RVA: 0x00132736 File Offset: 0x00130936
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B48 RID: 6984 RVA: 0x00132750 File Offset: 0x00130950
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B49 RID: 6985 RVA: 0x00132783 File Offset: 0x00130983
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002E9A RID: 11930
	public string[] AnimationNames;

	// Token: 0x04002E9B RID: 11931
	public string CurrentAnim = string.Empty;
}
