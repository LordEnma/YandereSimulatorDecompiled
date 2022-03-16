using System;
using UnityEngine;

// Token: 0x020002C5 RID: 709
public class FalconPunchScript : MonoBehaviour
{
	// Token: 0x06001492 RID: 5266 RVA: 0x000C9583 File Offset: 0x000C7783
	private void Start()
	{
		if (this.Mecha)
		{
			this.MyRigidbody.AddForce(base.transform.forward * this.Speed * 10f);
		}
	}

	// Token: 0x06001493 RID: 5267 RVA: 0x000C95B8 File Offset: 0x000C77B8
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

	// Token: 0x06001494 RID: 5268 RVA: 0x000C9624 File Offset: 0x000C7824
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

	// Token: 0x04001FFB RID: 8187
	public GameObject FalconExplosion;

	// Token: 0x04001FFC RID: 8188
	public Rigidbody MyRigidbody;

	// Token: 0x04001FFD RID: 8189
	public Collider MyCollider;

	// Token: 0x04001FFE RID: 8190
	public float Strength = 100f;

	// Token: 0x04001FFF RID: 8191
	public float Speed = 100f;

	// Token: 0x04002000 RID: 8192
	public bool Destructive;

	// Token: 0x04002001 RID: 8193
	public bool IgnoreTime;

	// Token: 0x04002002 RID: 8194
	public bool Shipgirl;

	// Token: 0x04002003 RID: 8195
	public bool Bancho;

	// Token: 0x04002004 RID: 8196
	public bool Falcon;

	// Token: 0x04002005 RID: 8197
	public bool Mecha;

	// Token: 0x04002006 RID: 8198
	public float TimeLimit = 0.5f;

	// Token: 0x04002007 RID: 8199
	public float Timer;
}
