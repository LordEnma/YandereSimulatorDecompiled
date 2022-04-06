using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001D07 RID: 7431 RVA: 0x0015A1A4 File Offset: 0x001583A4
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

	// Token: 0x06001D08 RID: 7432 RVA: 0x0015A2B7 File Offset: 0x001584B7
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x04003484 RID: 13444
	public GameObject BloodSplash;

	// Token: 0x04003485 RID: 13445
	public Transform Yandere;

	// Token: 0x04003486 RID: 13446
	public bool Bloody;

	// Token: 0x04003487 RID: 13447
	public bool FootUp;

	// Token: 0x04003488 RID: 13448
	public float DownThreshold;

	// Token: 0x04003489 RID: 13449
	public float UpThreshold;

	// Token: 0x0400348A RID: 13450
	public float Height;
}
