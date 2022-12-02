using UnityEngine;

public class RivalPoseScript : MonoBehaviour
{
	public GameObject Character;

	public SkinnedMeshRenderer MyRenderer;

	public Texture[] FemaleUniformTextures;

	public Mesh[] FemaleUniforms;

	public Texture[] TestTextures;

	public Texture HairTexture;

	public string[] AnimNames;

	public int ID = -1;

	private void Start()
	{
		int femaleUniform = StudentGlobals.FemaleUniform;
		MyRenderer.sharedMesh = FemaleUniforms[femaleUniform];
		switch (femaleUniform)
		{
		case 1:
			MyRenderer.materials[0].mainTexture = FemaleUniformTextures[femaleUniform];
			MyRenderer.materials[1].mainTexture = HairTexture;
			MyRenderer.materials[2].mainTexture = HairTexture;
			MyRenderer.materials[3].mainTexture = FemaleUniformTextures[femaleUniform];
			break;
		case 2:
			MyRenderer.materials[0].mainTexture = FemaleUniformTextures[femaleUniform];
			MyRenderer.materials[1].mainTexture = FemaleUniformTextures[femaleUniform];
			MyRenderer.materials[2].mainTexture = HairTexture;
			MyRenderer.materials[3].mainTexture = HairTexture;
			break;
		case 3:
			MyRenderer.materials[0].mainTexture = HairTexture;
			MyRenderer.materials[1].mainTexture = HairTexture;
			MyRenderer.materials[2].mainTexture = FemaleUniformTextures[femaleUniform];
			MyRenderer.materials[3].mainTexture = FemaleUniformTextures[femaleUniform];
			break;
		case 4:
			MyRenderer.materials[0].mainTexture = HairTexture;
			MyRenderer.materials[1].mainTexture = HairTexture;
			MyRenderer.materials[2].mainTexture = FemaleUniformTextures[femaleUniform];
			MyRenderer.materials[3].mainTexture = FemaleUniformTextures[femaleUniform];
			break;
		case 5:
			MyRenderer.materials[0].mainTexture = HairTexture;
			MyRenderer.materials[1].mainTexture = HairTexture;
			MyRenderer.materials[2].mainTexture = FemaleUniformTextures[femaleUniform];
			MyRenderer.materials[3].mainTexture = FemaleUniformTextures[femaleUniform];
			break;
		case 6:
			MyRenderer.materials[0].mainTexture = FemaleUniformTextures[femaleUniform];
			MyRenderer.materials[1].mainTexture = FemaleUniformTextures[femaleUniform];
			MyRenderer.materials[2].mainTexture = HairTexture;
			MyRenderer.materials[3].mainTexture = HairTexture;
			break;
		}
	}
}
