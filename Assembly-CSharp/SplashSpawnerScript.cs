using System;
using UnityEngine;

// Token: 0x02000441 RID: 1089
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001D12 RID: 7442 RVA: 0x0015ADF0 File Offset: 0x00158FF0
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

	// Token: 0x06001D13 RID: 7443 RVA: 0x0015AF03 File Offset: 0x00159103
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x0400349E RID: 13470
	public GameObject BloodSplash;

	// Token: 0x0400349F RID: 13471
	public Transform Yandere;

	// Token: 0x040034A0 RID: 13472
	public bool Bloody;

	// Token: 0x040034A1 RID: 13473
	public bool FootUp;

	// Token: 0x040034A2 RID: 13474
	public float DownThreshold;

	// Token: 0x040034A3 RID: 13475
	public float UpThreshold;

	// Token: 0x040034A4 RID: 13476
	public float Height;
}
