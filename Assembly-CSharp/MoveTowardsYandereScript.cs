using System;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019E0 RID: 6624 RVA: 0x0010969E File Offset: 0x0010789E
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019E1 RID: 6625 RVA: 0x001096E0 File Offset: 0x001078E0
	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Yandere.position) > this.Distance * 0.5f && base.transform.position.y < this.Yandere.position.y + 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
		}
		this.Speed += Time.deltaTime;
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yandere.position, this.Speed * Time.deltaTime);
		if (Vector3.Distance(base.transform.position, this.Yandere.position) == 0f)
		{
			this.Smoke.emission.enabled = false;
		}
	}

	// Token: 0x040029A0 RID: 10656
	public ParticleSystem Smoke;

	// Token: 0x040029A1 RID: 10657
	public Transform Yandere;

	// Token: 0x040029A2 RID: 10658
	public float Distance;

	// Token: 0x040029A3 RID: 10659
	public float Speed;

	// Token: 0x040029A4 RID: 10660
	public bool Fall;
}
