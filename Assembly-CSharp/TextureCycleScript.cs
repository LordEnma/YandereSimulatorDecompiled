using System;
using UnityEngine;

// Token: 0x02000477 RID: 1143
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001EEA RID: 7914 RVA: 0x001B592A File Offset: 0x001B3B2A
	private void Awake()
	{
	}

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06001EEB RID: 7915 RVA: 0x001B592C File Offset: 0x001B3B2C
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001EEC RID: 7916 RVA: 0x001B593C File Offset: 0x001B3B3C
	private void Update()
	{
		this.ID++;
		if (this.ID > 1)
		{
			this.ID = 0;
			this.Frame++;
			if (this.Frame > this.Limit)
			{
				this.Frame = this.Start;
			}
		}
		this.Sprite.mainTexture = this.Textures[this.Frame];
	}

	// Token: 0x04004027 RID: 16423
	public UITexture Sprite;

	// Token: 0x04004028 RID: 16424
	[SerializeField]
	private int Start;

	// Token: 0x04004029 RID: 16425
	[SerializeField]
	private int Frame;

	// Token: 0x0400402A RID: 16426
	[SerializeField]
	private int Limit;

	// Token: 0x0400402B RID: 16427
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x0400402C RID: 16428
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x0400402D RID: 16429
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x0400402E RID: 16430
	public int ID;
}
