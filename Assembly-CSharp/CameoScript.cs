using UnityEngine;

public class CameoScript : MonoBehaviour
{
	public GameObject[] AdditionalCharacter;

	public GameObject OriginalHair;

	public GameObject CameoHair;

	public Texture CameoTexture;

	public SkinnedMeshRenderer Renderer;

	public string[] LacunaLetters;

	public string[] ChipLetters;

	public string[] Letters;

	public int LacunaID;

	public int ChipID;

	public int ID;

	private void Update()
	{
		if (Input.GetKeyDown(Letters[ID]))
		{
			ID++;
			if (ID == Letters.Length)
			{
				Renderer.material.mainTexture = CameoTexture;
				AdditionalCharacter[1].SetActive(value: true);
				AdditionalCharacter[2].SetActive(value: true);
				base.enabled = false;
			}
		}
		if (Input.GetKeyDown(ChipLetters[ChipID]))
		{
			ChipID++;
			if (ChipID == ChipLetters.Length)
			{
				Renderer.material.mainTexture = CameoTexture;
				AdditionalCharacter[3].SetActive(value: true);
				base.enabled = false;
			}
		}
		bool flag = false;
		if (Input.GetKeyDown(LacunaLetters[LacunaID]) || flag)
		{
			LacunaID++;
			if (LacunaID == LacunaLetters.Length)
			{
				AdditionalCharacter[4].SetActive(value: true);
				base.enabled = false;
			}
		}
	}
}
