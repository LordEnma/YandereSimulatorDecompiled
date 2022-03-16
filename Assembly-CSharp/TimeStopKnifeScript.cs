using System;
using UnityEngine;

// Token: 0x02000476 RID: 1142
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001ECD RID: 7885 RVA: 0x001B1804 File Offset: 0x001AFA04
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001ECE RID: 7886 RVA: 0x001B1828 File Offset: 0x001AFA28
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

	// Token: 0x06001ECF RID: 7887 RVA: 0x001B1908 File Offset: 0x001AFB08
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

	// Token: 0x04003FDB RID: 16347
	public GameObject FemaleScream;

	// Token: 0x04003FDC RID: 16348
	public GameObject MaleScream;

	// Token: 0x04003FDD RID: 16349
	public bool Unfreeze;

	// Token: 0x04003FDE RID: 16350
	public float Speed = 0.1f;

	// Token: 0x04003FDF RID: 16351
	private float Timer;
}
