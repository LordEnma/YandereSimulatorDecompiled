using System;
using UnityEngine;

// Token: 0x0200036F RID: 879
public class MopHeadScript : MonoBehaviour
{
	// Token: 0x060019D5 RID: 6613 RVA: 0x00108C04 File Offset: 0x00106E04
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

	// Token: 0x0400298B RID: 10635
	public BloodPoolScript BloodPool;

	// Token: 0x0400298C RID: 10636
	public MopScript Mop;
}
