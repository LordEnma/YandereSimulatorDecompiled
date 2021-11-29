using System;
using UnityEngine;

// Token: 0x0200047A RID: 1146
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001EBE RID: 7870 RVA: 0x001AF170 File Offset: 0x001AD370
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001EBF RID: 7871 RVA: 0x001AF1F0 File Offset: 0x001AD3F0
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				this.Scream = UnityEngine.Object.Instantiate<GameObject>(component.Male ? this.MaleBloodyScream : this.FemaleBloodyScream, component.transform.position + Vector3.up, Quaternion.identity);
				this.Scream.transform.parent = component.HipCollider.transform;
				this.Scream.transform.localPosition = Vector3.zero;
				component.DeathType = DeathType.EasterEgg;
				component.BecomeRagdoll();
				Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
				rigidbody.isKinematic = false;
				rigidbody.AddForce(Vector3.up * this.Strength);
			}
		}
	}

	// Token: 0x04003FCA RID: 16330
	public GameObject FemaleBloodyScream;

	// Token: 0x04003FCB RID: 16331
	public GameObject MaleBloodyScream;

	// Token: 0x04003FCC RID: 16332
	public GameObject Scream;

	// Token: 0x04003FCD RID: 16333
	public Collider MyCollider;

	// Token: 0x04003FCE RID: 16334
	public float Strength = 10000f;

	// Token: 0x04003FCF RID: 16335
	public float Timer;
}
