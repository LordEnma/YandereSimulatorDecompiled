using System;
using UnityEngine;

// Token: 0x02000490 RID: 1168
public class UniformSwapperScript : MonoBehaviour
{
	// Token: 0x06001F33 RID: 7987 RVA: 0x001BB6BC File Offset: 0x001B98BC
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

	// Token: 0x06001F34 RID: 7988 RVA: 0x001BB7DB File Offset: 0x001B99DB
	private void LateUpdate()
	{
		if (this.LookTarget != null)
		{
			this.Head.LookAt(this.LookTarget);
		}
	}

	// Token: 0x040041C7 RID: 16839
	public Texture[] UniformTextures;

	// Token: 0x040041C8 RID: 16840
	public Mesh[] UniformMeshes;

	// Token: 0x040041C9 RID: 16841
	public Texture FaceTexture;

	// Token: 0x040041CA RID: 16842
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040041CB RID: 16843
	public int UniformID;

	// Token: 0x040041CC RID: 16844
	public int FaceID;

	// Token: 0x040041CD RID: 16845
	public int SkinID;

	// Token: 0x040041CE RID: 16846
	public Transform LookTarget;

	// Token: 0x040041CF RID: 16847
	public Transform Head;
}
