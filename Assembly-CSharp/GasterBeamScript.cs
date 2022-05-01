using System;
using UnityEngine;

// Token: 0x020002DC RID: 732
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014E6 RID: 5350 RVA: 0x000CECF6 File Offset: 0x000CCEF6
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014E7 RID: 5351 RVA: 0x000CED20 File Offset: 0x000CCF20
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

	// Token: 0x060014E8 RID: 5352 RVA: 0x000CEDB8 File Offset: 0x000CCFB8
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

	// Token: 0x04002102 RID: 8450
	public float Strength = 1000f;

	// Token: 0x04002103 RID: 8451
	public float Target = 2f;

	// Token: 0x04002104 RID: 8452
	public bool LoveLoveBeam;
}
