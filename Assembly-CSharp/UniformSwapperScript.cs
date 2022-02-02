using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F09 RID: 7945 RVA: 0x001B82D0 File Offset: 0x001B64D0
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

	// Token: 0x06001F0A RID: 7946 RVA: 0x001B83EF File Offset: 0x001B65EF
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x04004143 RID: 16707
	public Texture[] UniformTextures;

	// Token: 0x04004144 RID: 16708
	public Mesh[] UniformMeshes;

	// Token: 0x04004145 RID: 16709
	public Texture FaceTexture;

	// Token: 0x04004146 RID: 16710
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004147 RID: 16711
	public int UniformID;

	// Token: 0x04004148 RID: 16712
	public int FaceID;

	// Token: 0x04004149 RID: 16713
	public int SkinID;

	// Token: 0x0400414A RID: 16714
	public Transform LookTarget;

	// Token: 0x0400414B RID: 16715
	public Transform Head;
}
