using System;
using UnityEngine;

// Token: 0x020003C6 RID: 966
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B3D RID: 6973 RVA: 0x00131AEA File Offset: 0x0012FCEA
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B3E RID: 6974 RVA: 0x00131B04 File Offset: 0x0012FD04
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B3F RID: 6975 RVA: 0x00131B37 File Offset: 0x0012FD37
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002E86 RID: 11910
	public string[] AnimationNames;

	// Token: 0x04002E87 RID: 11911
	public string CurrentAnim = string.Empty;
}
