using System;
using UnityEngine;

// Token: 0x02000472 RID: 1138
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001EAF RID: 7855 RVA: 0x001AEE50 File Offset: 0x001AD050
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001EB0 RID: 7856 RVA: 0x001AEE74 File Offset: 0x001AD074
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

	// Token: 0x06001EB1 RID: 7857 RVA: 0x001AEF54 File Offset: 0x001AD154
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

	// Token: 0x04003F69 RID: 16233
	public GameObject FemaleScream;

	// Token: 0x04003F6A RID: 16234
	public GameObject MaleScream;

	// Token: 0x04003F6B RID: 16235
	public bool Unfreeze;

	// Token: 0x04003F6C RID: 16236
	public float Speed = 0.1f;

	// Token: 0x04003F6D RID: 16237
	private float Timer;
}
