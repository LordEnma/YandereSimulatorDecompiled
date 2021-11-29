using System;
using UnityEngine;

// Token: 0x0200029E RID: 670
public class EmergencyExitScript : MonoBehaviour
{
	// Token: 0x06001403 RID: 5123 RVA: 0x000BE89C File Offset: 0x000BCA9C
	private void Update()
	{
		if (Vector3.Distance(this.Yandere.position, base.transform.position) < 2f)
		{
			this.Open = true;
		}
		else if (this.Timer == 0f)
		{
			this.Student = null;
			this.Open = false;
		}
		if (!this.Open)
		{
			this.Pivot.localEulerAngles = new Vector3(this.Pivot.localEulerAngles.x, Mathf.Lerp(this.Pivot.localEulerAngles.y, 0f, Time.deltaTime * 10f), this.Pivot.localEulerAngles.z);
			return;
		}
		this.Pivot.localEulerAngles = new Vector3(this.Pivot.localEulerAngles.x, Mathf.Lerp(this.Pivot.localEulerAngles.y, 90f, Time.deltaTime * 10f), this.Pivot.localEulerAngles.z);
		this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
	}

	// Token: 0x06001404 RID: 5124 RVA: 0x000BE9BD File Offset: 0x000BCBBD
	private void OnTriggerStay(Collider other)
	{
		this.Student = other.gameObject.GetComponent<StudentScript>();
		if (this.Student != null)
		{
			this.Timer = 1f;
			this.Open = true;
		}
	}

	// Token: 0x04001DF0 RID: 7664
	public StudentScript Student;

	// Token: 0x04001DF1 RID: 7665
	public Transform Yandere;

	// Token: 0x04001DF2 RID: 7666
	public Transform Pivot;

	// Token: 0x04001DF3 RID: 7667
	public float Timer;

	// Token: 0x04001DF4 RID: 7668
	public bool Open;
}
