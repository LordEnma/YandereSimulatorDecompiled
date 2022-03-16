using System;
using UnityEngine;

// Token: 0x020002A2 RID: 674
public class EmergencyExitScript : MonoBehaviour
{
	// Token: 0x0600141E RID: 5150 RVA: 0x000C026C File Offset: 0x000BE46C
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

	// Token: 0x0600141F RID: 5151 RVA: 0x000C038D File Offset: 0x000BE58D
	private void OnTriggerStay(Collider other)
	{
		this.Student = other.gameObject.GetComponent<StudentScript>();
		if (this.Student != null)
		{
			this.Timer = 1f;
			this.Open = true;
		}
	}

	// Token: 0x04001E47 RID: 7751
	public StudentScript Student;

	// Token: 0x04001E48 RID: 7752
	public Transform Yandere;

	// Token: 0x04001E49 RID: 7753
	public Transform Pivot;

	// Token: 0x04001E4A RID: 7754
	public float Timer;

	// Token: 0x04001E4B RID: 7755
	public bool Open;
}
