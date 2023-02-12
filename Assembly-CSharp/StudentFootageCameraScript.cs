using UnityEngine;

public class StudentFootageCameraScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public int CurrentStudentID = 1;

	public float Timer;

	public bool Alt;

	private void Start()
	{
		StudentManager.Clock.StopTime = true;
		for (int i = 0; i < StudentManager.Students.Length; i++)
		{
			StudentScript studentScript = StudentManager.Students[i];
			if (!(studentScript != null))
			{
				continue;
			}
			studentScript.Prompt.Hide();
			studentScript.gameObject.SetActive(value: false);
			studentScript.transform.position = new Vector3(0f, 0f, -100f);
			studentScript.Indoors = true;
			studentScript.Spawned = true;
			studentScript.Paired = false;
			if (i < 90)
			{
				Debug.Log("ID is currently: " + i);
				if (studentScript.ShoeRemoval.Locker == null)
				{
					studentScript.ShoeRemoval.Start();
				}
				studentScript.ShoeRemoval.PutOnShoes();
			}
		}
		StudentManager.Yandere.CameraEffects.UpdateDOF(0.6f);
		StudentManager.Yandere.CameraEffects.UpdateAperture(10f);
		StudentManager.Yandere.MainCamera.gameObject.SetActive(value: false);
		StudentManager.Yandere.HUD.transform.parent.gameObject.SetActive(value: false);
		Physics.SyncTransforms();
	}

	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			Timer = 0f;
		}
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			Alt = !Alt;
		}
		Timer = Mathf.MoveTowards(Timer, 0f, Time.deltaTime);
		if (StudentManager.Students[CurrentStudentID] != null && StudentManager.Students[CurrentStudentID].Hurry)
		{
			StudentManager.Students[CurrentStudentID].CharacterAnimation.CrossFade(StudentManager.Students[CurrentStudentID].WalkAnim);
			StudentManager.Students[CurrentStudentID].Pathfinding.maxSpeed = 1f;
			StudentManager.Students[CurrentStudentID].Pathfinding.speed = 1f;
			StudentManager.Students[CurrentStudentID].Hurry = false;
		}
		if (Timer != 0f)
		{
			return;
		}
		base.transform.parent = null;
		if (StudentManager.Students[CurrentStudentID] != null)
		{
			StudentManager.Students[CurrentStudentID].gameObject.SetActive(value: false);
		}
		CurrentStudentID++;
		if (CurrentStudentID > 100)
		{
			CurrentStudentID = 0;
		}
		StudentScript studentScript = StudentManager.Students[CurrentStudentID];
		if (studentScript != null)
		{
			Timer = 30f;
			studentScript.gameObject.SetActive(value: true);
			studentScript.UpdateAnimLayers();
			studentScript.transform.position = new Vector3(0f, 0f, -100f);
			studentScript.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			studentScript.CharacterAnimation.CrossFade(studentScript.WalkAnim);
			studentScript.Pathfinding.canSearch = true;
			studentScript.DistanceToDestination = 100f;
			studentScript.Pathfinding.canMove = true;
			studentScript.Pathfinding.enabled = true;
			studentScript.Pathfinding.maxSpeed = 1f;
			studentScript.Pathfinding.speed = 1f;
			studentScript.ChangingShoes = false;
			studentScript.Routine = true;
			studentScript.Hurry = false;
			if (studentScript.FollowTarget == null)
			{
				studentScript.CurrentDestination = StudentManager.Fountain.transform;
				studentScript.Pathfinding.target = StudentManager.Fountain.transform;
			}
			else
			{
				studentScript.CurrentDestination = studentScript.FollowTarget.transform;
				studentScript.Pathfinding.target = studentScript.FollowTarget.transform;
			}
			Physics.SyncTransforms();
			base.transform.parent = studentScript.transform;
			if (!Alt)
			{
				base.transform.localPosition = new Vector3(-0.66666f, 1.2f, 0.66666f);
				base.transform.localEulerAngles = new Vector3(0f, 135f, 0f);
			}
			else
			{
				base.transform.localPosition = new Vector3(-0.3f, 1.266666f, 0.9f);
				base.transform.localEulerAngles = new Vector3(0f, 157.5f, 0f);
			}
		}
	}
}
