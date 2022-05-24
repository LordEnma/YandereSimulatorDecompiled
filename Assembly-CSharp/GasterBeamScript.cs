using System;
using UnityEngine;

// Token: 0x020002DD RID: 733
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014E8 RID: 5352 RVA: 0x000CF042 File Offset: 0x000CD242
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014E9 RID: 5353 RVA: 0x000CF06C File Offset: 0x000CD26C
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

	// Token: 0x060014EA RID: 5354 RVA: 0x000CF104 File Offset: 0x000CD304
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

	// Token: 0x0400210B RID: 8459
	public float Strength = 1000f;

	// Token: 0x0400210C RID: 8460
	public float Target = 2f;

	// Token: 0x0400210D RID: 8461
	public bool LoveLoveBeam;
}
