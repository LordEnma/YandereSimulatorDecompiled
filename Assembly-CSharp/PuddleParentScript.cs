using System;
using UnityEngine;

// Token: 0x020003C9 RID: 969
public class PuddleParentScript : MonoBehaviour
{
	// Token: 0x06001B4B RID: 6987 RVA: 0x00131984 File Offset: 0x0012FB84
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

	// Token: 0x06001B4C RID: 6988 RVA: 0x00131A68 File Offset: 0x0012FC68
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

	// Token: 0x04002E9B RID: 11931
	public GameObject WaterPuddle;

	// Token: 0x04002E9C RID: 11932
	public GameObject GasPuddle;

	// Token: 0x04002E9D RID: 11933
	public GameObject BrownPuddle;

	// Token: 0x04002E9E RID: 11934
	public Vector3[] PuddlePositions;

	// Token: 0x04002E9F RID: 11935
	public Vector3[] PuddleRotations;

	// Token: 0x04002EA0 RID: 11936
	public int[] Type;

	// Token: 0x04002EA1 RID: 11937
	public int PoolID;
}
