using System;
using UnityEngine;

// Token: 0x020002A0 RID: 672
public class EmergencyExitScript : MonoBehaviour
{
	// Token: 0x0600140E RID: 5134 RVA: 0x000BF444 File Offset: 0x000BD644
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

	// Token: 0x0600140F RID: 5135 RVA: 0x000BF565 File Offset: 0x000BD765
	private void OnTriggerStay(Collider other)
	{
		this.Student = other.gameObject.GetComponent<StudentScript>();
		if (this.Student != null)
		{
			this.Timer = 1f;
			this.Open = true;
		}
	}

	// Token: 0x04001E1D RID: 7709
	public StudentScript Student;

	// Token: 0x04001E1E RID: 7710
	public Transform Yandere;

	// Token: 0x04001E1F RID: 7711
	public Transform Pivot;

	// Token: 0x04001E20 RID: 7712
	public float Timer;

	// Token: 0x04001E21 RID: 7713
	public bool Open;
}
