using System;
using UnityEngine;

// Token: 0x02000483 RID: 1155
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001F02 RID: 7938 RVA: 0x001B523C File Offset: 0x001B343C
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001F03 RID: 7939 RVA: 0x001B52BC File Offset: 0x001B34BC
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

	// Token: 0x040040A8 RID: 16552
	public GameObject FemaleBloodyScream;

	// Token: 0x040040A9 RID: 16553
	public GameObject MaleBloodyScream;

	// Token: 0x040040AA RID: 16554
	public GameObject Scream;

	// Token: 0x040040AB RID: 16555
	public Collider MyCollider;

	// Token: 0x040040AC RID: 16556
	public float Strength = 10000f;

	// Token: 0x040040AD RID: 16557
	public float Timer;
}
