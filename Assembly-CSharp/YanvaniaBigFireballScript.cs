using System;
using UnityEngine;

// Token: 0x020004CD RID: 1229
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x0600205F RID: 8287 RVA: 0x001DAA88 File Offset: 0x001D8C88
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046E0 RID: 18144
	public GameObject Explosion;
}
