using System;
using UnityEngine;

// Token: 0x02000473 RID: 1139
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001EB8 RID: 7864 RVA: 0x001AF98C File Offset: 0x001ADB8C
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001EB9 RID: 7865 RVA: 0x001AF9B0 File Offset: 0x001ADBB0
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

	// Token: 0x06001EBA RID: 7866 RVA: 0x001AFA90 File Offset: 0x001ADC90
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

	// Token: 0x04003F79 RID: 16249
	public GameObject FemaleScream;

	// Token: 0x04003F7A RID: 16250
	public GameObject MaleScream;

	// Token: 0x04003F7B RID: 16251
	public bool Unfreeze;

	// Token: 0x04003F7C RID: 16252
	public float Speed = 0.1f;

	// Token: 0x04003F7D RID: 16253
	private float Timer;
}
