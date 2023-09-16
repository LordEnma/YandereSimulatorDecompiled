using UnityEngine;

public class FallCheckerScript : MonoBehaviour
{
	public DumpsterLidScript Dumpster;

	public RagdollScript Ragdoll;

	public Collider MyCollider;

	private void OnTriggerEnter(Collider other)
	{
		if (Ragdoll == null && other.gameObject.layer == 11)
		{
			Ragdoll = other.transform.root.gameObject.GetComponent<RagdollScript>();
			Ragdoll.Prompt.Hide();
			Ragdoll.Prompt.enabled = false;
			Ragdoll.Prompt.MyCollider.enabled = false;
			Ragdoll.BloodPoolSpawner.enabled = false;
			Ragdoll.HideCollider = MyCollider;
			if (!Ragdoll.Concealed)
			{
				Ragdoll.Police.HiddenCorpses++;
			}
			Ragdoll.Hidden = true;
			Dumpster.Corpse = Ragdoll.gameObject;
			Dumpster.Victim = Ragdoll.Student;
		}
	}

	private void Update()
	{
		if (Ragdoll != null)
		{
			if (Ragdoll.Prompt.transform.localPosition.y > -10.5f)
			{
				Ragdoll.Prompt.transform.localEulerAngles = new Vector3(-90f, 90f, 0f);
				Ragdoll.AllColliders[2].transform.localEulerAngles = Vector3.zero;
				Ragdoll.AllColliders[7].transform.localEulerAngles = new Vector3(0f, 0f, -80f);
				Ragdoll.Prompt.transform.position = new Vector3(Dumpster.transform.position.x, Ragdoll.Prompt.transform.position.y, Dumpster.transform.position.z);
			}
			else
			{
				Debug.Log("A student who was shoved from the school rooftop just landed in a dumpster.");
				GameObject obj = Object.Instantiate(Ragdoll.Student.AlarmDisc, Dumpster.SlideLocation.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
				obj.transform.localScale = new Vector3(1000f, 1f, 1000f);
				obj.GetComponent<AlarmDiscScript>().FarTargetDistance = true;
				GetComponent<AudioSource>().Play();
				Dumpster.Slide = true;
				Ragdoll = null;
			}
		}
	}
}
