using UnityEngine;

public class RobotArmScript : MonoBehaviour
{
	public SkinnedMeshRenderer RobotArms;

	public AudioSource MyAudio;

	public PromptScript Prompt;

	public Transform TerminalTarget;

	public ParticleSystem[] Sparks;

	public AudioClip ArmsOff;

	public AudioClip ArmsOn;

	public float StartWorkTimer;

	public float StopWorkTimer;

	public float[] ArmValue;

	public float[] Timer;

	public bool UpdateArms;

	public bool Work;

	public bool[] On;

	public int ID;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			ActivateArms();
		}
		if (Prompt.Circle[1].fillAmount == 0f)
		{
			ToggleWork();
		}
		if (UpdateArms)
		{
			if (On[0])
			{
				ArmValue[0] = Mathf.Lerp(ArmValue[0], 0f, Time.deltaTime * 5f);
				RobotArms.SetBlendShapeWeight(0, ArmValue[0]);
				if (ArmValue[0] < 0.1f)
				{
					RobotArms.SetBlendShapeWeight(0, 0f);
					UpdateArms = false;
					ArmValue[0] = 0f;
				}
			}
			else
			{
				ArmValue[0] = Mathf.Lerp(ArmValue[0], 100f, Time.deltaTime * 5f);
				RobotArms.SetBlendShapeWeight(0, ArmValue[0]);
				if (ArmValue[0] > 99.9f)
				{
					RobotArms.SetBlendShapeWeight(0, 100f);
					UpdateArms = false;
					ArmValue[0] = 100f;
				}
			}
		}
		if (Work)
		{
			if (StartWorkTimer > 0f)
			{
				for (ID = 1; ID < 9; ID += 2)
				{
					ArmValue[ID] = Mathf.Lerp(ArmValue[ID], 100f, Time.deltaTime * 5f);
					RobotArms.SetBlendShapeWeight(ID, ArmValue[ID]);
				}
				StartWorkTimer -= Time.deltaTime;
				if (StartWorkTimer < 0f)
				{
					for (ID = 1; ID < 9; ID += 2)
					{
						RobotArms.SetBlendShapeWeight(ID, 100f);
					}
				}
				return;
			}
			for (ID = 1; ID < 9; ID += 2)
			{
				Timer[ID] -= Time.deltaTime;
				if (Timer[ID] < 0f)
				{
					Sparks[ID].Stop();
					Sparks[ID + 1].Stop();
					if (Random.Range(0, 2) == 1)
					{
						On[ID] = true;
					}
					else
					{
						On[ID] = false;
					}
					Timer[ID] = Random.Range(1f, 2f);
				}
				if (On[ID])
				{
					ArmValue[ID] = Mathf.Lerp(ArmValue[ID], 0f, Time.deltaTime * 5f);
					ArmValue[ID + 1] = Mathf.Lerp(ArmValue[ID + 1], 100f, Time.deltaTime * 5f);
					RobotArms.SetBlendShapeWeight(ID, ArmValue[ID]);
					RobotArms.SetBlendShapeWeight(ID + 1, ArmValue[ID + 1]);
					if (ArmValue[ID] < 1f)
					{
						Sparks[ID].Play();
						RobotArms.SetBlendShapeWeight(ID, 0f);
						RobotArms.SetBlendShapeWeight(ID + 1, 100f);
						ArmValue[ID] = 0f;
						ArmValue[ID + 1] = 100f;
					}
				}
				else
				{
					ArmValue[ID] = Mathf.Lerp(ArmValue[ID], 100f, Time.deltaTime * 5f);
					ArmValue[ID + 1] = Mathf.Lerp(ArmValue[ID + 1], 0f, Time.deltaTime * 5f);
					RobotArms.SetBlendShapeWeight(ID, ArmValue[ID]);
					RobotArms.SetBlendShapeWeight(ID + 1, ArmValue[ID + 1]);
					if (ArmValue[ID] > 99f)
					{
						Sparks[ID + 1].Play();
						RobotArms.SetBlendShapeWeight(ID, 100f);
						RobotArms.SetBlendShapeWeight(ID + 1, 0f);
						ArmValue[ID] = 100f;
						ArmValue[ID + 1] = 0f;
					}
				}
			}
		}
		else
		{
			if (!(StopWorkTimer > 0f))
			{
				return;
			}
			for (ID = 1; ID < 9; ID++)
			{
				ArmValue[ID] = Mathf.Lerp(ArmValue[ID], 0f, Time.deltaTime * 5f);
				RobotArms.SetBlendShapeWeight(ID, ArmValue[ID]);
				Sparks[ID].Stop();
			}
			StopWorkTimer -= Time.deltaTime;
			if (StopWorkTimer < 0f)
			{
				for (ID = 1; ID < 9; ID++)
				{
					RobotArms.SetBlendShapeWeight(ID, 0f);
					On[ID] = false;
				}
			}
		}
	}

	public void ActivateArms()
	{
		Prompt.Circle[0].fillAmount = 1f;
		UpdateArms = true;
		On[0] = !On[0];
		if (On[0])
		{
			Prompt.HideButton[1] = false;
			MyAudio.clip = ArmsOn;
		}
		else
		{
			Prompt.HideButton[1] = true;
			MyAudio.clip = ArmsOff;
			StopWorkTimer = 5f;
			Work = false;
		}
		MyAudio.Play();
	}

	public void ToggleWork()
	{
		Prompt.Circle[1].fillAmount = 1f;
		StartWorkTimer = 1f;
		StopWorkTimer = 5f;
		Work = !Work;
	}
}
