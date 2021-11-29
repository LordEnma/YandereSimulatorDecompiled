using System;
using UnityEngine;

// Token: 0x02000486 RID: 1158
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001EE9 RID: 7913 RVA: 0x001B5258 File Offset: 0x001B3458
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

	// Token: 0x06001EEA RID: 7914 RVA: 0x001B5308 File Offset: 0x001B3508
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

	// Token: 0x06001EEB RID: 7915 RVA: 0x001B53F4 File Offset: 0x001B35F4
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

	// Token: 0x040040D5 RID: 16597
	public Texture[] FemaleUniformTextures;

	// Token: 0x040040D6 RID: 16598
	public Texture[] MaleUniformTextures;

	// Token: 0x040040D7 RID: 16599
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040040D8 RID: 16600
	public Mesh[] FemaleUniforms;

	// Token: 0x040040D9 RID: 16601
	public Mesh[] MaleUniforms;

	// Token: 0x040040DA RID: 16602
	public Texture SenpaiFace;

	// Token: 0x040040DB RID: 16603
	public Texture SenpaiSkin;

	// Token: 0x040040DC RID: 16604
	public Texture RyobaFace;

	// Token: 0x040040DD RID: 16605
	public Texture AyanoFace;

	// Token: 0x040040DE RID: 16606
	public Texture OsanaFace;

	// Token: 0x040040DF RID: 16607
	public int FaceID;

	// Token: 0x040040E0 RID: 16608
	public int SkinID;

	// Token: 0x040040E1 RID: 16609
	public int UniformID;

	// Token: 0x040040E2 RID: 16610
	public int StudentID;

	// Token: 0x040040E3 RID: 16611
	public bool AttachHair;

	// Token: 0x040040E4 RID: 16612
	public bool Male;

	// Token: 0x040040E5 RID: 16613
	public Transform Head;

	// Token: 0x040040E6 RID: 16614
	public GameObject[] Hair;

	// Token: 0x040040E7 RID: 16615
	public int HairID;

	// Token: 0x040040E8 RID: 16616
	public int ForceUniform;
}
