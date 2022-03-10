using System;
using UnityEngine;

// Token: 0x0200048C RID: 1164
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001F1D RID: 7965 RVA: 0x001B9CD0 File Offset: 0x001B7ED0
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

	// Token: 0x06001F1E RID: 7966 RVA: 0x001B9D80 File Offset: 0x001B7F80
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

	// Token: 0x06001F1F RID: 7967 RVA: 0x001B9E6C File Offset: 0x001B806C
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

	// Token: 0x04004168 RID: 16744
	public Texture[] FemaleUniformTextures;

	// Token: 0x04004169 RID: 16745
	public Texture[] MaleUniformTextures;

	// Token: 0x0400416A RID: 16746
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400416B RID: 16747
	public Mesh[] FemaleUniforms;

	// Token: 0x0400416C RID: 16748
	public Mesh[] MaleUniforms;

	// Token: 0x0400416D RID: 16749
	public Texture SenpaiFace;

	// Token: 0x0400416E RID: 16750
	public Texture SenpaiSkin;

	// Token: 0x0400416F RID: 16751
	public Texture RyobaFace;

	// Token: 0x04004170 RID: 16752
	public Texture AyanoFace;

	// Token: 0x04004171 RID: 16753
	public Texture OsanaFace;

	// Token: 0x04004172 RID: 16754
	public int FaceID;

	// Token: 0x04004173 RID: 16755
	public int SkinID;

	// Token: 0x04004174 RID: 16756
	public int UniformID;

	// Token: 0x04004175 RID: 16757
	public int StudentID;

	// Token: 0x04004176 RID: 16758
	public bool AttachHair;

	// Token: 0x04004177 RID: 16759
	public bool Male;

	// Token: 0x04004178 RID: 16760
	public Transform Head;

	// Token: 0x04004179 RID: 16761
	public GameObject[] Hair;

	// Token: 0x0400417A RID: 16762
	public int HairID;

	// Token: 0x0400417B RID: 16763
	public int ForceUniform;
}
