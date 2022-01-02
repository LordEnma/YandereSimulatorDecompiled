using System;
using UnityEngine;

// Token: 0x02000436 RID: 1078
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CCB RID: 7371 RVA: 0x00154FFC File Offset: 0x001531FC
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

	// Token: 0x06001CCC RID: 7372 RVA: 0x0015510F File Offset: 0x0015330F
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x040033EF RID: 13295
	public GameObject BloodSplash;

	// Token: 0x040033F0 RID: 13296
	public Transform Yandere;

	// Token: 0x040033F1 RID: 13297
	public bool Bloody;

	// Token: 0x040033F2 RID: 13298
	public bool FootUp;

	// Token: 0x040033F3 RID: 13299
	public float DownThreshold;

	// Token: 0x040033F4 RID: 13300
	public float UpThreshold;

	// Token: 0x040033F5 RID: 13301
	public float Height;
}
