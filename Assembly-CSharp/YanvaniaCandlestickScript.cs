using System;
using UnityEngine;

// Token: 0x020004D4 RID: 1236
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x06002072 RID: 8306 RVA: 0x001DBD74 File Offset: 0x001D9F74
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

	// Token: 0x040046FB RID: 18171
	public GameObject DestroyedCandlestick;

	// Token: 0x040046FC RID: 18172
	public bool Destroyed;

	// Token: 0x040046FD RID: 18173
	public AudioClip Break;
}
