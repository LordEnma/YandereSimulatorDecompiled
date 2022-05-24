using System;
using UnityEngine;

// Token: 0x02000489 RID: 1161
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001F2D RID: 7981 RVA: 0x001BA104 File Offset: 0x001B8304
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001F2E RID: 7982 RVA: 0x001BA184 File Offset: 0x001B8384
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

	// Token: 0x04004125 RID: 16677
	public GameObject FemaleBloodyScream;

	// Token: 0x04004126 RID: 16678
	public GameObject MaleBloodyScream;

	// Token: 0x04004127 RID: 16679
	public GameObject Scream;

	// Token: 0x04004128 RID: 16680
	public Collider MyCollider;

	// Token: 0x04004129 RID: 16681
	public float Strength = 10000f;

	// Token: 0x0400412A RID: 16682
	public float Timer;
}
