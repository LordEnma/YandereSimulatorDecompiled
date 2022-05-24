using System;
using UnityEngine;

// Token: 0x020000E9 RID: 233
public class BloodParentScript : MonoBehaviour
{
	// Token: 0x06000A37 RID: 2615 RVA: 0x0005AD4C File Offset: 0x00058F4C
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

	// Token: 0x06000A38 RID: 2616 RVA: 0x0005AE68 File Offset: 0x00059068
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

	// Token: 0x04000B9F RID: 2975
	public YandereScript Yandere;

	// Token: 0x04000BA0 RID: 2976
	public GameObject Bloodpool;

	// Token: 0x04000BA1 RID: 2977
	public GameObject Footprint;

	// Token: 0x04000BA2 RID: 2978
	public Vector3[] FootprintPositions;

	// Token: 0x04000BA3 RID: 2979
	public Vector3[] BloodPositions;

	// Token: 0x04000BA4 RID: 2980
	public Vector3[] FootprintRotations;

	// Token: 0x04000BA5 RID: 2981
	public Vector3[] BloodRotations;

	// Token: 0x04000BA6 RID: 2982
	public float[] BloodSizes;

	// Token: 0x04000BA7 RID: 2983
	public int FootprintID;

	// Token: 0x04000BA8 RID: 2984
	public int PoolID;
}
