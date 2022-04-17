using System;
using UnityEngine;

// Token: 0x020002DC RID: 732
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014E2 RID: 5346 RVA: 0x000CE84A File Offset: 0x000CCA4A
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014E3 RID: 5347 RVA: 0x000CE874 File Offset: 0x000CCA74
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

	// Token: 0x060014E4 RID: 5348 RVA: 0x000CE90C File Offset: 0x000CCB0C
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

	// Token: 0x040020F9 RID: 8441
	public float Strength = 1000f;

	// Token: 0x040020FA RID: 8442
	public float Target = 2f;

	// Token: 0x040020FB RID: 8443
	public bool LoveLoveBeam;
}
