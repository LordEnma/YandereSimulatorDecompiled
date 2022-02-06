using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001E9D RID: 7837 RVA: 0x001AE0CA File Offset: 0x001AC2CA
	private void Awake()
	{
	}

	// Token: 0x170004AD RID: 1197
	// (get) Token: 0x06001E9E RID: 7838 RVA: 0x001AE0CC File Offset: 0x001AC2CC
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001E9F RID: 7839 RVA: 0x001AE0DC File Offset: 0x001AC2DC
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

	// Token: 0x04003F39 RID: 16185
	public UITexture Sprite;

	// Token: 0x04003F3A RID: 16186
	[SerializeField]
	private int Start;

	// Token: 0x04003F3B RID: 16187
	[SerializeField]
	private int Frame;

	// Token: 0x04003F3C RID: 16188
	[SerializeField]
	private int Limit;

	// Token: 0x04003F3D RID: 16189
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003F3E RID: 16190
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003F3F RID: 16191
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003F40 RID: 16192
	public int ID;
}
