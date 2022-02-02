using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B45 RID: 6981 RVA: 0x0013249A File Offset: 0x0013069A
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B46 RID: 6982 RVA: 0x001324B4 File Offset: 0x001306B4
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B47 RID: 6983 RVA: 0x001324E7 File Offset: 0x001306E7
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002E96 RID: 11926
	public string[] AnimationNames;

	// Token: 0x04002E97 RID: 11927
	public string CurrentAnim = string.Empty;
}
