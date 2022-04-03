using System;
using UnityEngine;

// Token: 0x02000479 RID: 1145
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001ED7 RID: 7895 RVA: 0x001B2D78 File Offset: 0x001B0F78
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001ED8 RID: 7896 RVA: 0x001B2D9C File Offset: 0x001B0F9C
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

	// Token: 0x06001ED9 RID: 7897 RVA: 0x001B2E7C File Offset: 0x001B107C
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

	// Token: 0x04004008 RID: 16392
	public GameObject FemaleScream;

	// Token: 0x04004009 RID: 16393
	public GameObject MaleScream;

	// Token: 0x0400400A RID: 16394
	public bool Unfreeze;

	// Token: 0x0400400B RID: 16395
	public float Speed = 0.1f;

	// Token: 0x0400400C RID: 16396
	private float Timer;
}
