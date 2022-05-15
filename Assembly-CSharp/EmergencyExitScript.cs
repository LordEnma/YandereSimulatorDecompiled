using System;
using UnityEngine;

// Token: 0x020002A4 RID: 676
public class EmergencyExitScript : MonoBehaviour
{
	// Token: 0x0600142B RID: 5163 RVA: 0x000C0CFC File Offset: 0x000BEEFC
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

	// Token: 0x0600142C RID: 5164 RVA: 0x000C0E1D File Offset: 0x000BF01D
	private void OnTriggerStay(Collider other)
	{
		this.Student = other.gameObject.GetComponent<StudentScript>();
		if (this.Student != null)
		{
			this.Timer = 1f;
			this.Open = true;
		}
	}

	// Token: 0x04001E5D RID: 7773
	public StudentScript Student;

	// Token: 0x04001E5E RID: 7774
	public Transform Yandere;

	// Token: 0x04001E5F RID: 7775
	public Transform Pivot;

	// Token: 0x04001E60 RID: 7776
	public float Timer;

	// Token: 0x04001E61 RID: 7777
	public bool Open;
}
