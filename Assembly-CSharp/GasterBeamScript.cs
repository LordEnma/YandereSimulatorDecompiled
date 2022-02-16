using System;
using UnityEngine;

// Token: 0x020002D9 RID: 729
public class GasterBeamScript : MonoBehaviour
{
	// Token: 0x060014CB RID: 5323 RVA: 0x000CD44E File Offset: 0x000CB64E
	private void Start()
	{
		if (this.LoveLoveBeam)
		{
			base.transform.localScale = new Vector3(0f, 0f, 0f);
		}
	}

	// Token: 0x060014CC RID: 5324 RVA: 0x000CD478 File Offset: 0x000CB678
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

	// Token: 0x060014CD RID: 5325 RVA: 0x000CD510 File Offset: 0x000CB710
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

	// Token: 0x040020C7 RID: 8391
	public float Strength = 1000f;

	// Token: 0x040020C8 RID: 8392
	public float Target = 2f;

	// Token: 0x040020C9 RID: 8393
	public bool LoveLoveBeam;
}
