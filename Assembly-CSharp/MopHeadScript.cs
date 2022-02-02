using System;
using UnityEngine;

// Token: 0x0200036B RID: 875
public class MopHeadScript : MonoBehaviour
{
	// Token: 0x060019AB RID: 6571 RVA: 0x00106670 File Offset: 0x00104870
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

	// Token: 0x0400291C RID: 10524
	public BloodPoolScript BloodPool;

	// Token: 0x0400291D RID: 10525
	public MopScript Mop;
}
