using System;
using UnityEngine;

// Token: 0x020004CC RID: 1228
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x06002056 RID: 8278 RVA: 0x001DA14D File Offset: 0x001D834D
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x06002057 RID: 8279 RVA: 0x001DA164 File Offset: 0x001D8364
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06002058 RID: 8280 RVA: 0x001DA1EC File Offset: 0x001D83EC
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.BlackExplosion, base.transform.position, Quaternion.identity);
			this.Yanmont.TakeDamage(20);
		}
		if (other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.BlackExplosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040046CD RID: 18125
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046CE RID: 18126
	public GameObject BlackExplosion;
}
