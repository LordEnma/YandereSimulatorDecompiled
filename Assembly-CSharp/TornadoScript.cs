using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001EC8 RID: 7880 RVA: 0x001AFF40 File Offset: 0x001AE140
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001EC9 RID: 7881 RVA: 0x001AFFC0 File Offset: 0x001AE1C0
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

	// Token: 0x04003FFA RID: 16378
	public GameObject FemaleBloodyScream;

	// Token: 0x04003FFB RID: 16379
	public GameObject MaleBloodyScream;

	// Token: 0x04003FFC RID: 16380
	public GameObject Scream;

	// Token: 0x04003FFD RID: 16381
	public Collider MyCollider;

	// Token: 0x04003FFE RID: 16382
	public float Strength = 10000f;

	// Token: 0x04003FFF RID: 16383
	public float Timer;
}
