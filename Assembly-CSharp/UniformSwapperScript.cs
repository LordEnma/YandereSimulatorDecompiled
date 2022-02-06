using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F0E RID: 7950 RVA: 0x001B87FC File Offset: 0x001B69FC
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

	// Token: 0x06001F0F RID: 7951 RVA: 0x001B891B File Offset: 0x001B6B1B
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x0400414C RID: 16716
	public Texture[] UniformTextures;

	// Token: 0x0400414D RID: 16717
	public Mesh[] UniformMeshes;

	// Token: 0x0400414E RID: 16718
	public Texture FaceTexture;

	// Token: 0x0400414F RID: 16719
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004150 RID: 16720
	public int UniformID;

	// Token: 0x04004151 RID: 16721
	public int FaceID;

	// Token: 0x04004152 RID: 16722
	public int SkinID;

	// Token: 0x04004153 RID: 16723
	public Transform LookTarget;

	// Token: 0x04004154 RID: 16724
	public Transform Head;
}
