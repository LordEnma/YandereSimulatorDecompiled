using System;
using UnityEngine;

// Token: 0x02000494 RID: 1172
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F4B RID: 8011 RVA: 0x001BDB2C File Offset: 0x001BBD2C
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

	// Token: 0x06001F4C RID: 8012 RVA: 0x001BDC4B File Offset: 0x001BBE4B
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x04004207 RID: 16903
	public Texture[] UniformTextures;

	// Token: 0x04004208 RID: 16904
	public Mesh[] UniformMeshes;

	// Token: 0x04004209 RID: 16905
	public Texture FaceTexture;

	// Token: 0x0400420A RID: 16906
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400420B RID: 16907
	public int UniformID;

	// Token: 0x0400420C RID: 16908
	public int FaceID;

	// Token: 0x0400420D RID: 16909
	public int SkinID;

	// Token: 0x0400420E RID: 16910
	public Transform LookTarget;

	// Token: 0x0400420F RID: 16911
	public Transform Head;
}
