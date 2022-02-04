using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x06002067 RID: 8295 RVA: 0x001DC310 File Offset: 0x001DA510
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046F8 RID: 18168
	public GameObject Explosion;
}
