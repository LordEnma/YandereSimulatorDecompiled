using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
	public Transform StartPos;

	public Transform EndPos;

	public Transform RightDoor;

	public Transform LeftDoor;

	public Transform Target;

	public bool OpenDoors;

	public bool Begin;

	public float Speed;

	public float Timer;

	private void Start()
	{
		base.transform.position = StartPos.position;
		base.transform.rotation = StartPos.rotation;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Begin = true;
		}
		if (!Begin)
		{
			return;
		}
		Timer += Time.deltaTime * Speed;
		if (Timer > 0.1f)
		{
			OpenDoors = true;
			if (LeftDoor != null)
			{
				LeftDoor.transform.localPosition = new Vector3(Mathf.Lerp(LeftDoor.transform.localPosition.x, 1f, Time.deltaTime), LeftDoor.transform.localPosition.y, LeftDoor.transform.localPosition.z);
				RightDoor.transform.localPosition = new Vector3(Mathf.Lerp(RightDoor.transform.localPosition.x, -1f, Time.deltaTime), RightDoor.transform.localPosition.y, RightDoor.transform.localPosition.z);
			}
		}
		base.transform.position = Vector3.Lerp(base.transform.position, EndPos.position, Time.deltaTime * Timer);
		base.transform.rotation = Quaternion.Lerp(base.transform.rotation, EndPos.rotation, Time.deltaTime * Timer);
	}

	private void LateUpdate()
	{
		if (Target != null)
		{
			base.transform.LookAt(Target);
		}
	}
}
