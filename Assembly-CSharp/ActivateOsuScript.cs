using System;
using UnityEngine;

// Token: 0x0200038A RID: 906
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A2E RID: 6702 RVA: 0x00115A18 File Offset: 0x00113C18
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A2F RID: 6703 RVA: 0x00115A58 File Offset: 0x00113C58
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

	// Token: 0x06001A30 RID: 6704 RVA: 0x00115B90 File Offset: 0x00113D90
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A31 RID: 6705 RVA: 0x00115C00 File Offset: 0x00113E00
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

	// Token: 0x04002AC7 RID: 10951
	public StudentManagerScript StudentManager;

	// Token: 0x04002AC8 RID: 10952
	public OsuScript[] OsuScripts;

	// Token: 0x04002AC9 RID: 10953
	public StudentScript Student;

	// Token: 0x04002ACA RID: 10954
	public ClockScript Clock;

	// Token: 0x04002ACB RID: 10955
	public GameObject Music;

	// Token: 0x04002ACC RID: 10956
	public Transform Mouse;

	// Token: 0x04002ACD RID: 10957
	public GameObject Osu;

	// Token: 0x04002ACE RID: 10958
	public int PlayerID;

	// Token: 0x04002ACF RID: 10959
	public Vector3 OriginalMousePosition;

	// Token: 0x04002AD0 RID: 10960
	public Vector3 OriginalMouseRotation;
}
