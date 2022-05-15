using System;
using UnityEngine;

// Token: 0x020003D0 RID: 976
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B83 RID: 7043 RVA: 0x00136B92 File Offset: 0x00134D92
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B84 RID: 7044 RVA: 0x00136BAC File Offset: 0x00134DAC
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B85 RID: 7045 RVA: 0x00136BDF File Offset: 0x00134DDF
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002F40 RID: 12096
	public string[] AnimationNames;

	// Token: 0x04002F41 RID: 12097
	public string CurrentAnim = string.Empty;
}
