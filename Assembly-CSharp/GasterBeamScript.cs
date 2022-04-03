using System;
using UnityEngine;

// Token: 0x020002DB RID: 731
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014DA RID: 5338 RVA: 0x000CE55A File Offset: 0x000CC75A
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014DB RID: 5339 RVA: 0x000CE584 File Offset: 0x000CC784
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

	// Token: 0x060014DC RID: 5340 RVA: 0x000CE61C File Offset: 0x000CC81C
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

	// Token: 0x040020F5 RID: 8437
	public float Strength = 1000f;

	// Token: 0x040020F6 RID: 8438
	public float Target = 2f;

	// Token: 0x040020F7 RID: 8439
	public bool LoveLoveBeam;
}
