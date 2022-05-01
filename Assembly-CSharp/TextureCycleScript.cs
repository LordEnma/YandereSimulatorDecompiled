using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001EE1 RID: 7905 RVA: 0x001B46B6 File Offset: 0x001B28B6
	private void Awake()
	{
	}

	// Token: 0x170004B0 RID: 1200
	// (get) Token: 0x06001EE2 RID: 7906 RVA: 0x001B46B8 File Offset: 0x001B28B8
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001EE3 RID: 7907 RVA: 0x001B46C8 File Offset: 0x001B28C8
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

	// Token: 0x04004009 RID: 16393
	public UITexture Sprite;

	// Token: 0x0400400A RID: 16394
	[SerializeField]
	private int Start;

	// Token: 0x0400400B RID: 16395
	[SerializeField]
	private int Frame;

	// Token: 0x0400400C RID: 16396
	[SerializeField]
	private int Limit;

	// Token: 0x0400400D RID: 16397
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x0400400E RID: 16398
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x0400400F RID: 16399
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04004010 RID: 16400
	public int ID;
}
