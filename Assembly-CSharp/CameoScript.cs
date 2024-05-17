using UnityEngine;

public class CameoScript : MonoBehaviour
{
	public GameObject AdditionalCharacter;

	public GameObject OriginalHair;

	public GameObject CameoHair;

	public Texture CameoTexture;

	public SkinnedMeshRenderer Renderer;

	public string[] Letters;

	public int ID;

	private void Update()
	{
		if (Input.GetKeyDown(Letters[ID]))
		{
			ID++;
			if (ID == Letters.Length)
			{
				Renderer.material.mainTexture = CameoTexture;
				AdditionalCharacter.SetActive(value: true);
				OriginalHair.SetActive(value: false);
				CameoHair.SetActive(value: true);
				base.enabled = false;
			}
		}
	}
}
