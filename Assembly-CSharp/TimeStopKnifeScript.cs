using System;
using UnityEngine;

// Token: 0x0200047A RID: 1146
public class TimeStopKnifeScript : MonoBehaviour
{
	// Token: 0x06001EE5 RID: 7909 RVA: 0x001B3C58 File Offset: 0x001B1E58
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x06001EE6 RID: 7910 RVA: 0x001B3C7C File Offset: 0x001B1E7C
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

	// Token: 0x06001EE7 RID: 7911 RVA: 0x001B3D5C File Offset: 0x001B1F5C
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

	// Token: 0x0400401B RID: 16411
	public GameObject FemaleScream;

	// Token: 0x0400401C RID: 16412
	public GameObject MaleScream;

	// Token: 0x0400401D RID: 16413
	public bool Unfreeze;

	// Token: 0x0400401E RID: 16414
	public float Speed = 0.1f;

	// Token: 0x0400401F RID: 16415
	private float Timer;
}
