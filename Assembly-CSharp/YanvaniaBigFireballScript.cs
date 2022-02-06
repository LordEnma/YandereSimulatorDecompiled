using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x0600206A RID: 8298 RVA: 0x001DC514 File Offset: 0x001DA714
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046FB RID: 18171
	public GameObject Explosion;
}
