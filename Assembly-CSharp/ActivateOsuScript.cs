using System;
using UnityEngine;

// Token: 0x0200038C RID: 908
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A4C RID: 6732 RVA: 0x00117C50 File Offset: 0x00115E50
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A4D RID: 6733 RVA: 0x00117C90 File Offset: 0x00115E90
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

	// Token: 0x06001A4E RID: 6734 RVA: 0x00117DC8 File Offset: 0x00115FC8
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A4F RID: 6735 RVA: 0x00117E38 File Offset: 0x00116038
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

	// Token: 0x04002B26 RID: 11046
	public StudentManagerScript StudentManager;

	// Token: 0x04002B27 RID: 11047
	public OsuScript[] OsuScripts;

	// Token: 0x04002B28 RID: 11048
	public StudentScript Student;

	// Token: 0x04002B29 RID: 11049
	public ClockScript Clock;

	// Token: 0x04002B2A RID: 11050
	public GameObject Music;

	// Token: 0x04002B2B RID: 11051
	public Transform Mouse;

	// Token: 0x04002B2C RID: 11052
	public GameObject Osu;

	// Token: 0x04002B2D RID: 11053
	public int PlayerID;

	// Token: 0x04002B2E RID: 11054
	public Vector3 OriginalMousePosition;

	// Token: 0x04002B2F RID: 11055
	public Vector3 OriginalMouseRotation;
}
