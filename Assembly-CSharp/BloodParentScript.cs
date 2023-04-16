using UnityEngine;

public class BloodParentScript : MonoBehaviour
{
	public YandereScript Yandere;

	public GameObject Bloodpool;

	public GameObject Footprint;

	public Vector3[] FootprintPositions;

	public Vector3[] BloodPositions;

	public Vector3[] FootprintRotations;

	public Vector3[] BloodRotations;

	public float[] BloodSizes;

	public int FootprintID;

	public int PoolID;

	public void RecordAllBlood()
	{
		PoolID = 0;
		FootprintID = 0;
		foreach (Transform item in base.transform)
		{
			BloodPoolScript component = item.GetComponent<BloodPoolScript>();
			if (component != null)
			{
				PoolID++;
				if (PoolID < 100)
				{
					BloodPositions[PoolID] = item.position;
					BloodRotations[PoolID] = item.eulerAngles;
					BloodSizes[PoolID] = component.TargetSize;
				}
			}
			else
			{
				FootprintID++;
				if (FootprintID < 100)
				{
					FootprintPositions[FootprintID] = item.position;
					FootprintRotations[FootprintID] = item.eulerAngles;
				}
			}
		}
	}

	public void RestoreAllBlood()
	{
		while (PoolID > 0)
		{
			GameObject obj = Object.Instantiate(Bloodpool, BloodPositions[PoolID], Quaternion.identity);
			obj.GetComponent<BloodPoolScript>().TargetSize = BloodSizes[PoolID];
			obj.transform.eulerAngles = BloodRotations[PoolID];
			obj.transform.parent = base.transform;
			PoolID--;
		}
		while (FootprintID > 0)
		{
			GameObject obj2 = Object.Instantiate(Footprint, FootprintPositions[FootprintID], Quaternion.identity);
			obj2.transform.GetChild(0).GetComponent<FootprintScript>().Yandere = Yandere;
			obj2.transform.eulerAngles = FootprintRotations[FootprintID];
			obj2.transform.parent = base.transform;
			FootprintID--;
		}
	}

	public void ChangeBloodTexture()
	{
		foreach (Transform item in base.transform)
		{
			BloodPoolScript component = item.GetComponent<BloodPoolScript>();
			if (component != null)
			{
				component.UpdateCensor();
			}
		}
	}
}
