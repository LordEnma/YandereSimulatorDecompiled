using System;
using UnityEngine;

// Token: 0x020002D8 RID: 728
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014C6 RID: 5318 RVA: 0x000CD2CA File Offset: 0x000CB4CA
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014C7 RID: 5319 RVA: 0x000CD2F4 File Offset: 0x000CB4F4
	private void Update()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(100f, this.Target, this.Target), Time.deltaTime * 10f);
			if (base.transform.localScale.x > 99.99f)
			{
				this.Target = 0f;
				if (base.transform.localScale.y < 0.1f)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}

	// Token: 0x060014C8 RID: 5320 RVA: 0x000CD38C File Offset: 0x000CB58C
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				component.DeathType = DeathType.Burning;
				component.BecomeRagdoll();
				Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
				rigidbody.isKinematic = false;
				rigidbody.AddForce((rigidbody.transform.root.position - base.transform.root.position) * this.Strength);
				rigidbody.AddForce(Vector3.up * 1000f);
			}
		}
	}

	// Token: 0x040020C0 RID: 8384
	public float Strength = 1000f;

	// Token: 0x040020C1 RID: 8385
	public float Target = 2f;

	// Token: 0x040020C2 RID: 8386
	public bool LoveLoveBeam;
}
