using UnityEngine;

public class VtuberHairReplacerScript : MonoBehaviour
{
	public GameObject YandereHair;

	public GameObject[] VtuberHair;

	private void Start()
	{
		if (GameGlobals.VtuberID > 0)
		{
			YandereHair.SetActive(false);
			VtuberHair[GameGlobals.VtuberID].SetActive(true);
		}
		else
		{
			VtuberHair[1].SetActive(false);
		}
	}
}
