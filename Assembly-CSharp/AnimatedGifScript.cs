using System;
using UnityEngine;

// Token: 0x020000C9 RID: 201
public class AnimatedGifScript : MonoBehaviour
{
	// Token: 0x060009BA RID: 2490 RVA: 0x00051122 File Offset: 0x0004F322
	private void Awake()
	{
	}

	// Token: 0x170001F4 RID: 500
	// (get) Token: 0x060009BB RID: 2491 RVA: 0x00051124 File Offset: 0x0004F324
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x060009BC RID: 2492 RVA: 0x00051134 File Offset: 0x0004F334
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

	// Token: 0x04000A10 RID: 2576
	[SerializeField]
	private UISprite Sprite;

	// Token: 0x04000A11 RID: 2577
	[SerializeField]
	private string SpriteName;

	// Token: 0x04000A12 RID: 2578
	[SerializeField]
	private int Start;

	// Token: 0x04000A13 RID: 2579
	[SerializeField]
	private int Frame;

	// Token: 0x04000A14 RID: 2580
	[SerializeField]
	private int Limit;

	// Token: 0x04000A15 RID: 2581
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04000A16 RID: 2582
	[SerializeField]
	private float CurrentSeconds;
}
