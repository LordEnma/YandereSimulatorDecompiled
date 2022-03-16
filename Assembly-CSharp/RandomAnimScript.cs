using System;
using UnityEngine;

// Token: 0x020003CB RID: 971
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B65 RID: 7013 RVA: 0x00134866 File Offset: 0x00132A66
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B66 RID: 7014 RVA: 0x00134880 File Offset: 0x00132A80
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B67 RID: 7015 RVA: 0x001348B3 File Offset: 0x00132AB3
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002EFA RID: 12026
	public string[] AnimationNames;

	// Token: 0x04002EFB RID: 12027
	public string CurrentAnim = string.Empty;
}
