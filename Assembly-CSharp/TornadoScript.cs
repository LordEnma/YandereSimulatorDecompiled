using System;
using UnityEngine;

// Token: 0x02000487 RID: 1159
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001F1A RID: 7962 RVA: 0x001B7690 File Offset: 0x001B5890
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001F1B RID: 7963 RVA: 0x001B7710 File Offset: 0x001B5910
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

	// Token: 0x040040E8 RID: 16616
	public GameObject FemaleBloodyScream;

	// Token: 0x040040E9 RID: 16617
	public GameObject MaleBloodyScream;

	// Token: 0x040040EA RID: 16618
	public GameObject Scream;

	// Token: 0x040040EB RID: 16619
	public Collider MyCollider;

	// Token: 0x040040EC RID: 16620
	public float Strength = 10000f;

	// Token: 0x040040ED RID: 16621
	public float Timer;
}
