using System;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x060020DA RID: 8410 RVA: 0x001E58A4 File Offset: 0x001E3AA4
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 19 && !this.Destroyed)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.DestroyedCandlestick, base.transform.position, Quaternion.identity).transform.localScale = base.transform.localScale;
			this.Destroyed = true;
			AudioClipPlayer.Play2D(this.Break, base.transform.position);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004828 RID: 18472
	public GameObject DestroyedCandlestick;

	// Token: 0x04004829 RID: 18473
	public bool Destroyed;

	// Token: 0x0400482A RID: 18474
	public AudioClip Break;
}
