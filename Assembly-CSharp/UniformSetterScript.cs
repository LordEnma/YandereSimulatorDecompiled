using System.Collections;
using UnityEngine;

public class UniformSetterScript : MonoBehaviour
{
	public CustomUniformScript CustomUniform;

	public Texture[] FemaleUniformTextures;

	public Texture[] MaleUniformTextures;

	public SkinnedMeshRenderer MyRenderer;

	public Renderer RightEye;

	public Renderer LeftEye;

	public Mesh[] FemaleUniforms;

	public Mesh[] MaleUniforms;

	public Texture SenpaiFace;

	public Texture SenpaiSkin;

	public Texture RyobaFace;

	public Texture AyanoFace;

	public Texture OsanaFace;

	public Texture Nude;

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

	public bool Street;

	public bool Ryoba;

	public Texture RyobaTexture;

	public Texture[] VTuberFaces;

	public Texture OriginalFemaleUniformTexture1;

	public Texture OriginalFemaleUniformTexture2;

	public Texture OriginalFemaleUniformTexture3;

	public Texture OriginalFemaleUniformTexture4;

	public Texture OriginalMaleUniformTexture1;

	public Texture OriginalMaleUniformTexture2;

	public Texture OriginalMaleUniformTexture3;

	public Texture OriginalMaleUniformTexture4;

	public void Start()
	{
		if (VTuberFaces != null && VTuberFaces.Length != 0 && GameGlobals.VtuberID > 0)
		{
			AyanoFace = VTuberFaces[GameGlobals.VtuberID];
			if (RightEye != null)
			{
				RightEye.material.mainTexture = AyanoFace;
				LeftEye.material.mainTexture = AyanoFace;
			}
		}
		if (MyRenderer == null)
		{
			MyRenderer = base.transform.GetChild(0).GetChild(0).GetChild(0)
				.GetComponent<SkinnedMeshRenderer>();
		}
		if (!Male)
		{
			if (OriginalFemaleUniformTexture1 == null)
			{
				OriginalFemaleUniformTexture1 = FemaleUniformTextures[1];
				OriginalFemaleUniformTexture2 = FemaleUniformTextures[2];
				OriginalFemaleUniformTexture3 = FemaleUniformTextures[3];
				OriginalFemaleUniformTexture4 = FemaleUniformTextures[4];
			}
			else
			{
				FemaleUniformTextures[1] = OriginalFemaleUniformTexture1;
				FemaleUniformTextures[2] = OriginalFemaleUniformTexture2;
				FemaleUniformTextures[3] = OriginalFemaleUniformTexture3;
				FemaleUniformTextures[4] = OriginalFemaleUniformTexture4;
			}
		}
		if (Male)
		{
			if (OriginalMaleUniformTexture1 == null)
			{
				OriginalMaleUniformTexture1 = MaleUniformTextures[1];
				OriginalMaleUniformTexture2 = MaleUniformTextures[2];
				OriginalMaleUniformTexture3 = MaleUniformTextures[3];
				OriginalMaleUniformTexture4 = MaleUniformTextures[4];
			}
			else
			{
				MaleUniformTextures[1] = OriginalMaleUniformTexture1;
				MaleUniformTextures[2] = OriginalMaleUniformTexture2;
				MaleUniformTextures[3] = OriginalMaleUniformTexture3;
				MaleUniformTextures[4] = OriginalMaleUniformTexture4;
			}
		}
		if ((!Male && StudentGlobals.CustomFemaleUniform) || (Male && StudentGlobals.CustomMaleUniform))
		{
			GrabCustomTextures();
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
		if (Ryoba && Street && !GameGlobals.CustomMode)
		{
			ForceUniform = 6;
		}
		if (ForceUniform > 0)
		{
			num = ForceUniform;
		}
		MyRenderer.sharedMesh = FemaleUniforms[num];
		MyRenderer.materials[0].mainTexture = FemaleUniformTextures[num];
		MyRenderer.materials[1].mainTexture = FemaleUniformTextures[num];
		if (Ryoba && !GameGlobals.CustomMode)
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
			if (Ryoba)
			{
				_ = GameGlobals.CustomMode;
			}
		}
		else
		{
			MyRenderer.materials[2].mainTexture = OsanaFace;
		}
	}

	public IEnumerator GrabCustomTexturesAsync()
	{
		WWW NewTexture = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleShortOutdoors.png");
		yield return NewTexture;
		if (NewTexture.error == null)
		{
			FemaleUniformTextures[1] = NewTexture.texture;
		}
		NewTexture = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleLongOutdoors.png");
		yield return NewTexture;
		if (NewTexture.error == null)
		{
			FemaleUniformTextures[2] = NewTexture.texture;
		}
		NewTexture = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleSweaterOutdoors.png");
		yield return NewTexture;
		if (NewTexture.error == null)
		{
			FemaleUniformTextures[3] = NewTexture.texture;
		}
		NewTexture = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleBlazerOutdoors.png");
		yield return NewTexture;
		if (NewTexture.error == null)
		{
			FemaleUniformTextures[4] = NewTexture.texture;
		}
		if (Male)
		{
			SetMaleUniform();
		}
		else
		{
			SetFemaleUniform();
		}
	}

	public void GrabCustomTextures()
	{
		CustomUniform = GameObject.Find("CustomUniform").GetComponent<CustomUniformScript>();
		if (!Male)
		{
			FemaleUniformTextures[1] = CustomUniform.FemaleUniformTextures[1];
			FemaleUniformTextures[2] = CustomUniform.FemaleUniformTextures[2];
			FemaleUniformTextures[3] = CustomUniform.FemaleUniformTextures[3];
			FemaleUniformTextures[4] = CustomUniform.FemaleUniformTextures[4];
			SetFemaleUniform();
		}
		else
		{
			MaleUniformTextures[1] = CustomUniform.MaleUniformTextures[1];
			MaleUniformTextures[2] = CustomUniform.MaleUniformTextures[2];
			MaleUniformTextures[3] = CustomUniform.MaleUniformTextures[3];
			MaleUniformTextures[4] = CustomUniform.MaleUniformTextures[4];
			SetMaleUniform();
		}
	}
}
