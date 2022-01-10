using System;
using UnityEngine;

// Token: 0x0200048A RID: 1162
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F05 RID: 7941 RVA: 0x001B70D8 File Offset: 0x001B52D8
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

	// Token: 0x06001F06 RID: 7942 RVA: 0x001B71F7 File Offset: 0x001B53F7
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x04004134 RID: 16692
	public Texture[] UniformTextures;

	// Token: 0x04004135 RID: 16693
	public Mesh[] UniformMeshes;

	// Token: 0x04004136 RID: 16694
	public Texture FaceTexture;

	// Token: 0x04004137 RID: 16695
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004138 RID: 16696
	public int UniformID;

	// Token: 0x04004139 RID: 16697
	public int FaceID;

	// Token: 0x0400413A RID: 16698
	public int SkinID;

	// Token: 0x0400413B RID: 16699
	public Transform LookTarget;

	// Token: 0x0400413C RID: 16700
	public Transform Head;
}
