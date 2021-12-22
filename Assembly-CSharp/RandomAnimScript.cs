using System;
using UnityEngine;

// Token: 0x020003C6 RID: 966
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B3B RID: 6971 RVA: 0x001316EE File Offset: 0x0012F8EE
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B3C RID: 6972 RVA: 0x00131708 File Offset: 0x0012F908
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B3D RID: 6973 RVA: 0x0013173B File Offset: 0x0012F93B
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002E7F RID: 11903
	public string[] AnimationNames;

	// Token: 0x04002E80 RID: 11904
	public string CurrentAnim = string.Empty;
}
