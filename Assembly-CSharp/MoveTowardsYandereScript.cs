using System;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019D8 RID: 6616 RVA: 0x00108EDA File Offset: 0x001070DA
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019D9 RID: 6617 RVA: 0x00108F1C File Offset: 0x0010711C
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

	// Token: 0x0400298F RID: 10639
	public ParticleSystem Smoke;

	// Token: 0x04002990 RID: 10640
	public Transform Yandere;

	// Token: 0x04002991 RID: 10641
	public float Distance;

	// Token: 0x04002992 RID: 10642
	public float Speed;

	// Token: 0x04002993 RID: 10643
	public bool Fall;
}
