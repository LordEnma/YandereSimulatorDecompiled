using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001E97 RID: 7831 RVA: 0x001AD70A File Offset: 0x001AB90A
	private void Awake()
	{
	}

	// Token: 0x170004AC RID: 1196
	// (get) Token: 0x06001E98 RID: 7832 RVA: 0x001AD70C File Offset: 0x001AB90C
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001E99 RID: 7833 RVA: 0x001AD71C File Offset: 0x001AB91C
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

	// Token: 0x04003F29 RID: 16169
	public UITexture Sprite;

	// Token: 0x04003F2A RID: 16170
	[SerializeField]
	private int Start;

	// Token: 0x04003F2B RID: 16171
	[SerializeField]
	private int Frame;

	// Token: 0x04003F2C RID: 16172
	[SerializeField]
	private int Limit;

	// Token: 0x04003F2D RID: 16173
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003F2E RID: 16174
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003F2F RID: 16175
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003F30 RID: 16176
	public int ID;
}
