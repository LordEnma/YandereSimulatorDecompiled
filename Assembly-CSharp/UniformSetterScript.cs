using System;
using UnityEngine;

// Token: 0x0200048C RID: 1164
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001F1A RID: 7962 RVA: 0x001B9530 File Offset: 0x001B7730
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

	// Token: 0x06001F1B RID: 7963 RVA: 0x001B95E0 File Offset: 0x001B77E0
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

	// Token: 0x06001F1C RID: 7964 RVA: 0x001B96CC File Offset: 0x001B78CC
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

	// Token: 0x04004151 RID: 16721
	public Texture[] FemaleUniformTextures;

	// Token: 0x04004152 RID: 16722
	public Texture[] MaleUniformTextures;

	// Token: 0x04004153 RID: 16723
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04004154 RID: 16724
	public Mesh[] FemaleUniforms;

	// Token: 0x04004155 RID: 16725
	public Mesh[] MaleUniforms;

	// Token: 0x04004156 RID: 16726
	public Texture SenpaiFace;

	// Token: 0x04004157 RID: 16727
	public Texture SenpaiSkin;

	// Token: 0x04004158 RID: 16728
	public Texture RyobaFace;

	// Token: 0x04004159 RID: 16729
	public Texture AyanoFace;

	// Token: 0x0400415A RID: 16730
	public Texture OsanaFace;

	// Token: 0x0400415B RID: 16731
	public int FaceID;

	// Token: 0x0400415C RID: 16732
	public int SkinID;

	// Token: 0x0400415D RID: 16733
	public int UniformID;

	// Token: 0x0400415E RID: 16734
	public int StudentID;

	// Token: 0x0400415F RID: 16735
	public bool AttachHair;

	// Token: 0x04004160 RID: 16736
	public bool Male;

	// Token: 0x04004161 RID: 16737
	public Transform Head;

	// Token: 0x04004162 RID: 16738
	public GameObject[] Hair;

	// Token: 0x04004163 RID: 16739
	public int HairID;

	// Token: 0x04004164 RID: 16740
	public int ForceUniform;
}
