using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B6F RID: 7023 RVA: 0x001352DA File Offset: 0x001334DA
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B70 RID: 7024 RVA: 0x001352F4 File Offset: 0x001334F4
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B71 RID: 7025 RVA: 0x00135327 File Offset: 0x00133527
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002F13 RID: 12051
	public string[] AnimationNames;

	// Token: 0x04002F14 RID: 12052
	public string CurrentAnim = string.Empty;
}
