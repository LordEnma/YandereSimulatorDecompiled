using UnityEngine;

public class LaptopManagerScript : MonoBehaviour
{
	public GameObject[] Laptops;

	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			base.gameObject.SetActive(value: false);
			return;
		}
		int num = 0;
		num = DateGlobals.Week;
		for (int i = 1; i < Laptops.Length; i++)
		{
			if (Laptops[i] != null)
			{
				if (num > i)
				{
					Laptops[i].SetActive(value: false);
				}
				else
				{
					Laptops[i].SetActive(value: true);
				}
			}
		}
		if (MissionModeGlobals.MissionMode)
		{
			Laptops[1].SetActive(value: false);
			Laptops[2].SetActive(value: false);
		}
	}
}
