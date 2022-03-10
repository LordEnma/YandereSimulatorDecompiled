using System;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001EF0 RID: 7920 RVA: 0x001B3AEC File Offset: 0x001B1CEC
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001EF1 RID: 7921 RVA: 0x001B3B6C File Offset: 0x001B1D6C
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

	// Token: 0x0400405D RID: 16477
	public GameObject FemaleBloodyScream;

	// Token: 0x0400405E RID: 16478
	public GameObject MaleBloodyScream;

	// Token: 0x0400405F RID: 16479
	public GameObject Scream;

	// Token: 0x04004060 RID: 16480
	public Collider MyCollider;

	// Token: 0x04004061 RID: 16481
	public float Strength = 10000f;

	// Token: 0x04004062 RID: 16482
	public float Timer;
}
