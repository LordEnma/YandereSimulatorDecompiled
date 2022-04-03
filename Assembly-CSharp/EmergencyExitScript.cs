using System;
using UnityEngine;

// Token: 0x020002A2 RID: 674
public class EmergencyExitScript : MonoBehaviour
{
	// Token: 0x0600141F RID: 5151 RVA: 0x000C0378 File Offset: 0x000BE578
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

	// Token: 0x06001420 RID: 5152 RVA: 0x000C0499 File Offset: 0x000BE699
	private void OnTriggerStay(Collider other)
	{
		this.Student = other.gameObject.GetComponent<StudentScript>();
		if (this.Student != null)
		{
			this.Timer = 1f;
			this.Open = true;
		}
	}

	// Token: 0x04001E4A RID: 7754
	public StudentScript Student;

	// Token: 0x04001E4B RID: 7755
	public Transform Yandere;

	// Token: 0x04001E4C RID: 7756
	public Transform Pivot;

	// Token: 0x04001E4D RID: 7757
	public float Timer;

	// Token: 0x04001E4E RID: 7758
	public bool Open;
}
