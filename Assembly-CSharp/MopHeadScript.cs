using System;
using UnityEngine;

// Token: 0x02000370 RID: 880
public class MopHeadScript : MonoBehaviour
{
	// Token: 0x060019E0 RID: 6624 RVA: 0x00109B10 File Offset: 0x00107D10
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
				this.Mop.StudentBloodID = this.BloodPool.StudentBloodID;
				if (other.transform.localScale.x < 0.1f)
				{
					UnityEngine.Object.Destroy(other.gameObject);
					return;
				}
			}
			else
			{
				FootprintScript component = other.transform.GetChild(0).GetComponent<FootprintScript>();
				if (component != null)
				{
					this.Mop.StudentBloodID = component.StudentBloodID;
				}
				UnityEngine.Object.Destroy(other.gameObject);
			}
		}
	}

	// Token: 0x040029AC RID: 10668
	public BloodPoolScript BloodPool;

	// Token: 0x040029AD RID: 10669
	public MopScript Mop;
}
