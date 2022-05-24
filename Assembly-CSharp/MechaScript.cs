using System;
using UnityEngine;

// Token: 0x02000366 RID: 870
public class MechaScript : MonoBehaviour
{
	// Token: 0x060019BD RID: 6589 RVA: 0x00107534 File Offset: 0x00105734
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_riding_00");
			this.Prompt.Yandere.enabled = false;
			this.Prompt.Yandere.Riding = true;
			this.Prompt.Yandere.Egg = true;
			this.Prompt.Yandere.Jukebox.Egg = true;
			this.Prompt.Yandere.Jukebox.KillVolume();
			this.Prompt.Yandere.Jukebox.Ninja.enabled = true;
			this.Prompt.Yandere.transform.parent = base.transform;
			this.Prompt.Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
			this.Prompt.Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Physics.SyncTransforms();
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			this.MainCamera = this.Prompt.Yandere.MainCamera;
			base.transform.parent = null;
			this.StudentCrusher.SetActive(true);
			base.gameObject.layer = 9;
		}
		if (this.Prompt.Yandere.Riding)
		{
			if (this.Prompt.Yandere.transform.localPosition != Vector3.zero)
			{
				base.transform.position = this.Prompt.Yandere.transform.position;
				this.Prompt.Yandere.transform.localPosition = Vector3.zero;
				Physics.SyncTransforms();
			}
			this.UpdateMovement();
			if (Input.GetButtonDown("RB"))
			{
				this.Fire = true;
			}
			if (Input.GetButtonDown("X"))
			{
				if (this.ShellType == this.MechaShell)
				{
					this.ShellType = this.DestructiveShell;
					this.Sparks[1].SetActive(true);
					this.Sparks[2].SetActive(true);
					this.Sparks[3].SetActive(true);
					this.Sparks[4].SetActive(true);
				}
				else
				{
					this.ShellType = this.MechaShell;
					this.Sparks[1].SetActive(false);
					this.Sparks[2].SetActive(false);
					this.Sparks[3].SetActive(false);
					this.Sparks[4].SetActive(false);
				}
			}
			if (this.Fire)
			{
				this.Timer += Time.deltaTime;
				if (this.ShotsFired < 1)
				{
					if (this.Timer > 0f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.ShellType, this.SpawnPoints[1].position, base.transform.rotation);
						this.ShotsFired++;
					}
				}
				else if (this.ShotsFired < 2)
				{
					if (this.Timer > 0.1f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.ShellType, this.SpawnPoints[2].position, base.transform.rotation);
						this.ShotsFired++;
					}
				}
				else if (this.ShotsFired < 3)
				{
					if (this.Timer > 0.2f)
					{
						UnityEngine.Object.Instantiate<GameObject>(this.ShellType, this.SpawnPoints[3].position, base.transform.rotation);
						this.ShotsFired++;
					}
				}
				else if (this.ShotsFired < 4 && this.Timer > 0.3f)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.ShellType, this.SpawnPoints[4].position, base.transform.rotation);
					this.ShotsFired = 0;
					this.Fire = false;
					this.Timer = 0f;
				}
			}
			if (Input.GetButtonDown("RS") || Input.GetButtonDown("LS"))
			{
				this.Prompt.Yandere.transform.parent = null;
				this.Prompt.Yandere.enabled = true;
				this.Prompt.Yandere.CanMove = true;
				this.Prompt.Yandere.Riding = false;
				this.Prompt.enabled = true;
				base.gameObject.layer = 17;
			}
		}
		if (base.transform.position.z < -100f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, -100f);
		}
		else if (base.transform.position.z > 140.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 140.5f);
		}
		if (base.transform.position.x > 71f)
		{
			base.transform.position = new Vector3(71f, base.transform.position.y, base.transform.position.z);
		}
		else if (base.transform.position.x < -71f)
		{
			base.transform.position = new Vector3(-71f, base.transform.position.y, base.transform.position.z);
		}
		if (base.transform.position.y < 0f)
		{
			base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
		}
	}

	// Token: 0x060019BE RID: 6590 RVA: 0x00107B48 File Offset: 0x00105D48
	private void UpdateMovement()
	{
		if (!this.Prompt.Yandere.ToggleRun)
		{
			this.Running = false;
			if (Input.GetButton("LB"))
			{
				this.Running = true;
			}
		}
		else if (Input.GetButtonDown("LB"))
		{
			this.Running = !this.Running;
		}
		this.MyController.Move(Physics.gravity * Time.deltaTime);
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		Vector3 vector = this.MainCamera.transform.TransformDirection(Vector3.forward);
		vector.y = 0f;
		vector = vector.normalized;
		Vector3 a = new Vector3(vector.z, 0f, -vector.x);
		Vector3 vector2 = axis2 * a + axis * vector;
		Quaternion b = Quaternion.identity;
		if (vector2 != Vector3.zero)
		{
			b = Quaternion.LookRotation(vector2);
		}
		if (vector2 != Vector3.zero)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime);
			this.Wheels[0].rotation = Quaternion.Lerp(this.Wheels[0].rotation, b, Time.deltaTime * 10f);
		}
		else
		{
			b = new Quaternion(0f, 0f, 0f, 0f);
		}
		if (axis != 0f || axis2 != 0f)
		{
			if (this.Running)
			{
				this.Speed = Mathf.MoveTowards(this.Speed, 20f, Time.deltaTime * 2f);
			}
			else
			{
				this.Speed = Mathf.MoveTowards(this.Speed, 1f, Time.deltaTime * 10f);
			}
		}
		else
		{
			this.Speed = Mathf.Lerp(this.Speed, 0f, Time.deltaTime);
		}
		this.MyController.Move(base.transform.forward * this.Speed * Time.deltaTime);
		for (int i = 0; i < 3; i++)
		{
			this.Wheels[i].Rotate(this.Speed * Time.deltaTime * 360f, 0f, 0f);
		}
	}

	// Token: 0x0400295F RID: 10591
	public CharacterController MyController;

	// Token: 0x04002960 RID: 10592
	public GameObject StudentCrusher;

	// Token: 0x04002961 RID: 10593
	public GameObject DestructiveShell;

	// Token: 0x04002962 RID: 10594
	public GameObject MechaShell;

	// Token: 0x04002963 RID: 10595
	public GameObject ShellType;

	// Token: 0x04002964 RID: 10596
	public GameObject[] Sparks;

	// Token: 0x04002965 RID: 10597
	public PromptScript Prompt;

	// Token: 0x04002966 RID: 10598
	public Transform[] SpawnPoints;

	// Token: 0x04002967 RID: 10599
	public Transform[] Wheels;

	// Token: 0x04002968 RID: 10600
	public Camera MainCamera;

	// Token: 0x04002969 RID: 10601
	public float Speed;

	// Token: 0x0400296A RID: 10602
	public float Timer;

	// Token: 0x0400296B RID: 10603
	public int ShotsFired;

	// Token: 0x0400296C RID: 10604
	public bool Running;

	// Token: 0x0400296D RID: 10605
	public bool Fire;
}
