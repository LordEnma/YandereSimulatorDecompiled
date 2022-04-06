using System;
using UnityEngine;

// Token: 0x02000494 RID: 1172
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F45 RID: 8005 RVA: 0x001BD150 File Offset: 0x001BB350
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

	// Token: 0x06001F46 RID: 8006 RVA: 0x001BD26F File Offset: 0x001BB46F
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x040041F7 RID: 16887
	public Texture[] UniformTextures;

	// Token: 0x040041F8 RID: 16888
	public Mesh[] UniformMeshes;

	// Token: 0x040041F9 RID: 16889
	public Texture FaceTexture;

	// Token: 0x040041FA RID: 16890
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040041FB RID: 16891
	public int UniformID;

	// Token: 0x040041FC RID: 16892
	public int FaceID;

	// Token: 0x040041FD RID: 16893
	public int SkinID;

	// Token: 0x040041FE RID: 16894
	public Transform LookTarget;

	// Token: 0x040041FF RID: 16895
	public Transform Head;
}
