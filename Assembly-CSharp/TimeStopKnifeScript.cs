using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001EEE RID: 7918 RVA: 0x001B4FC8 File Offset: 0x001B31C8
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001EEF RID: 7919 RVA: 0x001B4FEC File Offset: 0x001B31EC
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

	// Token: 0x06001EF0 RID: 7920 RVA: 0x001B50CC File Offset: 0x001B32CC
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

	// Token: 0x04004031 RID: 16433
	public GameObject FemaleScream;

	// Token: 0x04004032 RID: 16434
	public GameObject MaleScream;

	// Token: 0x04004033 RID: 16435
	public bool Unfreeze;

	// Token: 0x04004034 RID: 16436
	public float Speed = 0.1f;

	// Token: 0x04004035 RID: 16437
	private float Timer;
}
