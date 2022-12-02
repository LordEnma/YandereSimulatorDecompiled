using System.Collections.Generic;
using UnityEngine;

public class PopulationManagerScript : MonoBehaviour
{
	[Tooltip("All defined areas should go in here. If your area is not in here, it will not count as an actual area.")]
	[SerializeField]
	private List<AreaScript> _definedAreas;

	public Transform Cube;

	public Vector3 GetCrowdedLocation()
	{
		AreaScript crowdedArea = GetCrowdedArea();
		Vector3 position = crowdedArea.transform.position;
		Vector3 vector = new Vector3(0f, 0f, 0f);
		float num = 0f;
		int num2 = 0;
		foreach (StudentScript student in crowdedArea.Students)
		{
			vector += new Vector3(student.transform.position.x, 0f, student.transform.position.z);
			num += 1f;
		}
		vector /= num;
		return new Vector3(y: (!(position.y >= 0f) || !(position.y < 4f)) ? ((position.y >= 4f && position.y < 8f) ? 4 : ((!(position.y >= 8f) || !(position.y < 12f)) ? 12 : 8)) : 0, x: vector.x, z: vector.z);
	}

	public AreaScript GetCrowdedArea()
	{
		AreaScript result = null;
		float num = 0f;
		foreach (AreaScript definedArea in _definedAreas)
		{
			int population = definedArea.Population;
			if ((float)population > num)
			{
				num = population;
				result = definedArea;
			}
		}
		return result;
	}
}
