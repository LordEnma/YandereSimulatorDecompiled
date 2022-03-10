using System;
using UnityEngine;

// Token: 0x0200046F RID: 1135
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001EB0 RID: 7856 RVA: 0x001AF7E6 File Offset: 0x001AD9E6
	private void Awake()
	{
	}

	// Token: 0x170004AE RID: 1198
	// (get) Token: 0x06001EB1 RID: 7857 RVA: 0x001AF7E8 File Offset: 0x001AD9E8
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001EB2 RID: 7858 RVA: 0x001AF7F8 File Offset: 0x001AD9F8
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

	// Token: 0x04003F69 RID: 16233
	public UITexture Sprite;

	// Token: 0x04003F6A RID: 16234
	[SerializeField]
	private int Start;

	// Token: 0x04003F6B RID: 16235
	[SerializeField]
	private int Frame;

	// Token: 0x04003F6C RID: 16236
	[SerializeField]
	private int Limit;

	// Token: 0x04003F6D RID: 16237
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003F6E RID: 16238
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003F6F RID: 16239
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003F70 RID: 16240
	public int ID;
}
