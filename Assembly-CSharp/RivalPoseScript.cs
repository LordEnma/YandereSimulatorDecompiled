using System;
using UnityEngine;

// Token: 0x020000D0 RID: 208
public class RivalPoseScript : MonoBehaviour
{
	// Token: 0x060009D3 RID: 2515 RVA: 0x00051DEC File Offset: 0x0004FFEC
	private void Start()
	{
		int femaleUniform = StudentGlobals.FemaleUniform;
		this.MyRenderer.sharedMesh = this.FemaleUniforms[femaleUniform];
		if (femaleUniform == 1)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
			return;
		}
		if (femaleUniform == 2)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.HairTexture;
			return;
		}
		if (femaleUniform == 3)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
			return;
		}
		if (femaleUniform == 4)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
			return;
		}
		if (femaleUniform == 5)
		{
			this.MyRenderer.materials[0].mainTexture = this.HairTexture;
			this.MyRenderer.materials[1].mainTexture = this.HairTexture;
			this.MyRenderer.materials[2].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[3].mainTexture = this.FemaleUniformTextures[femaleUniform];
			return;
		}
		if (femaleUniform == 6)
		{
			this.MyRenderer.materials[0].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[1].mainTexture = this.FemaleUniformTextures[femaleUniform];
			this.MyRenderer.materials[2].mainTexture = this.HairTexture;
			this.MyRenderer.materials[3].mainTexture = this.HairTexture;
		}
	}

	// Token: 0x04000A59 RID: 2649
	public GameObject Character;

	// Token: 0x04000A5A RID: 2650
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04000A5B RID: 2651
	public Texture[] FemaleUniformTextures;

	// Token: 0x04000A5C RID: 2652
	public Mesh[] FemaleUniforms;

	// Token: 0x04000A5D RID: 2653
	public Texture[] TestTextures;

	// Token: 0x04000A5E RID: 2654
	public Texture HairTexture;

	// Token: 0x04000A5F RID: 2655
	public string[] AnimNames;

	// Token: 0x04000A60 RID: 2656
	public int ID = -1;
}
