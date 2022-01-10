using System;
using UnityEngine;

// Token: 0x02000438 RID: 1080
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CD2 RID: 7378 RVA: 0x00155300 File Offset: 0x00153500
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

	// Token: 0x06001CD3 RID: 7379 RVA: 0x00155413 File Offset: 0x00153613
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x040033F5 RID: 13301
	public GameObject BloodSplash;

	// Token: 0x040033F6 RID: 13302
	public Transform Yandere;

	// Token: 0x040033F7 RID: 13303
	public bool Bloody;

	// Token: 0x040033F8 RID: 13304
	public bool FootUp;

	// Token: 0x040033F9 RID: 13305
	public float DownThreshold;

	// Token: 0x040033FA RID: 13306
	public float UpThreshold;

	// Token: 0x040033FB RID: 13307
	public float Height;
}
