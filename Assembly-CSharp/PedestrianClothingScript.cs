using UnityEngine;

public class PedestrianClothingScript : MonoBehaviour
{
	public SkinnedMeshRenderer[] ClothingRenderer;

	public Texture[] ClothingTexture;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			ClothingRenderer[0].material.mainTexture = ClothingTexture[0];
			ClothingRenderer[1].material.mainTexture = ClothingTexture[1];
		}
	}
}
