using System;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001E95 RID: 7829 RVA: 0x001AC944 File Offset: 0x001AAB44
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001E96 RID: 7830 RVA: 0x001AC968 File Offset: 0x001AAB68
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

	// Token: 0x06001E97 RID: 7831 RVA: 0x001ACA48 File Offset: 0x001AAC48
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

	// Token: 0x04003F34 RID: 16180
	public GameObject FemaleScream;

	// Token: 0x04003F35 RID: 16181
	public GameObject MaleScream;

	// Token: 0x04003F36 RID: 16182
	public bool Unfreeze;

	// Token: 0x04003F37 RID: 16183
	public float Speed = 0.1f;

	// Token: 0x04003F38 RID: 16184
	private float Timer;
}
