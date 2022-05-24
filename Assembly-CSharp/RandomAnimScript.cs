using System;
using UnityEngine;

// Token: 0x020003D0 RID: 976
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B84 RID: 7044 RVA: 0x00136E2E File Offset: 0x0013502E
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B85 RID: 7045 RVA: 0x00136E48 File Offset: 0x00135048
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B86 RID: 7046 RVA: 0x00136E7B File Offset: 0x0013507B
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002F48 RID: 12104
	public string[] AnimationNames;

	// Token: 0x04002F49 RID: 12105
	public string CurrentAnim = string.Empty;
}
