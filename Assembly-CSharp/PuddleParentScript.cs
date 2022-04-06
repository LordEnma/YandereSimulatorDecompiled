using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class PuddleParentScript : MonoBehaviour
{
	// Token: 0x06001B3D RID: 6973 RVA: 0x001303D0 File Offset: 0x0012E5D0
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

	// Token: 0x06001B3E RID: 6974 RVA: 0x001304B4 File Offset: 0x0012E6B4
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

	// Token: 0x04002E72 RID: 11890
	public GameObject WaterPuddle;

	// Token: 0x04002E73 RID: 11891
	public GameObject GasPuddle;

	// Token: 0x04002E74 RID: 11892
	public GameObject BrownPuddle;

	// Token: 0x04002E75 RID: 11893
	public Vector3[] PuddlePositions;

	// Token: 0x04002E76 RID: 11894
	public Vector3[] PuddleRotations;

	// Token: 0x04002E77 RID: 11895
	public int[] Type;

	// Token: 0x04002E78 RID: 11896
	public int PoolID;
}
