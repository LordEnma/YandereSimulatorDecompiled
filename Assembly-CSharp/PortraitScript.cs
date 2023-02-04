using UnityEngine;

public class PortraitScript : MonoBehaviour
{
	public GameObject[] StudentObject;

	public Renderer Renderer1;

	public Renderer Renderer2;

	public Renderer Renderer3;

	public Texture[] HairSet1;

	public Texture[] HairSet2;

	public Texture[] HairSet3;

	public int Selected;

	public int CurrentHair;

	private void Start()
	{
		StudentObject[1].SetActive(value: false);
		StudentObject[2].SetActive(value: false);
		Selected = 1;
		UpdateHair();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			StudentObject[0].SetActive(value: true);
			StudentObject[1].SetActive(value: false);
			StudentObject[2].SetActive(value: false);
			Selected = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			StudentObject[0].SetActive(value: false);
			StudentObject[1].SetActive(value: true);
			StudentObject[2].SetActive(value: false);
			Selected = 2;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			StudentObject[0].SetActive(value: false);
			StudentObject[1].SetActive(value: false);
			StudentObject[2].SetActive(value: true);
			Selected = 3;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			CurrentHair++;
			if (CurrentHair > HairSet1.Length - 1)
			{
				CurrentHair = 0;
			}
			UpdateHair();
		}
	}

	private void UpdateHair()
	{
		Texture mainTexture = HairSet2[CurrentHair];
		Renderer1.materials[0].mainTexture = mainTexture;
		Renderer1.materials[3].mainTexture = mainTexture;
		Renderer2.materials[2].mainTexture = mainTexture;
		Renderer2.materials[3].mainTexture = mainTexture;
		Renderer3.materials[0].mainTexture = mainTexture;
		Renderer3.materials[1].mainTexture = mainTexture;
	}
}
