using System;
using UnityEngine;

// Token: 0x0200047A RID: 1146
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001EDF RID: 7903 RVA: 0x001B3280 File Offset: 0x001B1480
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001EE0 RID: 7904 RVA: 0x001B32A4 File Offset: 0x001B14A4
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

	// Token: 0x06001EE1 RID: 7905 RVA: 0x001B3384 File Offset: 0x001B1584
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

	// Token: 0x0400400B RID: 16395
	public GameObject FemaleScream;

	// Token: 0x0400400C RID: 16396
	public GameObject MaleScream;

	// Token: 0x0400400D RID: 16397
	public bool Unfreeze;

	// Token: 0x0400400E RID: 16398
	public float Speed = 0.1f;

	// Token: 0x0400400F RID: 16399
	private float Timer;
}
