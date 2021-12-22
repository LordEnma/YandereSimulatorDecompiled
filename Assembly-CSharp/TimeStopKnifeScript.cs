using System;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001E93 RID: 7827 RVA: 0x001AC490 File Offset: 0x001AA690
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001E94 RID: 7828 RVA: 0x001AC4B4 File Offset: 0x001AA6B4
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

	// Token: 0x06001E95 RID: 7829 RVA: 0x001AC594 File Offset: 0x001AA794
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

	// Token: 0x04003F2D RID: 16173
	public GameObject FemaleScream;

	// Token: 0x04003F2E RID: 16174
	public GameObject MaleScream;

	// Token: 0x04003F2F RID: 16175
	public bool Unfreeze;

	// Token: 0x04003F30 RID: 16176
	public float Speed = 0.1f;

	// Token: 0x04003F31 RID: 16177
	private float Timer;
}
