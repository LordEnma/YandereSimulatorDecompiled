using System;
using UnityEngine;

// Token: 0x020002D7 RID: 727
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014C1 RID: 5313 RVA: 0x000CCA2E File Offset: 0x000CAC2E
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014C2 RID: 5314 RVA: 0x000CCA58 File Offset: 0x000CAC58
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

	// Token: 0x060014C3 RID: 5315 RVA: 0x000CCAF0 File Offset: 0x000CACF0
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

	// Token: 0x040020B3 RID: 8371
	public float Strength = 1000f;

	// Token: 0x040020B4 RID: 8372
	public float Target = 2f;

	// Token: 0x040020B5 RID: 8373
	public bool LoveLoveBeam;
}
