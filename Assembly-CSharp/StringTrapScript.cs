using UnityEngine;

public class StringTrapScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public WaterCoolerScript WaterCooler;

	public GameObject BrownPaintPuddle;

	public GameObject GasolinePuddle;

	public GameObject BloodPuddle;

	public GameObject WaterPuddle;

	public GameObject BrownPaint;

	public GameObject Gasoline;

	public GameObject Blood;

	public GameObject Water;

	public GameObject Puddle;

	public Transform[] PuddleSpawn;

	public Transform Spawn;

	private void Update()
	{
		if (WaterCooler.Gasoline && StudentManager.Students[StudentManager.RivalID] != null && !StudentManager.Students[StudentManager.RivalID].GasWarned)
		{
			StudentScript follower = StudentManager.Students[StudentManager.RivalID].Follower;
			if (follower != null && follower.Alive && follower.CurrentAction == StudentActionType.Follow && Vector3.Distance(StudentManager.Students[StudentManager.RivalID].transform.position, follower.transform.position) < 10f && Vector3.Distance(base.transform.position, StudentManager.Students[StudentManager.RivalID].transform.position) < 10f)
			{
				WaterCooler.Prompt.Yandere.Subtitle.UpdateLabel(SubtitleType.GasWarning, 1, 5f);
				StudentManager.Students[StudentManager.RivalID].GasWarned = true;
			}
		}
		if (WaterCooler.TrapSet && WaterCooler.Prompt.Yandere.ShoulderCamera.GoingToCounselor)
		{
			WaterCooler.RemoveTrap();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer != 9)
		{
			return;
		}
		Debug.Log("A character just came into contact with a tripwire trap!");
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (!(component != null) || component.Yandere.InClass || !component.Pathfinding.canMove || component.ClubActivityPhase >= 16)
		{
			return;
		}
		if (component.Club == ClubType.Council || (component != null && component.Teacher) || component.WillRemoveTripwire || component.GasWarned || (component.Follower != null && Vector3.Distance(component.transform.position, component.Follower.transform.position) < 5f))
		{
			WaterCooler.Yandere.NotificationManager.CustomText = component.Name + " dismantled tripwire trap!";
			WaterCooler.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			if (component.Follower != null)
			{
				WaterCooler.Yandere.Subtitle.CustomText = "Osana, watch out for that string!";
				WaterCooler.Yandere.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
			}
			if (component.WillRemoveTripwire)
			{
				WaterCooler.Yandere.Subtitle.CustomText = "Let's get rid of this real quick...";
				WaterCooler.Yandere.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
				component.WillRemoveTripwire = false;
			}
			else
			{
				WaterCooler.Yandere.Subtitle.CustomText = "Someone tried to pull a prank? How childish...";
				WaterCooler.Yandere.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
			}
			base.transform.parent.gameObject.SetActive(value: false);
			WaterCooler.Prompt.HideButton[3] = false;
			WaterCooler.PickUp.enabled = true;
			WaterCooler.Prompt.enabled = true;
			WaterCooler.TrapSet = false;
			WaterCooler.Prompt.Label[1].text = "     Create Tripwire Trap";
			WaterCooler.Prompt.Label[1].applyGradient = false;
			WaterCooler.Prompt.Label[1].color = Color.red;
			return;
		}
		if (WaterCooler.BrownPaint)
		{
			Object.Instantiate(BrownPaint, Spawn.position, WaterCooler.transform.rotation);
			Puddle = BrownPaintPuddle;
		}
		else if (WaterCooler.Blood)
		{
			Object.Instantiate(Blood, Spawn.position, WaterCooler.transform.rotation);
			Puddle = BloodPuddle;
		}
		else if (WaterCooler.Gasoline)
		{
			Object.Instantiate(Gasoline, Spawn.position, WaterCooler.transform.rotation);
			Puddle = GasolinePuddle;
		}
		else
		{
			Object.Instantiate(Water, Spawn.position, WaterCooler.transform.rotation);
			Puddle = WaterPuddle;
		}
		GameObject gameObject = Object.Instantiate(Puddle, PuddleSpawn[1].position, Quaternion.identity);
		GameObject gameObject2 = Object.Instantiate(Puddle, PuddleSpawn[2].position, Quaternion.identity);
		GameObject gameObject3 = Object.Instantiate(Puddle, PuddleSpawn[3].position, Quaternion.identity);
		gameObject.transform.eulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
		gameObject2.transform.eulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
		gameObject3.transform.eulerAngles = new Vector3(90f, Random.Range(0f, 360f), 0f);
		if (WaterCooler.Blood)
		{
			gameObject.transform.parent = WaterCooler.Yandere.Police.BloodParent;
			gameObject2.transform.parent = WaterCooler.Yandere.Police.BloodParent;
			gameObject3.transform.parent = WaterCooler.Yandere.Police.BloodParent;
		}
		else
		{
			gameObject.transform.parent = WaterCooler.Yandere.StudentManager.PuddleParent.transform;
			gameObject2.transform.parent = WaterCooler.Yandere.StudentManager.PuddleParent.transform;
			gameObject3.transform.parent = WaterCooler.Yandere.StudentManager.PuddleParent.transform;
		}
		WaterCooler.Prompt.enabled = true;
		WaterCooler.BrownPaint = false;
		WaterCooler.Blood = false;
		WaterCooler.Gasoline = false;
		WaterCooler.Water = false;
		WaterCooler.TrapSet = false;
		WaterCooler.Empty = true;
		WaterCooler.Timer = 1f;
		WaterCooler.Prompt.Label[1].text = "     Create Tripwire Trap";
		WaterCooler.Prompt.Label[1].applyGradient = false;
		WaterCooler.Prompt.Label[1].color = Color.red;
		base.transform.parent.gameObject.SetActive(value: false);
		WaterCooler.Prompt.HideButton[3] = false;
		WaterCooler.PickUp.enabled = true;
		WaterCooler.MyRigidbody.isKinematic = false;
	}
}
