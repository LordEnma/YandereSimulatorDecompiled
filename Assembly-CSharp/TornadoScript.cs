using System;
using UnityEngine;

// Token: 0x02000486 RID: 1158
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001F0C RID: 7948 RVA: 0x001B67B0 File Offset: 0x001B49B0
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001F0D RID: 7949 RVA: 0x001B6830 File Offset: 0x001B4A30
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

	// Token: 0x040040D5 RID: 16597
	public GameObject FemaleBloodyScream;

	// Token: 0x040040D6 RID: 16598
	public GameObject MaleBloodyScream;

	// Token: 0x040040D7 RID: 16599
	public GameObject Scream;

	// Token: 0x040040D8 RID: 16600
	public Collider MyCollider;

	// Token: 0x040040D9 RID: 16601
	public float Strength = 10000f;

	// Token: 0x040040DA RID: 16602
	public float Timer;
}
