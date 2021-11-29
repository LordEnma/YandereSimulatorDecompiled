using System;
using UnityEngine;

// Token: 0x0200046D RID: 1133
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001E89 RID: 7817 RVA: 0x001AB704 File Offset: 0x001A9904
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001E8A RID: 7818 RVA: 0x001AB728 File Offset: 0x001A9928
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

	// Token: 0x06001E8B RID: 7819 RVA: 0x001AB808 File Offset: 0x001A9A08
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

	// Token: 0x04003EFD RID: 16125
	public GameObject FemaleScream;

	// Token: 0x04003EFE RID: 16126
	public GameObject MaleScream;

	// Token: 0x04003EFF RID: 16127
	public bool Unfreeze;

	// Token: 0x04003F00 RID: 16128
	public float Speed = 0.1f;

	// Token: 0x04003F01 RID: 16129
	private float Timer;
}
