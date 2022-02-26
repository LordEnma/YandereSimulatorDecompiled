using System;
using UnityEngine;

// Token: 0x0200046F RID: 1135
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001EAD RID: 7853 RVA: 0x001AF0BE File Offset: 0x001AD2BE
	private void Awake()
	{
	}

	// Token: 0x170004AE RID: 1198
	// (get) Token: 0x06001EAE RID: 7854 RVA: 0x001AF0C0 File Offset: 0x001AD2C0
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001EAF RID: 7855 RVA: 0x001AF0D0 File Offset: 0x001AD2D0
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

	// Token: 0x04003F52 RID: 16210
	public UITexture Sprite;

	// Token: 0x04003F53 RID: 16211
	[SerializeField]
	private int Start;

	// Token: 0x04003F54 RID: 16212
	[SerializeField]
	private int Frame;

	// Token: 0x04003F55 RID: 16213
	[SerializeField]
	private int Limit;

	// Token: 0x04003F56 RID: 16214
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003F57 RID: 16215
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003F58 RID: 16216
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003F59 RID: 16217
	public int ID;
}
