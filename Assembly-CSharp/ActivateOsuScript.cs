using System;
using UnityEngine;

// Token: 0x0200038C RID: 908
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A41 RID: 6721 RVA: 0x00116D68 File Offset: 0x00114F68
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A42 RID: 6722 RVA: 0x00116DA8 File Offset: 0x00114FA8
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

	// Token: 0x06001A43 RID: 6723 RVA: 0x00116EE0 File Offset: 0x001150E0
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A44 RID: 6724 RVA: 0x00116F50 File Offset: 0x00115150
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

	// Token: 0x04002AE7 RID: 10983
	public StudentManagerScript StudentManager;

	// Token: 0x04002AE8 RID: 10984
	public OsuScript[] OsuScripts;

	// Token: 0x04002AE9 RID: 10985
	public StudentScript Student;

	// Token: 0x04002AEA RID: 10986
	public ClockScript Clock;

	// Token: 0x04002AEB RID: 10987
	public GameObject Music;

	// Token: 0x04002AEC RID: 10988
	public Transform Mouse;

	// Token: 0x04002AED RID: 10989
	public GameObject Osu;

	// Token: 0x04002AEE RID: 10990
	public int PlayerID;

	// Token: 0x04002AEF RID: 10991
	public Vector3 OriginalMousePosition;

	// Token: 0x04002AF0 RID: 10992
	public Vector3 OriginalMouseRotation;
}
