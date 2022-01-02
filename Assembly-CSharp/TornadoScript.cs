using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001ECA RID: 7882 RVA: 0x001B03F4 File Offset: 0x001AE5F4
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001ECB RID: 7883 RVA: 0x001B0474 File Offset: 0x001AE674
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

	// Token: 0x04004001 RID: 16385
	public GameObject FemaleBloodyScream;

	// Token: 0x04004002 RID: 16386
	public GameObject MaleBloodyScream;

	// Token: 0x04004003 RID: 16387
	public GameObject Scream;

	// Token: 0x04004004 RID: 16388
	public Collider MyCollider;

	// Token: 0x04004005 RID: 16389
	public float Strength = 10000f;

	// Token: 0x04004006 RID: 16390
	public float Timer;
}
