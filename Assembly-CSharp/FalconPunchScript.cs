using System;
using UnityEngine;

// Token: 0x020002C6 RID: 710
public class FalconPunchScript : MonoBehaviour
{
	// Token: 0x0600149D RID: 5277 RVA: 0x000C9E33 File Offset: 0x000C8033
	private void Start()
	{
		if (this.Mecha)
		{
			this.MyRigidbody.AddForce(base.transform.forward * this.Speed * 10f);
		}
	}

	// Token: 0x0600149E RID: 5278 RVA: 0x000C9E68 File Offset: 0x000C8068
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

	// Token: 0x0600149F RID: 5279 RVA: 0x000C9ED4 File Offset: 0x000C80D4
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

	// Token: 0x0400200B RID: 8203
	public GameObject FalconExplosion;

	// Token: 0x0400200C RID: 8204
	public Rigidbody MyRigidbody;

	// Token: 0x0400200D RID: 8205
	public Collider MyCollider;

	// Token: 0x0400200E RID: 8206
	public float Strength = 100f;

	// Token: 0x0400200F RID: 8207
	public float Speed = 100f;

	// Token: 0x04002010 RID: 8208
	public bool Destructive;

	// Token: 0x04002011 RID: 8209
	public bool IgnoreTime;

	// Token: 0x04002012 RID: 8210
	public bool Shipgirl;

	// Token: 0x04002013 RID: 8211
	public bool Bancho;

	// Token: 0x04002014 RID: 8212
	public bool Falcon;

	// Token: 0x04002015 RID: 8213
	public bool Mecha;

	// Token: 0x04002016 RID: 8214
	public float TimeLimit = 0.5f;

	// Token: 0x04002017 RID: 8215
	public float Timer;
}
