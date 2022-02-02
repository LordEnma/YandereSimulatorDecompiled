using System;
using UnityEngine;

// Token: 0x020004D4 RID: 1236
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x06002076 RID: 8310 RVA: 0x001DC614 File Offset: 0x001DA814
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

	// Token: 0x04004706 RID: 18182
	public GameObject DestroyedCandlestick;

	// Token: 0x04004707 RID: 18183
	public bool Destroyed;

	// Token: 0x04004708 RID: 18184
	public AudioClip Break;
}
