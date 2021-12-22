using System;
using UnityEngine;

// Token: 0x0200046A RID: 1130
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001E88 RID: 7816 RVA: 0x001ABC06 File Offset: 0x001A9E06
	private void Awake()
	{
	}

	// Token: 0x170004AB RID: 1195
	// (get) Token: 0x06001E89 RID: 7817 RVA: 0x001ABC08 File Offset: 0x001A9E08
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001E8A RID: 7818 RVA: 0x001ABC18 File Offset: 0x001A9E18
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

	// Token: 0x04003F07 RID: 16135
	public UITexture Sprite;

	// Token: 0x04003F08 RID: 16136
	[SerializeField]
	private int Start;

	// Token: 0x04003F09 RID: 16137
	[SerializeField]
	private int Frame;

	// Token: 0x04003F0A RID: 16138
	[SerializeField]
	private int Limit;

	// Token: 0x04003F0B RID: 16139
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003F0C RID: 16140
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003F0D RID: 16141
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003F0E RID: 16142
	public int ID;
}
