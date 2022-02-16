using System;
using UnityEngine;

// Token: 0x020003C9 RID: 969
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B4E RID: 6990 RVA: 0x00132A66 File Offset: 0x00130C66
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B4F RID: 6991 RVA: 0x00132A80 File Offset: 0x00130C80
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B50 RID: 6992 RVA: 0x00132AB3 File Offset: 0x00130CB3
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002EA0 RID: 11936
	public string[] AnimationNames;

	// Token: 0x04002EA1 RID: 11937
	public string CurrentAnim = string.Empty;
}
