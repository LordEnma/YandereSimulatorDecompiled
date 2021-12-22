using System;
using UnityEngine;

// Token: 0x02000488 RID: 1160
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001EF7 RID: 7927 RVA: 0x001B6280 File Offset: 0x001B4480
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

	// Token: 0x06001EF8 RID: 7928 RVA: 0x001B639F File Offset: 0x001B459F
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x04004119 RID: 16665
	public Texture[] UniformTextures;

	// Token: 0x0400411A RID: 16666
	public Mesh[] UniformMeshes;

	// Token: 0x0400411B RID: 16667
	public Texture FaceTexture;

	// Token: 0x0400411C RID: 16668
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400411D RID: 16669
	public int UniformID;

	// Token: 0x0400411E RID: 16670
	public int FaceID;

	// Token: 0x0400411F RID: 16671
	public int SkinID;

	// Token: 0x04004120 RID: 16672
	public Transform LookTarget;

	// Token: 0x04004121 RID: 16673
	public Transform Head;
}
