using System;
using UnityEngine;

// Token: 0x0200043F RID: 1087
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001D00 RID: 7424 RVA: 0x00159E84 File Offset: 0x00158084
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

	// Token: 0x06001D01 RID: 7425 RVA: 0x00159F97 File Offset: 0x00158197
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x04003481 RID: 13441
	public GameObject BloodSplash;

	// Token: 0x04003482 RID: 13442
	public Transform Yandere;

	// Token: 0x04003483 RID: 13443
	public bool Bloody;

	// Token: 0x04003484 RID: 13444
	public bool FootUp;

	// Token: 0x04003485 RID: 13445
	public float DownThreshold;

	// Token: 0x04003486 RID: 13446
	public float UpThreshold;

	// Token: 0x04003487 RID: 13447
	public float Height;
}
