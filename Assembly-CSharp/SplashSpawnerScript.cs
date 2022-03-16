using System;
using UnityEngine;

// Token: 0x0200043C RID: 1084
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CF6 RID: 7414 RVA: 0x00159328 File Offset: 0x00157528
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

	// Token: 0x06001CF7 RID: 7415 RVA: 0x0015943B File Offset: 0x0015763B
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x04003465 RID: 13413
	public GameObject BloodSplash;

	// Token: 0x04003466 RID: 13414
	public Transform Yandere;

	// Token: 0x04003467 RID: 13415
	public bool Bloody;

	// Token: 0x04003468 RID: 13416
	public bool FootUp;

	// Token: 0x04003469 RID: 13417
	public float DownThreshold;

	// Token: 0x0400346A RID: 13418
	public float UpThreshold;

	// Token: 0x0400346B RID: 13419
	public float Height;
}
