using System;
using UnityEngine;

// Token: 0x020003C5 RID: 965
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B33 RID: 6963 RVA: 0x00130E2E File Offset: 0x0012F02E
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B34 RID: 6964 RVA: 0x00130E48 File Offset: 0x0012F048
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B35 RID: 6965 RVA: 0x00130E7B File Offset: 0x0012F07B
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002E55 RID: 11861
	public string[] AnimationNames;

	// Token: 0x04002E56 RID: 11862
	public string CurrentAnim = string.Empty;
}
