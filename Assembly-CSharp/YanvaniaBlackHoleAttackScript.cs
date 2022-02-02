using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x06002067 RID: 8295 RVA: 0x001DC05D File Offset: 0x001DA25D
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x06002068 RID: 8296 RVA: 0x001DC074 File Offset: 0x001DA274
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06002069 RID: 8297 RVA: 0x001DC0FC File Offset: 0x001DA2FC
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

	// Token: 0x040046F3 RID: 18163
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046F4 RID: 18164
	public GameObject BlackExplosion;
}
