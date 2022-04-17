using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class PuddleParentScript : MonoBehaviour
{
	// Token: 0x06001B41 RID: 6977 RVA: 0x001307E0 File Offset: 0x0012E9E0
	public void RecordAllPuddles()
	{
		this.PoolID = 0;
		foreach (object obj in base.transform)
		{
			Transform transform = (Transform)obj;
			BloodPoolScript component = transform.GetComponent<BloodPoolScript>();
			if (component != null)
			{
				this.PoolID++;
				if (this.PoolID < 100)
				{
					this.PuddlePositions[this.PoolID] = transform.position;
					this.PuddleRotations[this.PoolID] = transform.eulerAngles;
				}
				if (component.Gasoline)
				{
					this.Type[this.PoolID] = 1;
				}
				else if (component.Brown)
				{
					this.Type[this.PoolID] = 2;
				}
			}
		}
	}

	// Token: 0x06001B42 RID: 6978 RVA: 0x001308C4 File Offset: 0x0012EAC4
	public void RestoreAllPuddles()
	{
		while (this.PoolID > 0)
		{
			GameObject gameObject = null;
			if (this.Type[this.PoolID] == 0)
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.WaterPuddle, this.PuddlePositions[this.PoolID], Quaternion.identity);
			}
			else if (this.Type[this.PoolID] == 1)
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.GasPuddle, this.PuddlePositions[this.PoolID], Quaternion.identity);
			}
			else if (this.Type[this.PoolID] == 2)
			{
				gameObject = UnityEngine.Object.Instantiate<GameObject>(this.GasPuddle, this.PuddlePositions[this.PoolID], Quaternion.identity);
			}
			gameObject.GetComponent<BloodPoolScript>().TargetSize = 1f;
			gameObject.transform.eulerAngles = this.PuddleRotations[this.PoolID];
			gameObject.transform.parent = base.transform;
			this.PoolID--;
		}
	}

	// Token: 0x04002E7D RID: 11901
	public GameObject WaterPuddle;

	// Token: 0x04002E7E RID: 11902
	public GameObject GasPuddle;

	// Token: 0x04002E7F RID: 11903
	public GameObject BrownPuddle;

	// Token: 0x04002E80 RID: 11904
	public Vector3[] PuddlePositions;

	// Token: 0x04002E81 RID: 11905
	public Vector3[] PuddleRotations;

	// Token: 0x04002E82 RID: 11906
	public int[] Type;

	// Token: 0x04002E83 RID: 11907
	public int PoolID;
}
