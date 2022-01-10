using System;
using UnityEngine;

// Token: 0x0200047D RID: 1149
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001ED5 RID: 7893 RVA: 0x001B0D74 File Offset: 0x001AEF74
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001ED6 RID: 7894 RVA: 0x001B0DF4 File Offset: 0x001AEFF4
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

	// Token: 0x04004015 RID: 16405
	public GameObject FemaleBloodyScream;

	// Token: 0x04004016 RID: 16406
	public GameObject MaleBloodyScream;

	// Token: 0x04004017 RID: 16407
	public GameObject Scream;

	// Token: 0x04004018 RID: 16408
	public Collider MyCollider;

	// Token: 0x04004019 RID: 16409
	public float Strength = 10000f;

	// Token: 0x0400401A RID: 16410
	public float Timer;
}
