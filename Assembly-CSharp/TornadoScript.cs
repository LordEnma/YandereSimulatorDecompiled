using System;
using UnityEngine;

// Token: 0x02000487 RID: 1159
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001F14 RID: 7956 RVA: 0x001B6CB8 File Offset: 0x001B4EB8
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001F15 RID: 7957 RVA: 0x001B6D38 File Offset: 0x001B4F38
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

	// Token: 0x040040D8 RID: 16600
	public GameObject FemaleBloodyScream;

	// Token: 0x040040D9 RID: 16601
	public GameObject MaleBloodyScream;

	// Token: 0x040040DA RID: 16602
	public GameObject Scream;

	// Token: 0x040040DB RID: 16603
	public Collider MyCollider;

	// Token: 0x040040DC RID: 16604
	public float Strength = 10000f;

	// Token: 0x040040DD RID: 16605
	public float Timer;
}
