using System;
using UnityEngine;

// Token: 0x02000435 RID: 1077
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CC1 RID: 7361 RVA: 0x00154294 File Offset: 0x00152494
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

	// Token: 0x06001CC2 RID: 7362 RVA: 0x001543A7 File Offset: 0x001525A7
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x040033BD RID: 13245
	public GameObject BloodSplash;

	// Token: 0x040033BE RID: 13246
	public Transform Yandere;

	// Token: 0x040033BF RID: 13247
	public bool Bloody;

	// Token: 0x040033C0 RID: 13248
	public bool FootUp;

	// Token: 0x040033C1 RID: 13249
	public float DownThreshold;

	// Token: 0x040033C2 RID: 13250
	public float UpThreshold;

	// Token: 0x040033C3 RID: 13251
	public float Height;
}
