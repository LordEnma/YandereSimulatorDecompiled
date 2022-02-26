using System;
using UnityEngine;

// Token: 0x020003CA RID: 970
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B57 RID: 6999 RVA: 0x001334AE File Offset: 0x001316AE
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B58 RID: 7000 RVA: 0x001334C8 File Offset: 0x001316C8
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B59 RID: 7001 RVA: 0x001334FB File Offset: 0x001316FB
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002EB0 RID: 11952
	public string[] AnimationNames;

	// Token: 0x04002EB1 RID: 11953
	public string CurrentAnim = string.Empty;
}
