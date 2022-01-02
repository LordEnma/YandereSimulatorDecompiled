using System;
using UnityEngine;

// Token: 0x020000C9 RID: 201
public class AnimatedGifScript : MonoBehaviour
{
	// Token: 0x060009BA RID: 2490 RVA: 0x0005112A File Offset: 0x0004F32A
	private void Awake()
	{
	}

	// Token: 0x170001F4 RID: 500
	// (get) Token: 0x060009BB RID: 2491 RVA: 0x0005112C File Offset: 0x0004F32C
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x060009BC RID: 2492 RVA: 0x0005113C File Offset: 0x0004F33C
	private void Update()
	{
		this.CurrentSeconds += Time.unscaledDeltaTime;
		while (this.CurrentSeconds >= this.SecondsPerFrame)
		{
			this.CurrentSeconds -= this.SecondsPerFrame;
			this.Frame++;
			if (this.Frame > this.Limit)
			{
				this.Frame = this.Start;
			}
		}
		this.Sprite.spriteName = this.SpriteName + this.Frame.ToString();
	}

	// Token: 0x04000A0E RID: 2574
	[SerializeField]
	private UISprite Sprite;

	// Token: 0x04000A0F RID: 2575
	[SerializeField]
	private string SpriteName;

	// Token: 0x04000A10 RID: 2576
	[SerializeField]
	private int Start;

	// Token: 0x04000A11 RID: 2577
	[SerializeField]
	private int Frame;

	// Token: 0x04000A12 RID: 2578
	[SerializeField]
	private int Limit;

	// Token: 0x04000A13 RID: 2579
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04000A14 RID: 2580
	[SerializeField]
	private float CurrentSeconds;
}
