using System;
using UnityEngine;

// Token: 0x0200036D RID: 877
public class MopHeadScript : MonoBehaviour
{
	// Token: 0x060019BD RID: 6589 RVA: 0x001077F4 File Offset: 0x001059F4
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

	// Token: 0x0400294B RID: 10571
	public BloodPoolScript BloodPool;

	// Token: 0x0400294C RID: 10572
	public MopScript Mop;
}
