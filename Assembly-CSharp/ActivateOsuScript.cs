using System;
using UnityEngine;

// Token: 0x0200038B RID: 907
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A38 RID: 6712 RVA: 0x00116354 File Offset: 0x00114554
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A39 RID: 6713 RVA: 0x00116394 File Offset: 0x00114594
	private void Update()
	{
		if (this.Student == null)
		{
			this.Student = this.StudentManager.Students[this.PlayerID];
			return;
		}
		if (!this.Osu.activeInHierarchy)
		{
			if (Vector3.Distance(base.transform.position, this.Student.transform.position) < 0.1f && this.Student.Routine && this.Student.CurrentDestination == this.Student.Destinations[this.Student.Phase] && this.Student.Actions[this.Student.Phase] == StudentActionType.Gaming)
			{
				this.ActivateOsu();
				return;
			}
		}
		else
		{
			this.Mouse.transform.eulerAngles = this.OriginalMouseRotation;
			if (!this.Student.Routine || this.Student.CurrentDestination != this.Student.Destinations[this.Student.Phase] || this.Student.Actions[this.Student.Phase] != StudentActionType.Gaming)
			{
				this.DeactivateOsu();
			}
		}
	}

	// Token: 0x06001A3A RID: 6714 RVA: 0x001164CC File Offset: 0x001146CC
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A3B RID: 6715 RVA: 0x0011653C File Offset: 0x0011473C
	private void DeactivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(false);
		this.Music.SetActive(false);
		OsuScript[] osuScripts = this.OsuScripts;
		for (int i = 0; i < osuScripts.Length; i++)
		{
			osuScripts[i].Timer = 0f;
		}
		this.Mouse.parent = base.transform.parent;
		this.Mouse.transform.position = this.OriginalMousePosition;
	}

	// Token: 0x04002AD7 RID: 10967
	public StudentManagerScript StudentManager;

	// Token: 0x04002AD8 RID: 10968
	public OsuScript[] OsuScripts;

	// Token: 0x04002AD9 RID: 10969
	public StudentScript Student;

	// Token: 0x04002ADA RID: 10970
	public ClockScript Clock;

	// Token: 0x04002ADB RID: 10971
	public GameObject Music;

	// Token: 0x04002ADC RID: 10972
	public Transform Mouse;

	// Token: 0x04002ADD RID: 10973
	public GameObject Osu;

	// Token: 0x04002ADE RID: 10974
	public int PlayerID;

	// Token: 0x04002ADF RID: 10975
	public Vector3 OriginalMousePosition;

	// Token: 0x04002AE0 RID: 10976
	public Vector3 OriginalMouseRotation;
}
