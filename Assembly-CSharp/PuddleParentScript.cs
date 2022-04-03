using System;
using UnityEngine;

// Token: 0x020003C7 RID: 967
public class PuddleParentScript : MonoBehaviour
{
	// Token: 0x06001B37 RID: 6967 RVA: 0x00130224 File Offset: 0x0012E424
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

	// Token: 0x06001B38 RID: 6968 RVA: 0x00130308 File Offset: 0x0012E508
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

	// Token: 0x04002E6F RID: 11887
	public GameObject WaterPuddle;

	// Token: 0x04002E70 RID: 11888
	public GameObject GasPuddle;

	// Token: 0x04002E71 RID: 11889
	public GameObject BrownPuddle;

	// Token: 0x04002E72 RID: 11890
	public Vector3[] PuddlePositions;

	// Token: 0x04002E73 RID: 11891
	public Vector3[] PuddleRotations;

	// Token: 0x04002E74 RID: 11892
	public int[] Type;

	// Token: 0x04002E75 RID: 11893
	public int PoolID;
}
