using UnityEngine;

public class VtuberHairReplacerScript : MonoBehaviour
{
	public GameObject YandereHair;

	public GameObject[] VtuberHair;

	public GameObject[] VtuberAccs;

	private void Start()
	{
		for (int i = 1; i < VtuberHair.Length; i++)
		{
			VtuberHair[i].SetActive(value: false);
		}
		for (int i = 1; i < VtuberAccs.Length; i++)
		{
			VtuberAccs[i].SetActive(value: false);
		}
		if (GameGlobals.VtuberID > 0)
		{
			YandereHair.SetActive(value: false);
			VtuberHair[GameGlobals.VtuberID].SetActive(value: true);
			VtuberAccs[GameGlobals.VtuberID].SetActive(value: true);
		}
	}
}
