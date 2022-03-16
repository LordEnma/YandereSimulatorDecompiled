using System;
using UnityEngine;

// Token: 0x020002DA RID: 730
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014D7 RID: 5335 RVA: 0x000CE31E File Offset: 0x000CC51E
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014D8 RID: 5336 RVA: 0x000CE348 File Offset: 0x000CC548
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

	// Token: 0x060014D9 RID: 5337 RVA: 0x000CE3E0 File Offset: 0x000CC5E0
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

	// Token: 0x040020F0 RID: 8432
	public float Strength = 1000f;

	// Token: 0x040020F1 RID: 8433
	public float Target = 2f;

	// Token: 0x040020F2 RID: 8434
	public bool LoveLoveBeam;
}
