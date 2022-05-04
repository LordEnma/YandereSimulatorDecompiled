using System;
using UnityEngine;

// Token: 0x02000488 RID: 1160
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001F24 RID: 7972 RVA: 0x001B8AFC File Offset: 0x001B6CFC
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001F25 RID: 7973 RVA: 0x001B8B7C File Offset: 0x001B6D7C
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

	// Token: 0x040040FE RID: 16638
	public GameObject FemaleBloodyScream;

	// Token: 0x040040FF RID: 16639
	public GameObject MaleBloodyScream;

	// Token: 0x04004100 RID: 16640
	public GameObject Scream;

	// Token: 0x04004101 RID: 16641
	public Collider MyCollider;

	// Token: 0x04004102 RID: 16642
	public float Strength = 10000f;

	// Token: 0x04004103 RID: 16643
	public float Timer;
}
