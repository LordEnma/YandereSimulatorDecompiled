using UnityEngine;

public class MechaScript : MonoBehaviour
{
	public CharacterController MyController;

	public GameObject StudentCrusher;

	public GameObject DestructiveShell;

	public GameObject MechaShell;

	public GameObject ShellType;

	public GameObject[] Sparks;

	public PromptScript Prompt;

	public Transform[] SpawnPoints;

	public Transform[] Wheels;

	public Camera MainCamera;

	public float Speed;

	public float Timer;

	public int ShotsFired;

	public bool Running;

	public bool Fire;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Yandere.CharacterAnimation.CrossFade("f02_riding_00");
			Prompt.Yandere.enabled = false;
			Prompt.Yandere.Riding = true;
			Prompt.Yandere.Egg = true;
			Prompt.Yandere.Jukebox.Egg = true;
			Prompt.Yandere.Jukebox.KillVolume();
			Prompt.Yandere.Jukebox.Ninja.enabled = true;
			Prompt.Yandere.transform.parent = base.transform;
			Prompt.Yandere.transform.localPosition = new Vector3(0f, 0f, 0f);
			Prompt.Yandere.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			Physics.SyncTransforms();
			Prompt.enabled = false;
			Prompt.Hide();
			MainCamera = Prompt.Yandere.MainCamera;
			base.transform.parent = null;
			StudentCrusher.SetActive(true);
			base.gameObject.layer = 9;
		}
		if (Prompt.Yandere.Riding)
		{
			if (Prompt.Yandere.transform.localPosition != Vector3.zero)
			{
				base.transform.position = Prompt.Yandere.transform.position;
				Prompt.Yandere.transform.localPosition = Vector3.zero;
				Physics.SyncTransforms();
			}
			UpdateMovement();
			if (Input.GetButtonDown("RB"))
			{
				Fire = true;
			}
			if (Input.GetButtonDown("X"))
			{
				if (ShellType == MechaShell)
				{
					ShellType = DestructiveShell;
					Sparks[1].SetActive(true);
					Sparks[2].SetActive(true);
					Sparks[3].SetActive(true);
					Sparks[4].SetActive(true);
				}
				else
				{
					ShellType = MechaShell;
					Sparks[1].SetActive(false);
					Sparks[2].SetActive(false);
					Sparks[3].SetActive(false);
					Sparks[4].SetActive(false);
				}
			}
			if (Fire)
			{
				Timer += Time.deltaTime;
				if (ShotsFired < 1)
				{
					if (Timer > 0f)
					{
						Object.Instantiate(ShellType, SpawnPoints[1].position, base.transform.rotation);
						ShotsFired++;
					}
				}
				else if (ShotsFired < 2)
				{
					if (Timer > 0.1f)
					{
						Object.Instantiate(ShellType, SpawnPoints[2].position, base.transform.rotation);
						ShotsFired++;
					}
				}
				else if (ShotsFired < 3)
				{
					if (Timer > 0.2f)
					{
						Object.Instantiate(ShellType, SpawnPoints[3].position, base.transform.rotation);
						ShotsFired++;
					}
				}
				else if (ShotsFired < 4 && Timer > 0.3f)
				{
					Object.Instantiate(ShellType, SpawnPoints[4].position, base.transform.rotation);
					ShotsFired = 0;
					Fire = false;
					Timer = 0f;
				}
			}
			if (Input.GetButtonDown("RS") || Input.GetButtonDown("LS"))
			{
				Prompt.Yandere.transform.parent = null;
				Prompt.Yandere.enabled = true;
				Prompt.Yandere.CanMove = true;
				Prompt.Yandere.Riding = false;
				Prompt.enabled = true;
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

	private void UpdateMovement()
	{
		if (!Prompt.Yandere.ToggleRun)
		{
			Running = false;
			if (Input.GetButton("LB"))
			{
				Running = true;
			}
		}
		else if (Input.GetButtonDown("LB"))
		{
			Running = !Running;
		}
		MyController.Move(Physics.gravity * Time.deltaTime);
		float axis = Input.GetAxis("Vertical");
		float axis2 = Input.GetAxis("Horizontal");
		Vector3 vector = MainCamera.transform.TransformDirection(Vector3.forward);
		vector.y = 0f;
		vector = vector.normalized;
		Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
		Vector3 vector3 = axis2 * vector2 + axis * vector;
		Quaternion b = Quaternion.identity;
		if (vector3 != Vector3.zero)
		{
			b = Quaternion.LookRotation(vector3);
		}
		if (vector3 != Vector3.zero)
		{
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime);
			Wheels[0].rotation = Quaternion.Lerp(Wheels[0].rotation, b, Time.deltaTime * 10f);
		}
		else
		{
			b = new Quaternion(0f, 0f, 0f, 0f);
		}
		if (axis != 0f || axis2 != 0f)
		{
			if (Running)
			{
				Speed = Mathf.MoveTowards(Speed, 20f, Time.deltaTime * 2f);
			}
			else
			{
				Speed = Mathf.MoveTowards(Speed, 1f, Time.deltaTime * 10f);
			}
		}
		else
		{
			Speed = Mathf.Lerp(Speed, 0f, Time.deltaTime);
		}
		MyController.Move(base.transform.forward * Speed * Time.deltaTime);
		for (int i = 0; i < 3; i++)
		{
			Wheels[i].Rotate(Speed * Time.deltaTime * 360f, 0f, 0f);
		}
	}
}
