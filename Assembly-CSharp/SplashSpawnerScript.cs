using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001D0B RID: 7435 RVA: 0x0015A5B4 File Offset: 0x001587B4
	private void Update()
	{
		if (!this.FootUp)
		{
			if (base.transform.position.y > this.Yandere.transform.position.y + this.UpThreshold)
			{
				this.FootUp = true;
				return;
			}
		}
		else if (base.transform.position.y < this.Yandere.transform.position.y + this.DownThreshold)
		{
			this.FootUp = false;
			if (this.Bloody)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodSplash, new Vector3(base.transform.position.x, this.Yandere.position.y, base.transform.position.z), Quaternion.identity);
				gameObject.transform.eulerAngles = new Vector3(-90f, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
				this.Bloody = false;
			}
		}
	}

	// Token: 0x06001D0C RID: 7436 RVA: 0x0015A6C7 File Offset: 0x001588C7
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x0400348F RID: 13455
	public GameObject BloodSplash;

	// Token: 0x04003490 RID: 13456
	public Transform Yandere;

	// Token: 0x04003491 RID: 13457
	public bool Bloody;

	// Token: 0x04003492 RID: 13458
	public bool FootUp;

	// Token: 0x04003493 RID: 13459
	public float DownThreshold;

	// Token: 0x04003494 RID: 13460
	public float UpThreshold;

	// Token: 0x04003495 RID: 13461
	public float Height;
}
