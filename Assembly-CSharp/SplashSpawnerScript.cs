using System;
using UnityEngine;

// Token: 0x02000439 RID: 1081
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CD4 RID: 7380 RVA: 0x00156A14 File Offset: 0x00154C14
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

	// Token: 0x06001CD5 RID: 7381 RVA: 0x00156B27 File Offset: 0x00154D27
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x040033FA RID: 13306
	public GameObject BloodSplash;

	// Token: 0x040033FB RID: 13307
	public Transform Yandere;

	// Token: 0x040033FC RID: 13308
	public bool Bloody;

	// Token: 0x040033FD RID: 13309
	public bool FootUp;

	// Token: 0x040033FE RID: 13310
	public float DownThreshold;

	// Token: 0x040033FF RID: 13311
	public float UpThreshold;

	// Token: 0x04003400 RID: 13312
	public float Height;
}
