using System;
using UnityEngine;

// Token: 0x020002DA RID: 730
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014D4 RID: 5332 RVA: 0x000CDD32 File Offset: 0x000CBF32
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014D5 RID: 5333 RVA: 0x000CDD5C File Offset: 0x000CBF5C
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

	// Token: 0x060014D6 RID: 5334 RVA: 0x000CDDF4 File Offset: 0x000CBFF4
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

	// Token: 0x040020D6 RID: 8406
	public float Strength = 1000f;

	// Token: 0x040020D7 RID: 8407
	public float Target = 2f;

	// Token: 0x040020D8 RID: 8408
	public bool LoveLoveBeam;
}
