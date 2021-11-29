using System;
using UnityEngine;

// Token: 0x02000388 RID: 904
public class ActivateOsuScript : MonoBehaviour
{
	// Token: 0x06001A20 RID: 6688 RVA: 0x00114A68 File Offset: 0x00112C68
	private void Start()
	{
		this.OsuScripts = this.Osu.GetComponents<OsuScript>();
		this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
		this.OriginalMousePosition = this.Mouse.transform.position;
	}

	// Token: 0x06001A21 RID: 6689 RVA: 0x00114AA8 File Offset: 0x00112CA8
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

	// Token: 0x06001A22 RID: 6690 RVA: 0x00114BE0 File Offset: 0x00112DE0
	private void ActivateOsu()
	{
		this.Osu.transform.parent.gameObject.SetActive(true);
		this.Student.SmartPhone.SetActive(false);
		this.Music.SetActive(true);
		this.Mouse.parent = this.Student.RightHand;
		this.Mouse.transform.localPosition = Vector3.zero;
	}

	// Token: 0x06001A23 RID: 6691 RVA: 0x00114C50 File Offset: 0x00112E50
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

	// Token: 0x04002A90 RID: 10896
	public StudentManagerScript StudentManager;

	// Token: 0x04002A91 RID: 10897
	public OsuScript[] OsuScripts;

	// Token: 0x04002A92 RID: 10898
	public StudentScript Student;

	// Token: 0x04002A93 RID: 10899
	public ClockScript Clock;

	// Token: 0x04002A94 RID: 10900
	public GameObject Music;

	// Token: 0x04002A95 RID: 10901
	public Transform Mouse;

	// Token: 0x04002A96 RID: 10902
	public GameObject Osu;

	// Token: 0x04002A97 RID: 10903
	public int PlayerID;

	// Token: 0x04002A98 RID: 10904
	public Vector3 OriginalMousePosition;

	// Token: 0x04002A99 RID: 10905
	public Vector3 OriginalMouseRotation;
}
