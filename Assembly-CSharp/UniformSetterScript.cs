using System;
using UnityEngine;

// Token: 0x02000487 RID: 1159
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001EF3 RID: 7923 RVA: 0x001B6014 File Offset: 0x001B4214
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

	// Token: 0x06001EF4 RID: 7924 RVA: 0x001B60C4 File Offset: 0x001B42C4
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

	// Token: 0x06001EF5 RID: 7925 RVA: 0x001B61B0 File Offset: 0x001B43B0
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

	// Token: 0x04004105 RID: 16645
	public Texture[] FemaleUniformTextures;

	// Token: 0x04004106 RID: 16646
	public Texture[] MaleUniformTextures;

	// Token: 0x04004107 RID: 16647
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004108 RID: 16648
	public Mesh[] FemaleUniforms;

	// Token: 0x04004109 RID: 16649
	public Mesh[] MaleUniforms;

	// Token: 0x0400410A RID: 16650
	public Texture SenpaiFace;

	// Token: 0x0400410B RID: 16651
	public Texture SenpaiSkin;

	// Token: 0x0400410C RID: 16652
	public Texture RyobaFace;

	// Token: 0x0400410D RID: 16653
	public Texture AyanoFace;

	// Token: 0x0400410E RID: 16654
	public Texture OsanaFace;

	// Token: 0x0400410F RID: 16655
	public int FaceID;

	// Token: 0x04004110 RID: 16656
	public int SkinID;

	// Token: 0x04004111 RID: 16657
	public int UniformID;

	// Token: 0x04004112 RID: 16658
	public int StudentID;

	// Token: 0x04004113 RID: 16659
	public bool AttachHair;

	// Token: 0x04004114 RID: 16660
	public bool Male;

	// Token: 0x04004115 RID: 16661
	public Transform Head;

	// Token: 0x04004116 RID: 16662
	public GameObject[] Hair;

	// Token: 0x04004117 RID: 16663
	public int HairID;

	// Token: 0x04004118 RID: 16664
	public int ForceUniform;
}
