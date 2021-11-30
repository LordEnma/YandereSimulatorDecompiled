using System;
using UnityEngine;

// Token: 0x020002C1 RID: 705
public class FalconPunchScript : MonoBehaviour
{
	// Token: 0x06001475 RID: 5237 RVA: 0x000C750F File Offset: 0x000C570F
	private void Start()
	{
		if (this.Mecha)
		{
			this.MyRigidbody.AddForce(base.transform.forward * this.Speed * 10f);
		}
	}

	// Token: 0x06001476 RID: 5238 RVA: 0x000C7544 File Offset: 0x000C5744
	private void Update()
	{
		if (!this.IgnoreTime)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > this.TimeLimit)
			{
				this.MyCollider.enabled = false;
			}
		}
		if (this.Shipgirl)
		{
			this.MyRigidbody.AddForce(base.transform.forward * this.Speed);
		}
	}

	// Token: 0x06001477 RID: 5239 RVA: 0x000C75B0 File Offset: 0x000C57B0
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("A punch collided with something.");
		if (other.gameObject.layer == 9)
		{
			Debug.Log("A punch collided with something on the Characters layer.");
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				Debug.Log("A punch collided with a student.");
				if (component.StudentID > 1)
				{
					Debug.Log("A punch collided with a student and killed them.");
					UnityEngine.Object.Instantiate<GameObject>(this.FalconExplosion, component.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
					component.DeathType = DeathType.EasterEgg;
					component.BecomeRagdoll();
					Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
					rigidbody.isKinematic = false;
					Vector3 vector = rigidbody.transform.position - component.Yandere.transform.position;
					if (this.Falcon)
					{
						rigidbody.AddForce(vector * this.Strength);
					}
					else if (this.Bancho)
					{
						rigidbody.AddForce(vector.x * this.Strength, 5000f, vector.z * this.Strength);
					}
					else
					{
						rigidbody.AddForce(vector.x * this.Strength, 10000f, vector.z * this.Strength);
					}
				}
			}
		}
		if (this.Destructive && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 9 && other.gameObject.layer != 13 && other.gameObject.layer != 17)
		{
			GameObject gameObject = null;
			StudentScript component2 = other.gameObject.transform.root.GetComponent<StudentScript>();
			if (component2 != null)
			{
				if (component2.StudentID <= 1)
				{
					gameObject = component2.gameObject;
				}
			}
			else
			{
				gameObject = other.gameObject;
			}
			if (gameObject != null)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.FalconExplosion, base.transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
				UnityEngine.Object.Destroy(gameObject);
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x04001F9D RID: 8093
	public GameObject FalconExplosion;

	// Token: 0x04001F9E RID: 8094
	public Rigidbody MyRigidbody;

	// Token: 0x04001F9F RID: 8095
	public Collider MyCollider;

	// Token: 0x04001FA0 RID: 8096
	public float Strength = 100f;

	// Token: 0x04001FA1 RID: 8097
	public float Speed = 100f;

	// Token: 0x04001FA2 RID: 8098
	public bool Destructive;

	// Token: 0x04001FA3 RID: 8099
	public bool IgnoreTime;

	// Token: 0x04001FA4 RID: 8100
	public bool Shipgirl;

	// Token: 0x04001FA5 RID: 8101
	public bool Bancho;

	// Token: 0x04001FA6 RID: 8102
	public bool Falcon;

	// Token: 0x04001FA7 RID: 8103
	public bool Mecha;

	// Token: 0x04001FA8 RID: 8104
	public float TimeLimit = 0.5f;

	// Token: 0x04001FA9 RID: 8105
	public float Timer;
}
