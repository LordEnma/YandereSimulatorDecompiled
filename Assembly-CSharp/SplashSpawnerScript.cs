using System;
using UnityEngine;

// Token: 0x0200043B RID: 1083
public class SplashSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CE9 RID: 7401 RVA: 0x0015841C File Offset: 0x0015661C
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

	// Token: 0x06001CEA RID: 7402 RVA: 0x0015852F File Offset: 0x0015672F
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.Bloody = true;
		}
	}

	// Token: 0x04003430 RID: 13360
	public GameObject BloodSplash;

	// Token: 0x04003431 RID: 13361
	public Transform Yandere;

	// Token: 0x04003432 RID: 13362
	public bool Bloody;

	// Token: 0x04003433 RID: 13363
	public bool FootUp;

	// Token: 0x04003434 RID: 13364
	public float DownThreshold;

	// Token: 0x04003435 RID: 13365
	public float UpThreshold;

	// Token: 0x04003436 RID: 13366
	public float Height;
}
