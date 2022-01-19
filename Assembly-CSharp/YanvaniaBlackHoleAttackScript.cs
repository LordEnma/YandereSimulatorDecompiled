using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x06002063 RID: 8291 RVA: 0x001DB7BD File Offset: 0x001D99BD
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x06002064 RID: 8292 RVA: 0x001DB7D4 File Offset: 0x001D99D4
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06002065 RID: 8293 RVA: 0x001DB85C File Offset: 0x001D9A5C
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

	// Token: 0x040046E8 RID: 18152
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046E9 RID: 18153
	public GameObject BlackExplosion;
}
