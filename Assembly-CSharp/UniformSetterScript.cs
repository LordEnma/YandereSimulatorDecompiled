using System;
using UnityEngine;

// Token: 0x02000493 RID: 1171
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001F47 RID: 8007 RVA: 0x001BD8C0 File Offset: 0x001BBAC0
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

	// Token: 0x06001F48 RID: 8008 RVA: 0x001BD970 File Offset: 0x001BBB70
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

	// Token: 0x06001F49 RID: 8009 RVA: 0x001BDA5C File Offset: 0x001BBC5C
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

	// Token: 0x040041F3 RID: 16883
	public Texture[] FemaleUniformTextures;

	// Token: 0x040041F4 RID: 16884
	public Texture[] MaleUniformTextures;

	// Token: 0x040041F5 RID: 16885
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040041F6 RID: 16886
	public Mesh[] FemaleUniforms;

	// Token: 0x040041F7 RID: 16887
	public Mesh[] MaleUniforms;

	// Token: 0x040041F8 RID: 16888
	public Texture SenpaiFace;

	// Token: 0x040041F9 RID: 16889
	public Texture SenpaiSkin;

	// Token: 0x040041FA RID: 16890
	public Texture RyobaFace;

	// Token: 0x040041FB RID: 16891
	public Texture AyanoFace;

	// Token: 0x040041FC RID: 16892
	public Texture OsanaFace;

	// Token: 0x040041FD RID: 16893
	public int FaceID;

	// Token: 0x040041FE RID: 16894
	public int SkinID;

	// Token: 0x040041FF RID: 16895
	public int UniformID;

	// Token: 0x04004200 RID: 16896
	public int StudentID;

	// Token: 0x04004201 RID: 16897
	public bool AttachHair;

	// Token: 0x04004202 RID: 16898
	public bool Male;

	// Token: 0x04004203 RID: 16899
	public Transform Head;

	// Token: 0x04004204 RID: 16900
	public GameObject[] Hair;

	// Token: 0x04004205 RID: 16901
	public int HairID;

	// Token: 0x04004206 RID: 16902
	public int ForceUniform;
}
