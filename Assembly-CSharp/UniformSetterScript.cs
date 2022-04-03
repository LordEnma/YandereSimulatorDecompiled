using System;
using UnityEngine;

// Token: 0x02000492 RID: 1170
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001F39 RID: 7993 RVA: 0x001BC9DC File Offset: 0x001BABDC
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

	// Token: 0x06001F3A RID: 7994 RVA: 0x001BCA8C File Offset: 0x001BAC8C
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

	// Token: 0x06001F3B RID: 7995 RVA: 0x001BCB78 File Offset: 0x001BAD78
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

	// Token: 0x040041E0 RID: 16864
	public Texture[] FemaleUniformTextures;

	// Token: 0x040041E1 RID: 16865
	public Texture[] MaleUniformTextures;

	// Token: 0x040041E2 RID: 16866
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040041E3 RID: 16867
	public Mesh[] FemaleUniforms;

	// Token: 0x040041E4 RID: 16868
	public Mesh[] MaleUniforms;

	// Token: 0x040041E5 RID: 16869
	public Texture SenpaiFace;

	// Token: 0x040041E6 RID: 16870
	public Texture SenpaiSkin;

	// Token: 0x040041E7 RID: 16871
	public Texture RyobaFace;

	// Token: 0x040041E8 RID: 16872
	public Texture AyanoFace;

	// Token: 0x040041E9 RID: 16873
	public Texture OsanaFace;

	// Token: 0x040041EA RID: 16874
	public int FaceID;

	// Token: 0x040041EB RID: 16875
	public int SkinID;

	// Token: 0x040041EC RID: 16876
	public int UniformID;

	// Token: 0x040041ED RID: 16877
	public int StudentID;

	// Token: 0x040041EE RID: 16878
	public bool AttachHair;

	// Token: 0x040041EF RID: 16879
	public bool Male;

	// Token: 0x040041F0 RID: 16880
	public Transform Head;

	// Token: 0x040041F1 RID: 16881
	public GameObject[] Hair;

	// Token: 0x040041F2 RID: 16882
	public int HairID;

	// Token: 0x040041F3 RID: 16883
	public int ForceUniform;
}
