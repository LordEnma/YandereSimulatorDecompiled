using System;
using UnityEngine;

// Token: 0x020004CC RID: 1228
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x06002053 RID: 8275 RVA: 0x001D9B5D File Offset: 0x001D7D5D
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x06002054 RID: 8276 RVA: 0x001D9B74 File Offset: 0x001D7D74
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06002055 RID: 8277 RVA: 0x001D9BFC File Offset: 0x001D7DFC
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

	// Token: 0x040046C4 RID: 18116
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046C5 RID: 18117
	public GameObject BlackExplosion;
}
