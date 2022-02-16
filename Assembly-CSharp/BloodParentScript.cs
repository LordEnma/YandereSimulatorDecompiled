using System;
using UnityEngine;

// Token: 0x020000E8 RID: 232
public class BloodParentScript : MonoBehaviour
{
	// Token: 0x06000A35 RID: 2613 RVA: 0x0005A760 File Offset: 0x00058960
	public void RecordAllBlood()
	{
		this.PoolID = 0;
		this.FootprintID = 0;
		foreach (object obj in base.transform)
		{
			Transform transform = (Transform)obj;
			BloodPoolScript component = transform.GetComponent<BloodPoolScript>();
			if (component != null)
			{
				this.PoolID++;
				if (this.PoolID < 100)
				{
					this.BloodPositions[this.PoolID] = transform.position;
					this.BloodRotations[this.PoolID] = transform.eulerAngles;
					this.BloodSizes[this.PoolID] = component.TargetSize;
				}
			}
			else
			{
				this.FootprintID++;
				if (this.FootprintID < 100)
				{
					this.FootprintPositions[this.FootprintID] = transform.position;
					this.FootprintRotations[this.FootprintID] = transform.eulerAngles;
				}
			}
		}
	}

	// Token: 0x06000A36 RID: 2614 RVA: 0x0005A87C File Offset: 0x00058A7C
	public void RestoreAllBlood()
	{
		while (this.PoolID > 0)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Bloodpool, this.BloodPositions[this.PoolID], Quaternion.identity);
			gameObject.GetComponent<BloodPoolScript>().TargetSize = this.BloodSizes[this.PoolID];
			gameObject.transform.eulerAngles = this.BloodRotations[this.PoolID];
			gameObject.transform.parent = base.transform;
			this.PoolID--;
		}
		while (this.FootprintID > 0)
		{
			GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.Footprint, this.FootprintPositions[this.FootprintID], Quaternion.identity);
			gameObject2.transform.GetChild(0).GetComponent<FootprintScript>().Yandere = this.Yandere;
			gameObject2.transform.eulerAngles = this.FootprintRotations[this.FootprintID];
			gameObject2.transform.parent = base.transform;
			this.FootprintID--;
		}
	}

	// Token: 0x04000B8F RID: 2959
	public YandereScript Yandere;

	// Token: 0x04000B90 RID: 2960
	public GameObject Bloodpool;

	// Token: 0x04000B91 RID: 2961
	public GameObject Footprint;

	// Token: 0x04000B92 RID: 2962
	public Vector3[] FootprintPositions;

	// Token: 0x04000B93 RID: 2963
	public Vector3[] BloodPositions;

	// Token: 0x04000B94 RID: 2964
	public Vector3[] FootprintRotations;

	// Token: 0x04000B95 RID: 2965
	public Vector3[] BloodRotations;

	// Token: 0x04000B96 RID: 2966
	public float[] BloodSizes;

	// Token: 0x04000B97 RID: 2967
	public int FootprintID;

	// Token: 0x04000B98 RID: 2968
	public int PoolID;
}
