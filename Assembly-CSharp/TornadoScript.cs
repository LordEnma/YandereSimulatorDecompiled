using System;
using UnityEngine;

// Token: 0x02000480 RID: 1152
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001EED RID: 7917 RVA: 0x001B33C4 File Offset: 0x001B15C4
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001EEE RID: 7918 RVA: 0x001B3444 File Offset: 0x001B1644
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

	// Token: 0x04004046 RID: 16454
	public GameObject FemaleBloodyScream;

	// Token: 0x04004047 RID: 16455
	public GameObject MaleBloodyScream;

	// Token: 0x04004048 RID: 16456
	public GameObject Scream;

	// Token: 0x04004049 RID: 16457
	public Collider MyCollider;

	// Token: 0x0400404A RID: 16458
	public float Strength = 10000f;

	// Token: 0x0400404B RID: 16459
	public float Timer;
}
