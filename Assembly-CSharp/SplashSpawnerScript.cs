using System;
using UnityEngine;

// Token: 0x0200043A RID: 1082
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CDE RID: 7390 RVA: 0x001573EC File Offset: 0x001555EC
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

	// Token: 0x06001CDF RID: 7391 RVA: 0x001574FF File Offset: 0x001556FF
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x0400340A RID: 13322
	public GameObject BloodSplash;

	// Token: 0x0400340B RID: 13323
	public Transform Yandere;

	// Token: 0x0400340C RID: 13324
	public bool Bloody;

	// Token: 0x0400340D RID: 13325
	public bool FootUp;

	// Token: 0x0400340E RID: 13326
	public float DownThreshold;

	// Token: 0x0400340F RID: 13327
	public float UpThreshold;

	// Token: 0x04003410 RID: 13328
	public float Height;
}
