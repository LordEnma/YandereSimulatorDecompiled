using System;
using UnityEngine;

// Token: 0x020003CA RID: 970
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B58 RID: 7000 RVA: 0x001339C6 File Offset: 0x00131BC6
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B59 RID: 7001 RVA: 0x001339E0 File Offset: 0x00131BE0
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B5A RID: 7002 RVA: 0x00133A13 File Offset: 0x00131C13
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002EC6 RID: 11974
	public string[] AnimationNames;

	// Token: 0x04002EC7 RID: 11975
	public string CurrentAnim = string.Empty;
}
