using UnityEngine;

public class HologramScript : MonoBehaviour
{
	public GameObject[] Holograms;

	public void UpdateHolograms()
	{
		GameObject[] holograms = Holograms;
		for (int i = 0; i < holograms.Length; i++)
		{
			holograms[i].SetActive(TrueFalse());
		}
	}

	private bool TrueFalse()
	{
		if (Random.value >= 0.5f)
		{
			return true;
		}
		return false;
	}
}
