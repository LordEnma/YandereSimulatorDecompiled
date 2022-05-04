using System;
using UnityEngine;

// Token: 0x02000494 RID: 1172
public class UniformSetterScript : MonoBehaviour
{
	// Token: 0x06001F51 RID: 8017 RVA: 0x001BED78 File Offset: 0x001BCF78
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

	// Token: 0x06001F52 RID: 8018 RVA: 0x001BEE28 File Offset: 0x001BD028
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

	// Token: 0x06001F53 RID: 8019 RVA: 0x001BEF14 File Offset: 0x001BD114
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

	// Token: 0x04004209 RID: 16905
	public Texture[] FemaleUniformTextures;

	// Token: 0x0400420A RID: 16906
	public Texture[] MaleUniformTextures;

	// Token: 0x0400420B RID: 16907
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x0400420C RID: 16908
	public Mesh[] FemaleUniforms;

	// Token: 0x0400420D RID: 16909
	public Mesh[] MaleUniforms;

	// Token: 0x0400420E RID: 16910
	public Texture SenpaiFace;

	// Token: 0x0400420F RID: 16911
	public Texture SenpaiSkin;

	// Token: 0x04004210 RID: 16912
	public Texture RyobaFace;

	// Token: 0x04004211 RID: 16913
	public Texture AyanoFace;

	// Token: 0x04004212 RID: 16914
	public Texture OsanaFace;

	// Token: 0x04004213 RID: 16915
	public int FaceID;

	// Token: 0x04004214 RID: 16916
	public int SkinID;

	// Token: 0x04004215 RID: 16917
	public int UniformID;

	// Token: 0x04004216 RID: 16918
	public int StudentID;

	// Token: 0x04004217 RID: 16919
	public bool AttachHair;

	// Token: 0x04004218 RID: 16920
	public bool Male;

	// Token: 0x04004219 RID: 16921
	public Transform Head;

	// Token: 0x0400421A RID: 16922
	public GameObject[] Hair;

	// Token: 0x0400421B RID: 16923
	public int HairID;

	// Token: 0x0400421C RID: 16924
	public int ForceUniform;
}
