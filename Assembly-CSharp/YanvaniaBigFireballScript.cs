using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x06002071 RID: 8305 RVA: 0x001DC9C8 File Offset: 0x001DABC8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004704 RID: 18180
	public GameObject Explosion;
}
