using System;
using UnityEngine;

// Token: 0x02000371 RID: 881
public class MoveTowardsYandereScript : MonoBehaviour
{
	// Token: 0x060019DC RID: 6620 RVA: 0x0010919E File Offset: 0x0010739E
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>().Spine[3];
		this.Distance = Vector3.Distance(base.transform.position, this.Yandere.position);
	}

	// Token: 0x060019DD RID: 6621 RVA: 0x001091E0 File Offset: 0x001073E0
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

	// Token: 0x04002997 RID: 10647
	public ParticleSystem Smoke;

	// Token: 0x04002998 RID: 10648
	public Transform Yandere;

	// Token: 0x04002999 RID: 10649
	public float Distance;

	// Token: 0x0400299A RID: 10650
	public float Speed;

	// Token: 0x0400299B RID: 10651
	public bool Fall;
}
