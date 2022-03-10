using System;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001EBB RID: 7867 RVA: 0x001B00B4 File Offset: 0x001AE2B4
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001EBC RID: 7868 RVA: 0x001B00D8 File Offset: 0x001AE2D8
	private void Update()
	{
		if (!this.Unfreeze)
		{
			this.Speed = Mathf.MoveTowards(this.Speed, 0f, Time.deltaTime);
			if (base.transform.localScale.x < 0.99f)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
		}
		else
		{
			this.Speed = 10f;
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
		base.transform.Translate(Vector3.forward * this.Speed * Time.deltaTime, Space.Self);
	}

	// Token: 0x06001EBD RID: 7869 RVA: 0x001B01B8 File Offset: 0x001AE3B8
	private void OnTriggerEnter(Collider other)
	{
		if (this.Unfreeze && other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				if (component.Male)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.MaleScream, base.transform.position, Quaternion.identity);
				}
				else
				{
					UnityEngine.Object.Instantiate<GameObject>(this.FemaleScream, base.transform.position, Quaternion.identity);
				}
				component.DeathType = DeathType.EasterEgg;
				component.BecomeRagdoll();
			}
		}
	}

	// Token: 0x04003F90 RID: 16272
	public GameObject FemaleScream;

	// Token: 0x04003F91 RID: 16273
	public GameObject MaleScream;

	// Token: 0x04003F92 RID: 16274
	public bool Unfreeze;

	// Token: 0x04003F93 RID: 16275
	public float Speed = 0.1f;

	// Token: 0x04003F94 RID: 16276
	private float Timer;
}
