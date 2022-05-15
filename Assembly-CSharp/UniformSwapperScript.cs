using System;
using UnityEngine;

// Token: 0x02000496 RID: 1174
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F5E RID: 8030 RVA: 0x001C017C File Offset: 0x001BE37C
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

	// Token: 0x06001F5F RID: 8031 RVA: 0x001C029B File Offset: 0x001BE49B
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x0400423B RID: 16955
	public Texture[] UniformTextures;

	// Token: 0x0400423C RID: 16956
	public Mesh[] UniformMeshes;

	// Token: 0x0400423D RID: 16957
	public Texture FaceTexture;

	// Token: 0x0400423E RID: 16958
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400423F RID: 16959
	public int UniformID;

	// Token: 0x04004240 RID: 16960
	public int FaceID;

	// Token: 0x04004241 RID: 16961
	public int SkinID;

	// Token: 0x04004242 RID: 16962
	public Transform LookTarget;

	// Token: 0x04004243 RID: 16963
	public Transform Head;
}
