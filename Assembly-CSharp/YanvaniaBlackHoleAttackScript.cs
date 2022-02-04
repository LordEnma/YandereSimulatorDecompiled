using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x06002069 RID: 8297 RVA: 0x001DC375 File Offset: 0x001DA575
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x0600206A RID: 8298 RVA: 0x001DC38C File Offset: 0x001DA58C
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600206B RID: 8299 RVA: 0x001DC414 File Offset: 0x001DA614
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

	// Token: 0x040046F9 RID: 18169
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046FA RID: 18170
	public GameObject BlackExplosion;
}
