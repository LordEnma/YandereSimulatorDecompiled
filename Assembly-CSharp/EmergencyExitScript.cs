using System;
using UnityEngine;

// Token: 0x020002A3 RID: 675
public class EmergencyExitScript : MonoBehaviour
{
	// Token: 0x06001429 RID: 5161 RVA: 0x000C0A88 File Offset: 0x000BEC88
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

	// Token: 0x0600142A RID: 5162 RVA: 0x000C0BA9 File Offset: 0x000BEDA9
	private void OnTriggerStay(Collider other)
	{
		this.Student = other.gameObject.GetComponent<StudentScript>();
		if (this.Student != null)
		{
			this.Timer = 1f;
			this.Open = true;
		}
	}

	// Token: 0x04001E56 RID: 7766
	public StudentScript Student;

	// Token: 0x04001E57 RID: 7767
	public Transform Yandere;

	// Token: 0x04001E58 RID: 7768
	public Transform Pivot;

	// Token: 0x04001E59 RID: 7769
	public float Timer;

	// Token: 0x04001E5A RID: 7770
	public bool Open;
}
