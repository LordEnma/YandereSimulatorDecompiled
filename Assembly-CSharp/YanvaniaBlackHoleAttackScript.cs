using System;
using UnityEngine;

// Token: 0x020004D6 RID: 1238
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x0600209A RID: 8346 RVA: 0x001DFF4D File Offset: 0x001DE14D
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x0600209B RID: 8347 RVA: 0x001DFF64 File Offset: 0x001DE164
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600209C RID: 8348 RVA: 0x001DFFEC File Offset: 0x001DE1EC
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

	// Token: 0x04004791 RID: 18321
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004792 RID: 18322
	public GameObject BlackExplosion;
}
