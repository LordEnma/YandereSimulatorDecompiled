using System;
using UnityEngine;

// Token: 0x020004D7 RID: 1239
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x06002091 RID: 8337 RVA: 0x001DE59C File Offset: 0x001DC79C
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

	// Token: 0x04004745 RID: 18245
	public GameObject DestroyedCandlestick;

	// Token: 0x04004746 RID: 18246
	public bool Destroyed;

	// Token: 0x04004747 RID: 18247
	public AudioClip Break;
}
