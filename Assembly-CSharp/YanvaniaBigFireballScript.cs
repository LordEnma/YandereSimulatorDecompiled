using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x0600207A RID: 8314 RVA: 0x001DD5A8 File Offset: 0x001DB7A8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004714 RID: 18196
	public GameObject Explosion;
}
