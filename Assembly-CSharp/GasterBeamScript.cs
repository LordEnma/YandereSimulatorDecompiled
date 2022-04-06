using System;
using UnityEngine;

// Token: 0x020002DC RID: 732
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014E0 RID: 5344 RVA: 0x000CE662 File Offset: 0x000CC862
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014E1 RID: 5345 RVA: 0x000CE68C File Offset: 0x000CC88C
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

	// Token: 0x060014E2 RID: 5346 RVA: 0x000CE724 File Offset: 0x000CC924
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

	// Token: 0x040020F7 RID: 8439
	public float Strength = 1000f;

	// Token: 0x040020F8 RID: 8440
	public float Target = 2f;

	// Token: 0x040020F9 RID: 8441
	public bool LoveLoveBeam;
}
