using System;
using UnityEngine;

// Token: 0x0200048C RID: 1164
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F15 RID: 7957 RVA: 0x001B8C50 File Offset: 0x001B6E50
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

	// Token: 0x06001F16 RID: 7958 RVA: 0x001B8D6F File Offset: 0x001B6F6F
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x04004155 RID: 16725
	public Texture[] UniformTextures;

	// Token: 0x04004156 RID: 16726
	public Mesh[] UniformMeshes;

	// Token: 0x04004157 RID: 16727
	public Texture FaceTexture;

	// Token: 0x04004158 RID: 16728
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004159 RID: 16729
	public int UniformID;

	// Token: 0x0400415A RID: 16730
	public int FaceID;

	// Token: 0x0400415B RID: 16731
	public int SkinID;

	// Token: 0x0400415C RID: 16732
	public Transform LookTarget;

	// Token: 0x0400415D RID: 16733
	public Transform Head;
}
