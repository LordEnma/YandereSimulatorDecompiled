using UnityEngine;

public class RooftopScript : MonoBehaviour
{
	public GameObject[] DumpPoints;

	public GameObject Railing;

	public GameObject Fence;

	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			GameObject[] dumpPoints = DumpPoints;
			for (int i = 0; i < dumpPoints.Length; i++)
			{
				dumpPoints[i].SetActive(value: false);
			}
			Railing.SetActive(value: false);
			Fence.SetActive(value: true);
		}
	}
}
