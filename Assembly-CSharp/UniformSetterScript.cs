using System;
using UnityEngine;

// Token: 0x0200048A RID: 1162
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001F0A RID: 7946 RVA: 0x001B8590 File Offset: 0x001B6790
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

	// Token: 0x06001F0B RID: 7947 RVA: 0x001B8640 File Offset: 0x001B6840
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

	// Token: 0x06001F0C RID: 7948 RVA: 0x001B872C File Offset: 0x001B692C
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

	// Token: 0x04004138 RID: 16696
	public Texture[] FemaleUniformTextures;

	// Token: 0x04004139 RID: 16697
	public Texture[] MaleUniformTextures;

	// Token: 0x0400413A RID: 16698
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400413B RID: 16699
	public Mesh[] FemaleUniforms;

	// Token: 0x0400413C RID: 16700
	public Mesh[] MaleUniforms;

	// Token: 0x0400413D RID: 16701
	public Texture SenpaiFace;

	// Token: 0x0400413E RID: 16702
	public Texture SenpaiSkin;

	// Token: 0x0400413F RID: 16703
	public Texture RyobaFace;

	// Token: 0x04004140 RID: 16704
	public Texture AyanoFace;

	// Token: 0x04004141 RID: 16705
	public Texture OsanaFace;

	// Token: 0x04004142 RID: 16706
	public int FaceID;

	// Token: 0x04004143 RID: 16707
	public int SkinID;

	// Token: 0x04004144 RID: 16708
	public int UniformID;

	// Token: 0x04004145 RID: 16709
	public int StudentID;

	// Token: 0x04004146 RID: 16710
	public bool AttachHair;

	// Token: 0x04004147 RID: 16711
	public bool Male;

	// Token: 0x04004148 RID: 16712
	public Transform Head;

	// Token: 0x04004149 RID: 16713
	public GameObject[] Hair;

	// Token: 0x0400414A RID: 16714
	public int HairID;

	// Token: 0x0400414B RID: 16715
	public int ForceUniform;
}
