using System;
using UnityEngine;

// Token: 0x02000439 RID: 1081
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CD5 RID: 7381 RVA: 0x00156F4C File Offset: 0x0015514C
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

	// Token: 0x06001CD6 RID: 7382 RVA: 0x0015705F File Offset: 0x0015525F
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x04003401 RID: 13313
	public GameObject BloodSplash;

	// Token: 0x04003402 RID: 13314
	public Transform Yandere;

	// Token: 0x04003403 RID: 13315
	public bool Bloody;

	// Token: 0x04003404 RID: 13316
	public bool FootUp;

	// Token: 0x04003405 RID: 13317
	public float DownThreshold;

	// Token: 0x04003406 RID: 13318
	public float UpThreshold;

	// Token: 0x04003407 RID: 13319
	public float Height;
}
