using System;
using UnityEngine;

// Token: 0x02000471 RID: 1137
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001EA5 RID: 7845 RVA: 0x001AE778 File Offset: 0x001AC978
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001EA6 RID: 7846 RVA: 0x001AE79C File Offset: 0x001AC99C
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

	// Token: 0x06001EA7 RID: 7847 RVA: 0x001AE87C File Offset: 0x001ACA7C
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

	// Token: 0x04003F5D RID: 16221
	public GameObject FemaleScream;

	// Token: 0x04003F5E RID: 16222
	public GameObject MaleScream;

	// Token: 0x04003F5F RID: 16223
	public bool Unfreeze;

	// Token: 0x04003F60 RID: 16224
	public float Speed = 0.1f;

	// Token: 0x04003F61 RID: 16225
	private float Timer;
}
