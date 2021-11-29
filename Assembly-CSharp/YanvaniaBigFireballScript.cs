using System;
using UnityEngine;

// Token: 0x020004C9 RID: 1225
public class YanvaniaBigFireballScript : MonoBehaviour
{
	// Token: 0x06002040 RID: 8256 RVA: 0x001D83C4 File Offset: 0x001D65C4
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004684 RID: 18052
	public GameObject Explosion;
}
