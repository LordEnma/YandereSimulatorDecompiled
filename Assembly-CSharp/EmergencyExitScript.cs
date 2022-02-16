using System;
using UnityEngine;

// Token: 0x020002A1 RID: 673
public class EmergencyExitScript : MonoBehaviour
{
	// Token: 0x06001412 RID: 5138 RVA: 0x000BF39C File Offset: 0x000BD59C
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

	// Token: 0x06001413 RID: 5139 RVA: 0x000BF4BD File Offset: 0x000BD6BD
	private void OnTriggerStay(Collider other)
	{
		this.Student = other.gameObject.GetComponent<StudentScript>();
		if (this.Student != null)
		{
			this.Timer = 1f;
			this.Open = true;
		}
	}

	// Token: 0x04001E20 RID: 7712
	public StudentScript Student;

	// Token: 0x04001E21 RID: 7713
	public Transform Yandere;

	// Token: 0x04001E22 RID: 7714
	public Transform Pivot;

	// Token: 0x04001E23 RID: 7715
	public float Timer;

	// Token: 0x04001E24 RID: 7716
	public bool Open;
}
