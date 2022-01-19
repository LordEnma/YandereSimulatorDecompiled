using System;
using UnityEngine;

// Token: 0x02000471 RID: 1137
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001EA2 RID: 7842 RVA: 0x001ADF94 File Offset: 0x001AC194
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001EA3 RID: 7843 RVA: 0x001ADFB8 File Offset: 0x001AC1B8
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

	// Token: 0x06001EA4 RID: 7844 RVA: 0x001AE098 File Offset: 0x001AC298
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

	// Token: 0x04003F4F RID: 16207
	public GameObject FemaleScream;

	// Token: 0x04003F50 RID: 16208
	public GameObject MaleScream;

	// Token: 0x04003F51 RID: 16209
	public bool Unfreeze;

	// Token: 0x04003F52 RID: 16210
	public float Speed = 0.1f;

	// Token: 0x04003F53 RID: 16211
	private float Timer;
}
