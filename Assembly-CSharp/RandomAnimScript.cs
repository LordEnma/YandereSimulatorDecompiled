using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B44 RID: 6980 RVA: 0x00131E86 File Offset: 0x00130086
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B45 RID: 6981 RVA: 0x00131EA0 File Offset: 0x001300A0
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B46 RID: 6982 RVA: 0x00131ED3 File Offset: 0x001300D3
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002E8C RID: 11916
	public string[] AnimationNames;

	// Token: 0x04002E8D RID: 11917
	public string CurrentAnim = string.Empty;
}
