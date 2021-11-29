using System;
using UnityEngine;

// Token: 0x020004CA RID: 1226
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x06002042 RID: 8258 RVA: 0x001D8429 File Offset: 0x001D6629
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x06002043 RID: 8259 RVA: 0x001D8440 File Offset: 0x001D6640
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06002044 RID: 8260 RVA: 0x001D84C8 File Offset: 0x001D66C8
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

	// Token: 0x04004685 RID: 18053
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004686 RID: 18054
	public GameObject BlackExplosion;
}
