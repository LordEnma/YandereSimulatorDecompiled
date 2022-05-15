using System;
using UnityEngine;

// Token: 0x02000442 RID: 1090
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001D18 RID: 7448 RVA: 0x0015BA70 File Offset: 0x00159C70
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

	// Token: 0x06001D19 RID: 7449 RVA: 0x0015BB83 File Offset: 0x00159D83
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x040034B3 RID: 13491
	public GameObject BloodSplash;

	// Token: 0x040034B4 RID: 13492
	public Transform Yandere;

	// Token: 0x040034B5 RID: 13493
	public bool Bloody;

	// Token: 0x040034B6 RID: 13494
	public bool FootUp;

	// Token: 0x040034B7 RID: 13495
	public float DownThreshold;

	// Token: 0x040034B8 RID: 13496
	public float UpThreshold;

	// Token: 0x040034B9 RID: 13497
	public float Height;
}
