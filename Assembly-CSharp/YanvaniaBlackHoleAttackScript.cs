using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
	// Token: 0x060020C1 RID: 8385 RVA: 0x001E3C9D File Offset: 0x001E1E9D
	private void Start()
	{
		this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();
	}

	// Token: 0x060020C2 RID: 8386 RVA: 0x001E3CB4 File Offset: 0x001E1EB4
	private void Update()
	{
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yanmont.transform.position) > 10f || this.Yanmont.EnterCutscene)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060020C3 RID: 8387 RVA: 0x001E3D3C File Offset: 0x001E1F3C
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

	// Token: 0x040047EE RID: 18414
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x040047EF RID: 18415
	public GameObject BlackExplosion;
}
