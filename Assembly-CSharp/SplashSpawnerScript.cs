using System;
using UnityEngine;

// Token: 0x02000439 RID: 1081
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CD7 RID: 7383 RVA: 0x001570E4 File Offset: 0x001552E4
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

	// Token: 0x06001CD8 RID: 7384 RVA: 0x001571F7 File Offset: 0x001553F7
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x04003404 RID: 13316
	public GameObject BloodSplash;

	// Token: 0x04003405 RID: 13317
	public Transform Yandere;

	// Token: 0x04003406 RID: 13318
	public bool Bloody;

	// Token: 0x04003407 RID: 13319
	public bool FootUp;

	// Token: 0x04003408 RID: 13320
	public float DownThreshold;

	// Token: 0x04003409 RID: 13321
	public float UpThreshold;

	// Token: 0x0400340A RID: 13322
	public float Height;
}
