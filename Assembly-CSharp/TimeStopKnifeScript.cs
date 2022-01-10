using System;
using UnityEngine;

// Token: 0x02000470 RID: 1136
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001EA0 RID: 7840 RVA: 0x001AD2C4 File Offset: 0x001AB4C4
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001EA1 RID: 7841 RVA: 0x001AD2E8 File Offset: 0x001AB4E8
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

	// Token: 0x06001EA2 RID: 7842 RVA: 0x001AD3C8 File Offset: 0x001AB5C8
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

	// Token: 0x04003F48 RID: 16200
	public GameObject FemaleScream;

	// Token: 0x04003F49 RID: 16201
	public GameObject MaleScream;

	// Token: 0x04003F4A RID: 16202
	public bool Unfreeze;

	// Token: 0x04003F4B RID: 16203
	public float Speed = 0.1f;

	// Token: 0x04003F4C RID: 16204
	private float Timer;
}
