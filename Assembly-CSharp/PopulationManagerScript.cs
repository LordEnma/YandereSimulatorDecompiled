using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003B4 RID: 948
public class PopulationManagerScript : MonoBehaviour
{
	// Token: 0x06001AF1 RID: 6897 RVA: 0x00126E64 File Offset: 0x00125064
	public Vector3 GetCrowdedLocation()
	{
		AreaScript crowdedArea = this.GetCrowdedArea();
		Vector3 position = crowdedArea.transform.position;
		Vector3 vector = new Vector3(0f, 0f, 0f);
		float num = 0f;
		foreach (StudentScript studentScript in crowdedArea.Students)
		{
			vector += new Vector3(studentScript.transform.position.x, 0f, studentScript.transform.position.z);
			num += 1f;
		}
		vector /= num;
		int num2;
		if (position.y >= 0f && position.y < 4f)
		{
			num2 = 0;
		}
		else if (position.y >= 4f && position.y < 8f)
		{
			num2 = 4;
		}
		else if (position.y >= 8f && position.y < 12f)
		{
			num2 = 8;
		}
		else
		{
			num2 = 12;
		}
		return new Vector3(vector.x, (float)num2, vector.z);
	}

	// Token: 0x06001AF2 RID: 6898 RVA: 0x00126F94 File Offset: 0x00125194
	public AreaScript GetCrowdedArea()
	{
		AreaScript result = null;
		float num = 0f;
		foreach (AreaScript areaScript in this._definedAreas)
		{
			int population = areaScript.Population;
			if ((float)population > num)
			{
				num = (float)population;
				result = areaScript;
			}
		}
		return result;
	}

	// Token: 0x04002D64 RID: 11620
	[Tooltip("All defined areas should go in here. If your area is not in here, it will not count as an actual area.")]
	[SerializeField]
	private List<AreaScript> _definedAreas;

	// Token: 0x04002D65 RID: 11621
	public Transform Cube;
}
