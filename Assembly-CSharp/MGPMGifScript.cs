using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class MGPMGifScript : MonoBehaviour
{
	// Token: 0x0600002E RID: 46 RVA: 0x00004A90 File Offset: 0x00002C90
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.FPS)
		{
			this.ID++;
			if (this.ID == this.Frames.Length)
			{
				this.ID = 0;
			}
			this.MyRenderer.material.mainTexture = this.Frames[this.ID];
			this.Timer = 0f;
		}
	}

	// Token: 0x0400008A RID: 138
	public Texture[] Frames;

	// Token: 0x0400008B RID: 139
	public Renderer MyRenderer;

	// Token: 0x0400008C RID: 140
	public float Timer;

	// Token: 0x0400008D RID: 141
	public float FPS;

	// Token: 0x0400008E RID: 142
	public int ID;
}
