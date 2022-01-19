using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F07 RID: 7943 RVA: 0x001B7DA8 File Offset: 0x001B5FA8
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

	// Token: 0x06001F08 RID: 7944 RVA: 0x001B7EC7 File Offset: 0x001B60C7
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x0400413B RID: 16699
	public Texture[] UniformTextures;

	// Token: 0x0400413C RID: 16700
	public Mesh[] UniformMeshes;

	// Token: 0x0400413D RID: 16701
	public Texture FaceTexture;

	// Token: 0x0400413E RID: 16702
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400413F RID: 16703
	public int UniformID;

	// Token: 0x04004140 RID: 16704
	public int FaceID;

	// Token: 0x04004141 RID: 16705
	public int SkinID;

	// Token: 0x04004142 RID: 16706
	public Transform LookTarget;

	// Token: 0x04004143 RID: 16707
	public Transform Head;
}
