using System;
using UnityEngine;

// Token: 0x020004D4 RID: 1236
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x06002078 RID: 8312 RVA: 0x001DC92C File Offset: 0x001DAB2C
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

	// Token: 0x0400470C RID: 18188
	public GameObject DestroyedCandlestick;

	// Token: 0x0400470D RID: 18189
	public bool Destroyed;

	// Token: 0x0400470E RID: 18190
	public AudioClip Break;
}
