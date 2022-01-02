using System;
using UnityEngine;

// Token: 0x02000488 RID: 1160
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001EFA RID: 7930 RVA: 0x001B6758 File Offset: 0x001B4958
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

	// Token: 0x06001EFB RID: 7931 RVA: 0x001B6877 File Offset: 0x001B4A77
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x04004120 RID: 16672
	public Texture[] UniformTextures;

	// Token: 0x04004121 RID: 16673
	public Mesh[] UniformMeshes;

	// Token: 0x04004122 RID: 16674
	public Texture FaceTexture;

	// Token: 0x04004123 RID: 16675
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004124 RID: 16676
	public int UniformID;

	// Token: 0x04004125 RID: 16677
	public int FaceID;

	// Token: 0x04004126 RID: 16678
	public int SkinID;

	// Token: 0x04004127 RID: 16679
	public Transform LookTarget;

	// Token: 0x04004128 RID: 16680
	public Transform Head;
}
