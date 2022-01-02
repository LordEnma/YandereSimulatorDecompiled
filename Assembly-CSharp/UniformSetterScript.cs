using System;
using UnityEngine;

// Token: 0x02000487 RID: 1159
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001EF6 RID: 7926 RVA: 0x001B64EC File Offset: 0x001B46EC
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

	// Token: 0x06001EF7 RID: 7927 RVA: 0x001B659C File Offset: 0x001B479C
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

	// Token: 0x06001EF8 RID: 7928 RVA: 0x001B6688 File Offset: 0x001B4888
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

	// Token: 0x0400410C RID: 16652
	public Texture[] FemaleUniformTextures;

	// Token: 0x0400410D RID: 16653
	public Texture[] MaleUniformTextures;

	// Token: 0x0400410E RID: 16654
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400410F RID: 16655
	public Mesh[] FemaleUniforms;

	// Token: 0x04004110 RID: 16656
	public Mesh[] MaleUniforms;

	// Token: 0x04004111 RID: 16657
	public Texture SenpaiFace;

	// Token: 0x04004112 RID: 16658
	public Texture SenpaiSkin;

	// Token: 0x04004113 RID: 16659
	public Texture RyobaFace;

	// Token: 0x04004114 RID: 16660
	public Texture AyanoFace;

	// Token: 0x04004115 RID: 16661
	public Texture OsanaFace;

	// Token: 0x04004116 RID: 16662
	public int FaceID;

	// Token: 0x04004117 RID: 16663
	public int SkinID;

	// Token: 0x04004118 RID: 16664
	public int UniformID;

	// Token: 0x04004119 RID: 16665
	public int StudentID;

	// Token: 0x0400411A RID: 16666
	public bool AttachHair;

	// Token: 0x0400411B RID: 16667
	public bool Male;

	// Token: 0x0400411C RID: 16668
	public Transform Head;

	// Token: 0x0400411D RID: 16669
	public GameObject[] Hair;

	// Token: 0x0400411E RID: 16670
	public int HairID;

	// Token: 0x0400411F RID: 16671
	public int ForceUniform;
}
