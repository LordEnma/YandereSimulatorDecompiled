using System;
using UnityEngine;

// Token: 0x0200048D RID: 1165
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F21 RID: 7969 RVA: 0x001B9F3C File Offset: 0x001B813C
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

	// Token: 0x06001F22 RID: 7970 RVA: 0x001BA05B File Offset: 0x001B825B
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x0400417C RID: 16764
	public Texture[] UniformTextures;

	// Token: 0x0400417D RID: 16765
	public Mesh[] UniformMeshes;

	// Token: 0x0400417E RID: 16766
	public Texture FaceTexture;

	// Token: 0x0400417F RID: 16767
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004180 RID: 16768
	public int UniformID;

	// Token: 0x04004181 RID: 16769
	public int FaceID;

	// Token: 0x04004182 RID: 16770
	public int SkinID;

	// Token: 0x04004183 RID: 16771
	public Transform LookTarget;

	// Token: 0x04004184 RID: 16772
	public Transform Head;
}
