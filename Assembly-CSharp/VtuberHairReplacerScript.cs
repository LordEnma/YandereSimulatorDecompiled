using UnityEngine;

public class VtuberHairReplacerScript : MonoBehaviour
{
	public GameObject YandereHair;

	public GameObject[] VtuberHair;

	private void Start()
	{
		if (GameGlobals.VtuberID > 0)
		{
			YandereHair.SetActive(value: false);
			VtuberHair[GameGlobals.VtuberID].SetActive(value: true);
		}
		else
		{
			VtuberHair[1].SetActive(value: false);
		}
	}
}
