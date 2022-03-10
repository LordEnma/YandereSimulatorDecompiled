using System;
using UnityEngine;

// Token: 0x020002DA RID: 730
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014D4 RID: 5332 RVA: 0x000CDEAE File Offset: 0x000CC0AE
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014D5 RID: 5333 RVA: 0x000CDED8 File Offset: 0x000CC0D8
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

	// Token: 0x060014D6 RID: 5334 RVA: 0x000CDF70 File Offset: 0x000CC170
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

	// Token: 0x040020E0 RID: 8416
	public float Strength = 1000f;

	// Token: 0x040020E1 RID: 8417
	public float Target = 2f;

	// Token: 0x040020E2 RID: 8418
	public bool LoveLoveBeam;
}
