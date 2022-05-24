using System;
using UnityEngine;

// Token: 0x02000477 RID: 1143
public class TextureCycleScript : MonoBehaviour
{
	// Token: 0x06001EEB RID: 7915 RVA: 0x001B5DBA File Offset: 0x001B3FBA
	private void Awake()
	{
	}

	// Token: 0x170004B1 RID: 1201
	// (get) Token: 0x06001EEC RID: 7916 RVA: 0x001B5DBC File Offset: 0x001B3FBC
	private float SecondsPerFrame
	{
		get
		{
			return 1f / this.FramesPerSecond;
		}
	}

	// Token: 0x06001EED RID: 7917 RVA: 0x001B5DCC File Offset: 0x001B3FCC
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

	// Token: 0x04004030 RID: 16432
	public UITexture Sprite;

	// Token: 0x04004031 RID: 16433
	[SerializeField]
	private int Start;

	// Token: 0x04004032 RID: 16434
	[SerializeField]
	private int Frame;

	// Token: 0x04004033 RID: 16435
	[SerializeField]
	private int Limit;

	// Token: 0x04004034 RID: 16436
	[SerializeField]
	private float FramesPerSecond;

	// Token: 0x04004035 RID: 16437
	[SerializeField]
	private float CurrentSeconds;

	// Token: 0x04004036 RID: 16438
	[SerializeField]
	private Texture[] Textures;

	// Token: 0x04004037 RID: 16439
	public int ID;
}
