using System;
using UnityEngine;

// Token: 0x020004D5 RID: 1237
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x06002082 RID: 8322 RVA: 0x001DCFE4 File Offset: 0x001DB1E4
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

	// Token: 0x04004718 RID: 18200
	public GameObject DestroyedCandlestick;

	// Token: 0x04004719 RID: 18201
	public bool Destroyed;

	// Token: 0x0400471A RID: 18202
	public AudioClip Break;
}
