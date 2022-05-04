using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class PuddleParentScript : MonoBehaviour
{
	// Token: 0x06001B45 RID: 6981 RVA: 0x00130DC0 File Offset: 0x0012EFC0
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

	// Token: 0x06001B46 RID: 6982 RVA: 0x00130EA4 File Offset: 0x0012F0A4
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

	// Token: 0x04002E86 RID: 11910
	public GameObject WaterPuddle;

	// Token: 0x04002E87 RID: 11911
	public GameObject GasPuddle;

	// Token: 0x04002E88 RID: 11912
	public GameObject BrownPuddle;

	// Token: 0x04002E89 RID: 11913
	public Vector3[] PuddlePositions;

	// Token: 0x04002E8A RID: 11914
	public Vector3[] PuddleRotations;

	// Token: 0x04002E8B RID: 11915
	public int[] Type;

	// Token: 0x04002E8C RID: 11916
	public int PoolID;
}
