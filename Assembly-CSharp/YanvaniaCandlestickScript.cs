using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YanvaniaCandlestickScript : MonoBehaviour
{
	// Token: 0x06002065 RID: 8293 RVA: 0x001DA704 File Offset: 0x001D8904
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

	// Token: 0x040046E0 RID: 18144
	public GameObject DestroyedCandlestick;

	// Token: 0x040046E1 RID: 18145
	public bool Destroyed;

	// Token: 0x040046E2 RID: 18146
	public AudioClip Break;
}
