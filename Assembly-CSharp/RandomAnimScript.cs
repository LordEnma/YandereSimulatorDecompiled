using System;
using UnityEngine;

// Token: 0x020003CF RID: 975
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B79 RID: 7033 RVA: 0x00135902 File Offset: 0x00133B02
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B7A RID: 7034 RVA: 0x0013591C File Offset: 0x00133B1C
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B7B RID: 7035 RVA: 0x0013594F File Offset: 0x00133B4F
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002F21 RID: 12065
	public string[] AnimationNames;

	// Token: 0x04002F22 RID: 12066
	public string CurrentAnim = string.Empty;
}
