using UnityEngine;

public class GradingPaperScript : MonoBehaviour
{
	public StudentScript Teacher;

	public GameObject Character;

	public Transform LeftHand;

	public Transform Chair;

	public Transform Paper;

	public float PickUpTime1;

	public float SetDownTime1;

	public float PickUpTime2;

	public float SetDownTime2;

	public Vector3 OriginalPosition;

	public Vector3 PickUpPosition1;

	public Vector3 SetDownPosition1;

	public Vector3 PickUpPosition2;

	public Vector3 PickUpRotation1;

	public Vector3 SetDownRotation1;

	public Vector3 PickUpRotation2;

	public int Phase = 1;

	public float Speed = 1f;

	public bool Writing;

	public int ID;

	private void Start()
	{
		OriginalPosition = Chair.position;
		Paper.localScale = new Vector3(0.9090909f, 0.9090909f, 0.9090909f);
		if (ID == 8 && GameGlobals.Eighties && DateGlobals.Week == 1)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!(Teacher != null) || !(Teacher.DistanceToPlayer < 10f) || !Writing || !(Character != null))
		{
			return;
		}
		if (Teacher.DistanceToDestination < 1f)
		{
			switch (Phase)
			{
			case 1:
				if (Teacher.CharacterAnimation["f02_deskWrite"].time > PickUpTime1)
				{
					Teacher.CharacterAnimation["f02_deskWrite"].speed = Speed;
					Paper.parent = LeftHand;
					Paper.localPosition = PickUpPosition1;
					Paper.localEulerAngles = PickUpRotation1;
					Paper.gameObject.SetActive(true);
					Phase++;
				}
				break;
			case 2:
				if (Teacher.CharacterAnimation["f02_deskWrite"].time > SetDownTime1)
				{
					Paper.parent = Character.transform;
					Paper.localPosition = SetDownPosition1;
					Paper.localEulerAngles = SetDownRotation1;
					Phase++;
				}
				break;
			case 3:
				if (Teacher.CharacterAnimation["f02_deskWrite"].time > PickUpTime2)
				{
					Paper.parent = LeftHand;
					Paper.localPosition = PickUpPosition2;
					Paper.localEulerAngles = PickUpRotation2;
					Phase++;
				}
				break;
			case 4:
				if (Teacher.CharacterAnimation["f02_deskWrite"].time > SetDownTime2)
				{
					Paper.parent = Character.transform;
					Paper.gameObject.SetActive(false);
					Phase++;
				}
				break;
			case 5:
				if (Teacher.CharacterAnimation["f02_deskWrite"].time >= Teacher.CharacterAnimation["f02_deskWrite"].length)
				{
					Teacher.CharacterAnimation["f02_deskWrite"].time = 0f;
					Teacher.CharacterAnimation.Play("f02_deskWrite");
					Phase = 1;
				}
				break;
			}
			if ((Phase != 1 && Teacher.Actions[Teacher.Phase] != StudentActionType.GradePapers) || !Teacher.Routine || Teacher.Stop)
			{
				RemoveProps();
			}
		}
		else
		{
			RemoveProps();
		}
	}

	public void RemoveProps()
	{
		if (Paper.gameObject.activeInHierarchy)
		{
			Paper.gameObject.SetActive(false);
			Teacher.Obstacle.enabled = false;
			Teacher.Pen.SetActive(false);
			Writing = false;
			Phase = 1;
		}
	}
}
