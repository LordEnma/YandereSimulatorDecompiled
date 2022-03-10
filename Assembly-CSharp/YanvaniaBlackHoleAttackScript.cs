using System;
using UnityEngine;

// Token: 0x020004D2 RID: 1234
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x06002082 RID: 8322 RVA: 0x001DDFE5 File Offset: 0x001DC1E5
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x06002083 RID: 8323 RVA: 0x001DDFFC File Offset: 0x001DC1FC
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06002084 RID: 8324 RVA: 0x001DE084 File Offset: 0x001DC284
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

	// Token: 0x04004732 RID: 18226
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004733 RID: 18227
	public GameObject BlackExplosion;
}
