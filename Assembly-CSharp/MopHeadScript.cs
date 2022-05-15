using System;
using UnityEngine;

// Token: 0x02000370 RID: 880
public class MopHeadScript : MonoBehaviour
{
	// Token: 0x060019DF RID: 6623 RVA: 0x0010990C File Offset: 0x00107B0C
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

	// Token: 0x040029A5 RID: 10661
	public BloodPoolScript BloodPool;

	// Token: 0x040029A6 RID: 10662
	public MopScript Mop;
}
