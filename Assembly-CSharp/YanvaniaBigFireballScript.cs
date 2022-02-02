using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x06002065 RID: 8293 RVA: 0x001DBFF8 File Offset: 0x001DA1F8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046F2 RID: 18162
	public GameObject Explosion;
}
