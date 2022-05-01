using System;
using UnityEngine;

// Token: 0x02000495 RID: 1173
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F54 RID: 8020 RVA: 0x001BEEE8 File Offset: 0x001BD0E8
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

	// Token: 0x06001F55 RID: 8021 RVA: 0x001BF007 File Offset: 0x001BD207
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x0400421D RID: 16925
	public Texture[] UniformTextures;

	// Token: 0x0400421E RID: 16926
	public Mesh[] UniformMeshes;

	// Token: 0x0400421F RID: 16927
	public Texture FaceTexture;

	// Token: 0x04004220 RID: 16928
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004221 RID: 16929
	public int UniformID;

	// Token: 0x04004222 RID: 16930
	public int FaceID;

	// Token: 0x04004223 RID: 16931
	public int SkinID;

	// Token: 0x04004224 RID: 16932
	public Transform LookTarget;

	// Token: 0x04004225 RID: 16933
	public Transform Head;
}
