using System;
using UnityEngine;

// Token: 0x0200048F RID: 1167
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001F2F RID: 7983 RVA: 0x001BB450 File Offset: 0x001B9650
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

	// Token: 0x06001F30 RID: 7984 RVA: 0x001BB500 File Offset: 0x001B9700
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

	// Token: 0x06001F31 RID: 7985 RVA: 0x001BB5EC File Offset: 0x001B97EC
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

	// Token: 0x040041B3 RID: 16819
	public Texture[] FemaleUniformTextures;

	// Token: 0x040041B4 RID: 16820
	public Texture[] MaleUniformTextures;

	// Token: 0x040041B5 RID: 16821
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040041B6 RID: 16822
	public Mesh[] FemaleUniforms;

	// Token: 0x040041B7 RID: 16823
	public Mesh[] MaleUniforms;

	// Token: 0x040041B8 RID: 16824
	public Texture SenpaiFace;

	// Token: 0x040041B9 RID: 16825
	public Texture SenpaiSkin;

	// Token: 0x040041BA RID: 16826
	public Texture RyobaFace;

	// Token: 0x040041BB RID: 16827
	public Texture AyanoFace;

	// Token: 0x040041BC RID: 16828
	public Texture OsanaFace;

	// Token: 0x040041BD RID: 16829
	public int FaceID;

	// Token: 0x040041BE RID: 16830
	public int SkinID;

	// Token: 0x040041BF RID: 16831
	public int UniformID;

	// Token: 0x040041C0 RID: 16832
	public int StudentID;

	// Token: 0x040041C1 RID: 16833
	public bool AttachHair;

	// Token: 0x040041C2 RID: 16834
	public bool Male;

	// Token: 0x040041C3 RID: 16835
	public Transform Head;

	// Token: 0x040041C4 RID: 16836
	public GameObject[] Hair;

	// Token: 0x040041C5 RID: 16837
	public int HairID;

	// Token: 0x040041C6 RID: 16838
	public int ForceUniform;
}
