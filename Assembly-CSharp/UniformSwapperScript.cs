using System;
using UnityEngine;

// Token: 0x02000487 RID: 1159
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001EED RID: 7917 RVA: 0x001B54C4 File Offset: 0x001B36C4
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

	// Token: 0x06001EEE RID: 7918 RVA: 0x001B55E3 File Offset: 0x001B37E3
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x040040E9 RID: 16617
	public Texture[] UniformTextures;

	// Token: 0x040040EA RID: 16618
	public Mesh[] UniformMeshes;

	// Token: 0x040040EB RID: 16619
	public Texture FaceTexture;

	// Token: 0x040040EC RID: 16620
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040040ED RID: 16621
	public int UniformID;

	// Token: 0x040040EE RID: 16622
	public int FaceID;

	// Token: 0x040040EF RID: 16623
	public int SkinID;

	// Token: 0x040040F0 RID: 16624
	public Transform LookTarget;

	// Token: 0x040040F1 RID: 16625
	public Transform Head;
}
