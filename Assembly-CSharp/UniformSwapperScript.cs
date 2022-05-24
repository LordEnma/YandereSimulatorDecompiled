using System;
using UnityEngine;

// Token: 0x02000496 RID: 1174
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F5F RID: 8031 RVA: 0x001C05F8 File Offset: 0x001BE7F8
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

	// Token: 0x06001F60 RID: 8032 RVA: 0x001C0717 File Offset: 0x001BE917
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x04004244 RID: 16964
	public Texture[] UniformTextures;

	// Token: 0x04004245 RID: 16965
	public Mesh[] UniformMeshes;

	// Token: 0x04004246 RID: 16966
	public Texture FaceTexture;

	// Token: 0x04004247 RID: 16967
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004248 RID: 16968
	public int UniformID;

	// Token: 0x04004249 RID: 16969
	public int FaceID;

	// Token: 0x0400424A RID: 16970
	public int SkinID;

	// Token: 0x0400424B RID: 16971
	public Transform LookTarget;

	// Token: 0x0400424C RID: 16972
	public Transform Head;
}
