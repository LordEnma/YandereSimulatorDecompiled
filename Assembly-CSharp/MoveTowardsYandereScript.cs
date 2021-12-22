using System;
using UnityEngine;

// Token: 0x0200036C RID: 876
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019AB RID: 6571 RVA: 0x00105FD2 File Offset: 0x001041D2
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019AC RID: 6572 RVA: 0x00106014 File Offset: 0x00104214
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

	// Token: 0x04002915 RID: 10517
	public ParticleSystem Smoke;

	// Token: 0x04002916 RID: 10518
	public Transform Yandere;

	// Token: 0x04002917 RID: 10519
	public float Distance;

	// Token: 0x04002918 RID: 10520
	public float Speed;

	// Token: 0x04002919 RID: 10521
	public bool Fall;
}
