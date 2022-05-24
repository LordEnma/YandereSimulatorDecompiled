using System;
using UnityEngine;

// Token: 0x020003C9 RID: 969
public class PuddleParentScript : MonoBehaviour
{
	// Token: 0x06001B4C RID: 6988 RVA: 0x00131C00 File Offset: 0x0012FE00
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

	// Token: 0x06001B4D RID: 6989 RVA: 0x00131CE4 File Offset: 0x0012FEE4
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

	// Token: 0x04002EA3 RID: 11939
	public GameObject WaterPuddle;

	// Token: 0x04002EA4 RID: 11940
	public GameObject GasPuddle;

	// Token: 0x04002EA5 RID: 11941
	public GameObject BrownPuddle;

	// Token: 0x04002EA6 RID: 11942
	public Vector3[] PuddlePositions;

	// Token: 0x04002EA7 RID: 11943
	public Vector3[] PuddleRotations;

	// Token: 0x04002EA8 RID: 11944
	public int[] Type;

	// Token: 0x04002EA9 RID: 11945
	public int PoolID;
}
