using System;
using UnityEngine;

// Token: 0x0200038E RID: 910
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A58 RID: 6744 RVA: 0x00118414 File Offset: 0x00116614
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A59 RID: 6745 RVA: 0x00118454 File Offset: 0x00116654
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

	// Token: 0x06001A5A RID: 6746 RVA: 0x0011858C File Offset: 0x0011678C
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A5B RID: 6747 RVA: 0x001185FC File Offset: 0x001167FC
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

	// Token: 0x04002B3C RID: 11068
	public StudentManagerScript StudentManager;

	// Token: 0x04002B3D RID: 11069
	public OsuScript[] OsuScripts;

	// Token: 0x04002B3E RID: 11070
	public StudentScript Student;

	// Token: 0x04002B3F RID: 11071
	public ClockScript Clock;

	// Token: 0x04002B40 RID: 11072
	public GameObject Music;

	// Token: 0x04002B41 RID: 11073
	public Transform Mouse;

	// Token: 0x04002B42 RID: 11074
	public GameObject Osu;

	// Token: 0x04002B43 RID: 11075
	public int PlayerID;

	// Token: 0x04002B44 RID: 11076
	public Vector3 OriginalMousePosition;

	// Token: 0x04002B45 RID: 11077
	public Vector3 OriginalMouseRotation;
}
