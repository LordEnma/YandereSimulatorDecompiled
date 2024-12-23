using System.Collections;
using UnityEngine;

public class CustomUniformScript : MonoBehaviour
{
	private static CustomUniformScript instance;

	public Texture[] FemaleUniformTextures;

	public Texture[] FemaleCasualTextures;

	public Texture[] FemaleSocksTextures;

	public Texture[] MaleUniformTextures;

	public Texture[] MaleCasualTextures;

	public Texture[] MaleSocksTextures;

	public Texture[] CustomStockings;

	public Texture[] CustomBookbags;

	private void Start()
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("CustomTexture");
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != base.gameObject)
			{
				Object.Destroy(base.gameObject);
				return;
			}
		}
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		Object.DontDestroyOnLoad(base.gameObject);
		instance = this;
		StartCoroutine(GrabCustomTextures());
	}

	public IEnumerator GrabCustomTextures()
	{
		WWW NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleShortIndoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleUniformTextures[1] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleShortOutdoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleCasualTextures[1] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleShortSocks.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleSocksTextures[1] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleLongIndoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleUniformTextures[2] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleLongOutdoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleCasualTextures[2] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleLongSocks.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleSocksTextures[2] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleSweaterIndoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleUniformTextures[3] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleSweaterOutdoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleCasualTextures[3] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleSweaterSocks.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleSocksTextures[3] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleBlazerIndoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleUniformTextures[4] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleBlazerOutdoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleCasualTextures[4] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Female/FemaleBlazerSocks.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			FemaleSocksTextures[4] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleDefaultIndoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleUniformTextures[1] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleDefaultOutdoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleCasualTextures[1] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleDefaultSocks.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleSocksTextures[1] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleCoatIndoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleUniformTextures[2] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleCoatOutdoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleCasualTextures[2] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleCoatSocks.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleSocksTextures[2] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleButtonIndoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleUniformTextures[3] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleButtonOutdoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleCasualTextures[3] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleButtonSocks.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleSocksTextures[3] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleBlazerIndoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleUniformTextures[4] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleBlazerOutdoors.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleCasualTextures[4] = NewTexture26.texture;
		}
		NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Uniforms/Male/MaleBlazerSocks.png");
		yield return NewTexture26;
		if (NewTexture26.error == null)
		{
			MaleSocksTextures[4] = NewTexture26.texture;
		}
		for (int ID2 = 1; ID2 < 11; ID2++)
		{
			NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Stockings/CustomStockings" + ID2 + ".png");
			yield return NewTexture26;
			if (NewTexture26.error == null)
			{
				CustomStockings[ID2] = NewTexture26.texture;
			}
		}
		for (int ID2 = 1; ID2 < 11; ID2++)
		{
			NewTexture26 = new WWW("file:///" + Application.streamingAssetsPath + "/CustomMode/Textures/Bookbags/RivalBag" + ID2 + ".png");
			yield return NewTexture26;
			if (NewTexture26.error == null)
			{
				CustomBookbags[ID2] = NewTexture26.texture;
			}
		}
	}
}
