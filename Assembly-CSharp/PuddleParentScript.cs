using System;
using UnityEngine;

// Token: 0x020003C4 RID: 964
public class PuddleParentScript : MonoBehaviour
{
	// Token: 0x06001B2E RID: 6958 RVA: 0x0012FA94 File Offset: 0x0012DC94
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

	// Token: 0x06001B2F RID: 6959 RVA: 0x0012FB78 File Offset: 0x0012DD78
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

	// Token: 0x04002E56 RID: 11862
	public GameObject WaterPuddle;

	// Token: 0x04002E57 RID: 11863
	public GameObject GasPuddle;

	// Token: 0x04002E58 RID: 11864
	public GameObject BrownPuddle;

	// Token: 0x04002E59 RID: 11865
	public Vector3[] PuddlePositions;

	// Token: 0x04002E5A RID: 11866
	public Vector3[] PuddleRotations;

	// Token: 0x04002E5B RID: 11867
	public int[] Type;

	// Token: 0x04002E5C RID: 11868
	public int PoolID;
}
