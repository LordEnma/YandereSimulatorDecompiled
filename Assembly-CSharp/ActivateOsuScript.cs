using System;
using UnityEngine;

// Token: 0x0200038A RID: 906
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A2E RID: 6702 RVA: 0x001158B0 File Offset: 0x00113AB0
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A2F RID: 6703 RVA: 0x001158F0 File Offset: 0x00113AF0
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

	// Token: 0x06001A30 RID: 6704 RVA: 0x00115A28 File Offset: 0x00113C28
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A31 RID: 6705 RVA: 0x00115A98 File Offset: 0x00113C98
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

	// Token: 0x04002AC4 RID: 10948
	public StudentManagerScript StudentManager;

	// Token: 0x04002AC5 RID: 10949
	public OsuScript[] OsuScripts;

	// Token: 0x04002AC6 RID: 10950
	public StudentScript Student;

	// Token: 0x04002AC7 RID: 10951
	public ClockScript Clock;

	// Token: 0x04002AC8 RID: 10952
	public GameObject Music;

	// Token: 0x04002AC9 RID: 10953
	public Transform Mouse;

	// Token: 0x04002ACA RID: 10954
	public GameObject Osu;

	// Token: 0x04002ACB RID: 10955
	public int PlayerID;

	// Token: 0x04002ACC RID: 10956
	public Vector3 OriginalMousePosition;

	// Token: 0x04002ACD RID: 10957
	public Vector3 OriginalMouseRotation;
}
