using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x06002061 RID: 8289 RVA: 0x001DB758 File Offset: 0x001D9958
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046E7 RID: 18151
	public GameObject Explosion;
}
