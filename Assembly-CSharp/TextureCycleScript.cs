using System;
using UnityEngine;

// Token: 0x02000475 RID: 1141
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001ED2 RID: 7890 RVA: 0x001B296E File Offset: 0x001B0B6E
	private void Awake()
	{
	}

	// Token: 0x170004AF RID: 1199
	// (get) Token: 0x06001ED3 RID: 7891 RVA: 0x001B2970 File Offset: 0x001B0B70
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001ED4 RID: 7892 RVA: 0x001B2980 File Offset: 0x001B0B80
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

	// Token: 0x04003FE3 RID: 16355
	public UITexture Sprite;

	// Token: 0x04003FE4 RID: 16356
	[SerializeField]
	private int Start;

	// Token: 0x04003FE5 RID: 16357
	[SerializeField]
	private int Frame;

	// Token: 0x04003FE6 RID: 16358
	[SerializeField]
	private int Limit;

	// Token: 0x04003FE7 RID: 16359
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04003FE8 RID: 16360
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04003FE9 RID: 16361
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04003FEA RID: 16362
	public int ID;
}
