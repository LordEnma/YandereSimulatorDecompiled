using System;
using UnityEngine;

// Token: 0x0200047E RID: 1150
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001ED8 RID: 7896 RVA: 0x001B1F1C File Offset: 0x001B011C
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001ED9 RID: 7897 RVA: 0x001B1F9C File Offset: 0x001B019C
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

	// Token: 0x04004024 RID: 16420
	public GameObject FemaleBloodyScream;

	// Token: 0x04004025 RID: 16421
	public GameObject MaleBloodyScream;

	// Token: 0x04004026 RID: 16422
	public GameObject Scream;

	// Token: 0x04004027 RID: 16423
	public Collider MyCollider;

	// Token: 0x04004028 RID: 16424
	public float Strength = 10000f;

	// Token: 0x04004029 RID: 16425
	public float Timer;
}
