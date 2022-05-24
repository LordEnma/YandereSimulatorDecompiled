using System;
using UnityEngine;

// Token: 0x0200038F RID: 911
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A67 RID: 6759 RVA: 0x001197DC File Offset: 0x001179DC
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A68 RID: 6760 RVA: 0x0011981C File Offset: 0x00117A1C
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

	// Token: 0x06001A69 RID: 6761 RVA: 0x00119954 File Offset: 0x00117B54
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A6A RID: 6762 RVA: 0x001199C4 File Offset: 0x00117BC4
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

	// Token: 0x04002B66 RID: 11110
	public StudentManagerScript StudentManager;

	// Token: 0x04002B67 RID: 11111
	public OsuScript[] OsuScripts;

	// Token: 0x04002B68 RID: 11112
	public StudentScript Student;

	// Token: 0x04002B69 RID: 11113
	public ClockScript Clock;

	// Token: 0x04002B6A RID: 11114
	public GameObject Music;

	// Token: 0x04002B6B RID: 11115
	public Transform Mouse;

	// Token: 0x04002B6C RID: 11116
	public GameObject Osu;

	// Token: 0x04002B6D RID: 11117
	public int PlayerID;

	// Token: 0x04002B6E RID: 11118
	public Vector3 OriginalMousePosition;

	// Token: 0x04002B6F RID: 11119
	public Vector3 OriginalMouseRotation;
}
