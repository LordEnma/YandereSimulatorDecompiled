using UnityEngine;

public class PuddleParentScript : MonoBehaviour
{
	public GameObject WaterPuddle;

	public GameObject GasPuddle;

	public GameObject BrownPuddle;

	public Vector3[] PuddlePositions;

	public Vector3[] PuddleRotations;

	public int[] Type;

	public int PoolID;

	public void RecordAllPuddles()
	{
		PoolID = 0;
		foreach (Transform item in base.transform)
		{
			BloodPoolScript component = item.GetComponent<BloodPoolScript>();
			if (component != null)
			{
				PoolID++;
				if (PoolID < 100)
				{
					PuddlePositions[PoolID] = item.position;
					PuddleRotations[PoolID] = item.eulerAngles;
				}
				if (component.Gasoline)
				{
					Type[PoolID] = 1;
				}
				else if (component.Brown)
				{
					Type[PoolID] = 2;
				}
			}
		}
	}

	public void RestoreAllPuddles()
	{
		while (PoolID > 0)
		{
			GameObject gameObject = null;
			if (Type[PoolID] == 0)
			{
				gameObject = Object.Instantiate(WaterPuddle, PuddlePositions[PoolID], Quaternion.identity);
			}
			else if (Type[PoolID] == 1)
			{
				gameObject = Object.Instantiate(GasPuddle, PuddlePositions[PoolID], Quaternion.identity);
			}
			else if (Type[PoolID] == 2)
			{
				gameObject = Object.Instantiate(GasPuddle, PuddlePositions[PoolID], Quaternion.identity);
			}
			gameObject.GetComponent<BloodPoolScript>().TargetSize = 1f;
			gameObject.transform.eulerAngles = PuddleRotations[PoolID];
			gameObject.transform.parent = base.transform;
			PoolID--;
		}
	}
}
