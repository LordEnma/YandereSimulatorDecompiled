using System;
using UnityEngine;

// Token: 0x020002D8 RID: 728
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014C5 RID: 5317 RVA: 0x000CCD0E File Offset: 0x000CAF0E
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014C6 RID: 5318 RVA: 0x000CCD38 File Offset: 0x000CAF38
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

	// Token: 0x060014C7 RID: 5319 RVA: 0x000CCDD0 File Offset: 0x000CAFD0
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

	// Token: 0x040020B7 RID: 8375
	public float Strength = 1000f;

	// Token: 0x040020B8 RID: 8376
	public float Target = 2f;

	// Token: 0x040020B9 RID: 8377
	public bool LoveLoveBeam;
}
