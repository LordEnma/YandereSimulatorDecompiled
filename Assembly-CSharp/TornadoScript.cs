using System;
using UnityEngine;

// Token: 0x0200047F RID: 1151
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001EE4 RID: 7908 RVA: 0x001B2878 File Offset: 0x001B0A78
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001EE5 RID: 7909 RVA: 0x001B28F8 File Offset: 0x001B0AF8
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

	// Token: 0x04004036 RID: 16438
	public GameObject FemaleBloodyScream;

	// Token: 0x04004037 RID: 16439
	public GameObject MaleBloodyScream;

	// Token: 0x04004038 RID: 16440
	public GameObject Scream;

	// Token: 0x04004039 RID: 16441
	public Collider MyCollider;

	// Token: 0x0400403A RID: 16442
	public float Strength = 10000f;

	// Token: 0x0400403B RID: 16443
	public float Timer;
}
