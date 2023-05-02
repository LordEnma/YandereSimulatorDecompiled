using UnityEngine;

public class DumpsterHandleScript : MonoBehaviour
{
	public DumpsterLidScript DumpsterLid;

	public PromptBarScript PromptBar;

	public PromptScript Prompt;

	public Transform GrabSpot;

	public GameObject Panel;

	public bool Grabbed;

	public float Direction;

	public float PullLimit;

	public float PushLimit;

	private void Start()
	{
		Panel.SetActive(value: false);
	}

	private void Update()
	{
		Prompt.HideButton[3] = Prompt.Yandere.PickUp != null || Prompt.Yandere.Dragging || Prompt.Yandere.Carrying;
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			Prompt.Circle[3].fillAmount = 1f;
			if (!Prompt.Yandere.Chased && Prompt.Yandere.Chasers == 0)
			{
				Prompt.Yandere.DumpsterGrabbing = true;
				Prompt.Yandere.DumpsterHandle = this;
				Prompt.Yandere.CanMove = false;
				PromptBar.ClearButtons();
				PromptBar.Label[1].text = "STOP";
				PromptBar.Label[5].text = "PUSH / PULL";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				Grabbed = true;
			}
		}
		if (!Grabbed)
		{
			return;
		}
		Prompt.Yandere.transform.rotation = Quaternion.Lerp(Prompt.Yandere.transform.rotation, GrabSpot.rotation, Time.deltaTime * 10f);
		if (Vector3.Distance(Prompt.Yandere.transform.position, GrabSpot.position) > 0.1f)
		{
			Prompt.Yandere.MoveTowardsTarget(GrabSpot.position);
		}
		else
		{
			Prompt.Yandere.transform.position = GrabSpot.position;
		}
		if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("DpadX") > 0.5f || Input.GetKey("right"))
		{
			base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, base.transform.parent.transform.position.z - Time.deltaTime);
		}
		else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") < -0.5f || Input.GetKey("left"))
		{
			base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, base.transform.parent.transform.position.z + Time.deltaTime);
		}
		if (PullLimit < PushLimit)
		{
			if (base.transform.parent.transform.position.z < PullLimit)
			{
				base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, PullLimit);
			}
			else if (base.transform.parent.transform.position.z > PushLimit)
			{
				base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, PushLimit);
			}
		}
		else if (base.transform.parent.transform.position.z > PullLimit)
		{
			base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, PullLimit);
		}
		else if (base.transform.parent.transform.position.z < PushLimit)
		{
			base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, PushLimit);
		}
		Panel.SetActive(DumpsterLid.transform.position.z > DumpsterLid.DisposalSpot - 0.05f && DumpsterLid.transform.position.z < DumpsterLid.DisposalSpot + 0.05f);
		if (Prompt.Yandere.Chased || Prompt.Yandere.Chasers > 0 || Input.GetButtonDown(InputNames.Xbox_B))
		{
			StopGrabbing();
		}
	}

	private void StopGrabbing()
	{
		Prompt.Yandere.DumpsterGrabbing = false;
		Prompt.Yandere.CanMove = true;
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		Panel.SetActive(value: false);
		Grabbed = false;
	}
}
