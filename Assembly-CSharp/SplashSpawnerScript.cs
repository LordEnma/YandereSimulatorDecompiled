using System;
using UnityEngine;

// Token: 0x02000442 RID: 1090
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001D19 RID: 7449 RVA: 0x0015BD2C File Offset: 0x00159F2C
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

	// Token: 0x06001D1A RID: 7450 RVA: 0x0015BE3F File Offset: 0x0015A03F
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x040034BB RID: 13499
	public GameObject BloodSplash;

	// Token: 0x040034BC RID: 13500
	public Transform Yandere;

	// Token: 0x040034BD RID: 13501
	public bool Bloody;

	// Token: 0x040034BE RID: 13502
	public bool FootUp;

	// Token: 0x040034BF RID: 13503
	public float DownThreshold;

	// Token: 0x040034C0 RID: 13504
	public float UpThreshold;

	// Token: 0x040034C1 RID: 13505
	public float Height;
}
