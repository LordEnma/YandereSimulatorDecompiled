using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class RandomAnimScript : MonoBehaviour
{
	// Token: 0x06001B45 RID: 6981 RVA: 0x0013259E File Offset: 0x0013079E
	private void Start()
	{
		this.PickRandomAnim();
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x06001B46 RID: 6982 RVA: 0x001325B8 File Offset: 0x001307B8
	private void Update()
	{
		AnimationState animationState = base.GetComponent<Animation>()[this.CurrentAnim];
		if (animationState.time >= animationState.length)
		{
			this.PickRandomAnim();
		}
	}

	// Token: 0x06001B47 RID: 6983 RVA: 0x001325EB File Offset: 0x001307EB
	private void PickRandomAnim()
	{
		this.CurrentAnim = this.AnimationNames[UnityEngine.Random.Range(0, this.AnimationNames.Length)];
		base.GetComponent<Animation>().CrossFade(this.CurrentAnim);
	}

	// Token: 0x04002E97 RID: 11927
	public string[] AnimationNames;

	// Token: 0x04002E98 RID: 11928
	public string CurrentAnim = string.Empty;
}
