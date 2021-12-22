using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CC9 RID: 7369 RVA: 0x00154BB8 File Offset: 0x00152DB8
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

	// Token: 0x06001CCA RID: 7370 RVA: 0x00154CCB File Offset: 0x00152ECB
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x040033E8 RID: 13288
	public GameObject BloodSplash;

	// Token: 0x040033E9 RID: 13289
	public Transform Yandere;

	// Token: 0x040033EA RID: 13290
	public bool Bloody;

	// Token: 0x040033EB RID: 13291
	public bool FootUp;

	// Token: 0x040033EC RID: 13292
	public float DownThreshold;

	// Token: 0x040033ED RID: 13293
	public float UpThreshold;

	// Token: 0x040033EE RID: 13294
	public float Height;
}
