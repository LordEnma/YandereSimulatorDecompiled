using System;
using UnityEngine;

// Token: 0x0200048A RID: 1162
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001F05 RID: 7941 RVA: 0x001B8064 File Offset: 0x001B6264
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

	// Token: 0x06001F06 RID: 7942 RVA: 0x001B8114 File Offset: 0x001B6314
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

	// Token: 0x06001F07 RID: 7943 RVA: 0x001B8200 File Offset: 0x001B6400
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

	// Token: 0x0400412F RID: 16687
	public Texture[] FemaleUniformTextures;

	// Token: 0x04004130 RID: 16688
	public Texture[] MaleUniformTextures;

	// Token: 0x04004131 RID: 16689
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004132 RID: 16690
	public Mesh[] FemaleUniforms;

	// Token: 0x04004133 RID: 16691
	public Mesh[] MaleUniforms;

	// Token: 0x04004134 RID: 16692
	public Texture SenpaiFace;

	// Token: 0x04004135 RID: 16693
	public Texture SenpaiSkin;

	// Token: 0x04004136 RID: 16694
	public Texture RyobaFace;

	// Token: 0x04004137 RID: 16695
	public Texture AyanoFace;

	// Token: 0x04004138 RID: 16696
	public Texture OsanaFace;

	// Token: 0x04004139 RID: 16697
	public int FaceID;

	// Token: 0x0400413A RID: 16698
	public int SkinID;

	// Token: 0x0400413B RID: 16699
	public int UniformID;

	// Token: 0x0400413C RID: 16700
	public int StudentID;

	// Token: 0x0400413D RID: 16701
	public bool AttachHair;

	// Token: 0x0400413E RID: 16702
	public bool Male;

	// Token: 0x0400413F RID: 16703
	public Transform Head;

	// Token: 0x04004140 RID: 16704
	public GameObject[] Hair;

	// Token: 0x04004141 RID: 16705
	public int HairID;

	// Token: 0x04004142 RID: 16706
	public int ForceUniform;
}
