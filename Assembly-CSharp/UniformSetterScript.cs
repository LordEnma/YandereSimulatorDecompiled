using UnityEngine;

public class UniformSetterScript : MonoBehaviour
{
	public Texture[] FemaleUniformTextures;

	public Texture[] MaleUniformTextures;

	public SkinnedMeshRenderer MyRenderer;

	public Mesh[] FemaleUniforms;

	public Mesh[] MaleUniforms;

	public Texture SenpaiFace;

	public Texture SenpaiSkin;

	public Texture RyobaFace;

	public Texture AyanoFace;

	public Texture OsanaFace;

	public int FaceID;

	public int SkinID;

	public int UniformID;

	public int StudentID;

	public bool AttachHair;

	public bool Male;

	public Transform Head;

	public GameObject[] Hair;

	public int HairID;

	public int ForceUniform;

	public bool Ryoba;

	public Texture RyobaTexture;

	public void Start()
	{
		if (MyRenderer == null)
		{
			MyRenderer = base.transform.GetChild(0).GetChild(0).GetChild(0)
				.GetComponent<SkinnedMeshRenderer>();
		}
		if (Male)
		{
			SetMaleUniform();
		}
		else
		{
			SetFemaleUniform();
		}
		if (AttachHair)
		{
			GameObject obj = Object.Instantiate(Hair[HairID], base.transform.position, base.transform.rotation);
			Head = base.transform.Find("Character/PelvisRoot/Hips/Spine/Spine1/Spine2/Spine3/Neck/Head").transform;
			obj.transform.parent = Head;
		}
	}

	public void SetMaleUniform()
	{
		int num = StudentGlobals.MaleUniform;
		if (ForceUniform > 0)
		{
			num = ForceUniform;
		}
		MyRenderer.sharedMesh = MaleUniforms[num];
		switch (num)
		{
		case 1:
			SkinID = 0;
			UniformID = 1;
			FaceID = 2;
			break;
		case 2:
		case 3:
			UniformID = 0;
			FaceID = 1;
			SkinID = 2;
			break;
		case 4:
		case 5:
		case 6:
			FaceID = 0;
			SkinID = 1;
			UniformID = 2;
			break;
		}
		MyRenderer.materials[FaceID].mainTexture = SenpaiFace;
		MyRenderer.materials[SkinID].mainTexture = SenpaiSkin;
		MyRenderer.materials[UniformID].mainTexture = MaleUniformTextures[num];
	}

	public void SetFemaleUniform()
	{
		int num = StudentGlobals.FemaleUniform;
		if (ForceUniform > 0)
		{
			num = ForceUniform;
		}
		MyRenderer.sharedMesh = FemaleUniforms[num];
		MyRenderer.materials[0].mainTexture = FemaleUniformTextures[num];
		MyRenderer.materials[1].mainTexture = FemaleUniformTextures[num];
		if (Ryoba)
		{
			MyRenderer.materials[0].mainTexture = RyobaTexture;
			MyRenderer.materials[1].mainTexture = RyobaTexture;
		}
		if (StudentID == 0)
		{
			MyRenderer.materials[2].mainTexture = RyobaFace;
		}
		else if (StudentID == 1)
		{
			MyRenderer.materials[2].mainTexture = AyanoFace;
		}
		else
		{
			MyRenderer.materials[2].mainTexture = OsanaFace;
		}
	}
}
