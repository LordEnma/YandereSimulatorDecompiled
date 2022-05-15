using System;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001F2C RID: 7980 RVA: 0x001B9C74 File Offset: 0x001B7E74
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001F2D RID: 7981 RVA: 0x001B9CF4 File Offset: 0x001B7EF4
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

	// Token: 0x0400411C RID: 16668
	public GameObject FemaleBloodyScream;

	// Token: 0x0400411D RID: 16669
	public GameObject MaleBloodyScream;

	// Token: 0x0400411E RID: 16670
	public GameObject Scream;

	// Token: 0x0400411F RID: 16671
	public Collider MyCollider;

	// Token: 0x04004120 RID: 16672
	public float Strength = 10000f;

	// Token: 0x04004121 RID: 16673
	public float Timer;
}
