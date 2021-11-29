using System;
using UnityEngine;

// Token: 0x02000369 RID: 873
public class MopHeadScript : MonoBehaviour
{
	// Token: 0x0600199D RID: 6557 RVA: 0x001051AC File Offset: 0x001033AC
	private void OnTriggerStay(Collider other)
	{
		if (this.Mop.Bloodiness < 100f && other.tag == "Puddle")
		{
			this.BloodPool = other.gameObject.GetComponent<BloodPoolScript>();
			if (this.BloodPool != null)
			{
				this.BloodPool.Grow = false;
				other.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
				if (this.BloodPool.Blood)
				{
					this.Mop.Bloodiness += Time.deltaTime * 10f;
					this.Mop.UpdateBlood();
				}
				if (other.transform.localScale.x < 0.1f)
				{
					UnityEngine.Object.Destroy(other.gameObject);
					return;
				}
			}
			else
			{
				UnityEngine.Object.Destroy(other.gameObject);
			}
		}
	}

	// Token: 0x040028E4 RID: 10468
	public BloodPoolScript BloodPool;

	// Token: 0x040028E5 RID: 10469
	public MopScript Mop;
}
