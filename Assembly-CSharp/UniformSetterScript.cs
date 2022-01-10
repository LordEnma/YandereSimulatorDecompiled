using System;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001F01 RID: 7937 RVA: 0x001B6E6C File Offset: 0x001B506C
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

	// Token: 0x06001F02 RID: 7938 RVA: 0x001B6F1C File Offset: 0x001B511C
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

	// Token: 0x06001F03 RID: 7939 RVA: 0x001B7008 File Offset: 0x001B5208
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

	// Token: 0x04004120 RID: 16672
	public Texture[] FemaleUniformTextures;

	// Token: 0x04004121 RID: 16673
	public Texture[] MaleUniformTextures;

	// Token: 0x04004122 RID: 16674
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004123 RID: 16675
	public Mesh[] FemaleUniforms;

	// Token: 0x04004124 RID: 16676
	public Mesh[] MaleUniforms;

	// Token: 0x04004125 RID: 16677
	public Texture SenpaiFace;

	// Token: 0x04004126 RID: 16678
	public Texture SenpaiSkin;

	// Token: 0x04004127 RID: 16679
	public Texture RyobaFace;

	// Token: 0x04004128 RID: 16680
	public Texture AyanoFace;

	// Token: 0x04004129 RID: 16681
	public Texture OsanaFace;

	// Token: 0x0400412A RID: 16682
	public int FaceID;

	// Token: 0x0400412B RID: 16683
	public int SkinID;

	// Token: 0x0400412C RID: 16684
	public int UniformID;

	// Token: 0x0400412D RID: 16685
	public int StudentID;

	// Token: 0x0400412E RID: 16686
	public bool AttachHair;

	// Token: 0x0400412F RID: 16687
	public bool Male;

	// Token: 0x04004130 RID: 16688
	public Transform Head;

	// Token: 0x04004131 RID: 16689
	public GameObject[] Hair;

	// Token: 0x04004132 RID: 16690
	public int HairID;

	// Token: 0x04004133 RID: 16691
	public int ForceUniform;
}
