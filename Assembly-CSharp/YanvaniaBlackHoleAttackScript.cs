using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x06002061 RID: 8289 RVA: 0x001DAAED File Offset: 0x001D8CED
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x06002062 RID: 8290 RVA: 0x001DAB04 File Offset: 0x001D8D04
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06002063 RID: 8291 RVA: 0x001DAB8C File Offset: 0x001D8D8C
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

	// Token: 0x040046E1 RID: 18145
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040046E2 RID: 18146
	public GameObject BlackExplosion;
}
