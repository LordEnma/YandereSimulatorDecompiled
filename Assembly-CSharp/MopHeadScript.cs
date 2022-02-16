using System;
using UnityEngine;

// Token: 0x0200036C RID: 876
public class MopHeadScript : MonoBehaviour
{
	// Token: 0x060019B4 RID: 6580 RVA: 0x00106B5C File Offset: 0x00104D5C
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

	// Token: 0x04002926 RID: 10534
	public BloodPoolScript BloodPool;

	// Token: 0x04002927 RID: 10535
	public MopScript Mop;
}
