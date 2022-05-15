using System;
using UnityEngine;

// Token: 0x02000495 RID: 1173
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001F5A RID: 8026 RVA: 0x001BFF10 File Offset: 0x001BE110
	public void Start()
	{
		if (this.MyRenderer == null)
		{
			this.MyRenderer = base.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>();
		}
		if (this.Male)
		{
			this.SetMaleUniform();
		}
		else
		{
			this.SetFemaleUniform();
		}
		if (this.AttachHair)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Hair[this.HairID], base.transform.position, base.transform.rotation);
			this.Head = base.transform.Find("Character/PelvisRoot/Hips/Spine/Spine1/Spine2/Spine3/Neck/Head").transform;
			gameObject.transform.parent = this.Head;
		}
	}

	// Token: 0x06001F5B RID: 8027 RVA: 0x001BFFC0 File Offset: 0x001BE1C0
	public void SetMaleUniform()
	{
		int num = StudentGlobals.MaleUniform;
		if (this.ForceUniform > 0)
		{
			num = this.ForceUniform;
		}
		this.MyRenderer.sharedMesh = this.MaleUniforms[num];
		if (num == 1)
		{
			this.SkinID = 0;
			this.UniformID = 1;
			this.FaceID = 2;
		}
		else if (num == 2 || num == 3)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (num == 4 || num == 5 || num == 6)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		this.MyRenderer.materials[this.FaceID].mainTexture = this.SenpaiFace;
		this.MyRenderer.materials[this.SkinID].mainTexture = this.SenpaiSkin;
		this.MyRenderer.materials[this.UniformID].mainTexture = this.MaleUniformTextures[num];
	}

	// Token: 0x06001F5C RID: 8028 RVA: 0x001C00AC File Offset: 0x001BE2AC
	public void SetFemaleUniform()
	{
		int num = StudentGlobals.FemaleUniform;
		if (this.ForceUniform > 0)
		{
			num = this.ForceUniform;
		}
		this.MyRenderer.sharedMesh = this.FemaleUniforms[num];
		this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[num];
		this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[num];
		if (this.StudentID == 0)
		{
			this.MyRenderer.materials[2].mainTexture = this.RyobaFace;
			return;
		}
		if (this.StudentID == 1)
		{
			this.MyRenderer.materials[2].mainTexture = this.AyanoFace;
			return;
		}
		this.MyRenderer.materials[2].mainTexture = this.OsanaFace;
	}

	// Token: 0x04004227 RID: 16935
	public Texture[] FemaleUniformTextures;

	// Token: 0x04004228 RID: 16936
	public Texture[] MaleUniformTextures;

	// Token: 0x04004229 RID: 16937
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400422A RID: 16938
	public Mesh[] FemaleUniforms;

	// Token: 0x0400422B RID: 16939
	public Mesh[] MaleUniforms;

	// Token: 0x0400422C RID: 16940
	public Texture SenpaiFace;

	// Token: 0x0400422D RID: 16941
	public Texture SenpaiSkin;

	// Token: 0x0400422E RID: 16942
	public Texture RyobaFace;

	// Token: 0x0400422F RID: 16943
	public Texture AyanoFace;

	// Token: 0x04004230 RID: 16944
	public Texture OsanaFace;

	// Token: 0x04004231 RID: 16945
	public int FaceID;

	// Token: 0x04004232 RID: 16946
	public int SkinID;

	// Token: 0x04004233 RID: 16947
	public int UniformID;

	// Token: 0x04004234 RID: 16948
	public int StudentID;

	// Token: 0x04004235 RID: 16949
	public bool AttachHair;

	// Token: 0x04004236 RID: 16950
	public bool Male;

	// Token: 0x04004237 RID: 16951
	public Transform Head;

	// Token: 0x04004238 RID: 16952
	public GameObject[] Hair;

	// Token: 0x04004239 RID: 16953
	public int HairID;

	// Token: 0x0400423A RID: 16954
	public int ForceUniform;
}
