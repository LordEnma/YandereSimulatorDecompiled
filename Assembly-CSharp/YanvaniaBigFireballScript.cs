using System;
using UnityEngine;

// Token: 0x020004CB RID: 1227
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x06002054 RID: 8276 RVA: 0x001DA0E8 File Offset: 0x001D82E8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046CC RID: 18124
	public GameObject Explosion;
}
