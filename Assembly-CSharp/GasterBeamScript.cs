using System;
using UnityEngine;

// Token: 0x020002D6 RID: 726
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014BA RID: 5306 RVA: 0x000CC042 File Offset: 0x000CA242
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014BB RID: 5307 RVA: 0x000CC06C File Offset: 0x000CA26C
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

	// Token: 0x060014BC RID: 5308 RVA: 0x000CC104 File Offset: 0x000CA304
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

	// Token: 0x04002090 RID: 8336
	public float Strength = 1000f;

	// Token: 0x04002091 RID: 8337
	public float Target = 2f;

	// Token: 0x04002092 RID: 8338
	public bool LoveLoveBeam;
}
