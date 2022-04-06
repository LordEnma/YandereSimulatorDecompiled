using System;
using UnityEngine;

// Token: 0x020003CF RID: 975
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B75 RID: 7029 RVA: 0x001354F2 File Offset: 0x001336F2
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B76 RID: 7030 RVA: 0x0013550C File Offset: 0x0013370C
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B77 RID: 7031 RVA: 0x0013553F File Offset: 0x0013373F
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002F16 RID: 12054
	public string[] AnimationNames;

	// Token: 0x04002F17 RID: 12055
	public string CurrentAnim = string.Empty;
}
