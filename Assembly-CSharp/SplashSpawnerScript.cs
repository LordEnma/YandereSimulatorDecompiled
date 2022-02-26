using System;
using UnityEngine;

// Token: 0x0200043B RID: 1083
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CE7 RID: 7399 RVA: 0x00157E98 File Offset: 0x00156098
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

	// Token: 0x06001CE8 RID: 7400 RVA: 0x00157FAB File Offset: 0x001561AB
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x0400341A RID: 13338
	public GameObject BloodSplash;

	// Token: 0x0400341B RID: 13339
	public Transform Yandere;

	// Token: 0x0400341C RID: 13340
	public bool Bloody;

	// Token: 0x0400341D RID: 13341
	public bool FootUp;

	// Token: 0x0400341E RID: 13342
	public float DownThreshold;

	// Token: 0x0400341F RID: 13343
	public float UpThreshold;

	// Token: 0x04003420 RID: 13344
	public float Height;
}
