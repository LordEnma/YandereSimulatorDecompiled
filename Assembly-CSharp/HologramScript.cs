using System;
using UnityEngine;

public class HologramScript : MonoBehaviour
{
	public GameObject[] Holograms;

	public void Start()
	{
		if (DateGlobals.Week == 2 && DateGlobals.Weekday == DayOfWeek.Wednesday)
		{
			Holograms[8].GetComponent<MeshRenderer>().enabled = false;
			Holograms[10].GetComponent<MeshRenderer>().enabled = true;
			Holograms[10].GetComponent<BoxCollider>().enabled = true;
		}
	}

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
		if (UnityEngine.Random.value >= 0.5f)
		{
			return true;
		}
		return false;
	}
}
