using System;
using UnityEngine;

// Token: 0x02000471 RID: 1137
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001EA3 RID: 7843 RVA: 0x001AE46C File Offset: 0x001AC66C
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001EA4 RID: 7844 RVA: 0x001AE490 File Offset: 0x001AC690
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

	// Token: 0x06001EA5 RID: 7845 RVA: 0x001AE570 File Offset: 0x001AC770
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

	// Token: 0x04003F57 RID: 16215
	public GameObject FemaleScream;

	// Token: 0x04003F58 RID: 16216
	public GameObject MaleScream;

	// Token: 0x04003F59 RID: 16217
	public bool Unfreeze;

	// Token: 0x04003F5A RID: 16218
	public float Speed = 0.1f;

	// Token: 0x04003F5B RID: 16219
	private float Timer;
}
