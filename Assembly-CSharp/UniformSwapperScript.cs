using System;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F1E RID: 7966 RVA: 0x001B979C File Offset: 0x001B799C
	private void Start()
	{
		int maleUniform = StudentGlobals.MaleUniform;
		this.MyRenderer.sharedMesh = this.UniformMeshes[maleUniform];
		Texture mainTexture = this.UniformTextures[maleUniform];
		if (maleUniform == 1)
		{
			this.SkinID = 0;
			this.UniformID = 1;
			this.FaceID = 2;
		}
		else if (maleUniform == 2)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (maleUniform == 3)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (maleUniform == 4)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (maleUniform == 5)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (maleUniform == 6)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
		this.MyRenderer.materials[this.SkinID].mainTexture = mainTexture;
		this.MyRenderer.materials[this.UniformID].mainTexture = mainTexture;
	}

	// Token: 0x06001F1F RID: 7967 RVA: 0x001B98BB File Offset: 0x001B7ABB
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x04004165 RID: 16741
	public Texture[] UniformTextures;

	// Token: 0x04004166 RID: 16742
	public Mesh[] UniformMeshes;

	// Token: 0x04004167 RID: 16743
	public Texture FaceTexture;

	// Token: 0x04004168 RID: 16744
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004169 RID: 16745
	public int UniformID;

	// Token: 0x0400416A RID: 16746
	public int FaceID;

	// Token: 0x0400416B RID: 16747
	public int SkinID;

	// Token: 0x0400416C RID: 16748
	public Transform LookTarget;

	// Token: 0x0400416D RID: 16749
	public Transform Head;
}
