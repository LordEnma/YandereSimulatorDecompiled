using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x06002080 RID: 8320 RVA: 0x001DDF80 File Offset: 0x001DC180
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004731 RID: 18225
	public GameObject Explosion;
}
