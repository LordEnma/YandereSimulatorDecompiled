using UnityEngine;

public class DeathColliderScript : MonoBehaviour
{
	public GenericPromptScript GenericPrompt;

	public AudioSource MyAudio;

	public float Force;

	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null)
		{
			Debug.Log("Crushing a student.");
			if (component.ReturningMisplacedWeapon)
			{
				component.DropMisplacedWeapon();
			}
			component.DeathType = DeathType.Weight;
			component.BecomeRagdoll();
			component.Ragdoll.DisableRigidbodies();
			component.CharacterAnimation.enabled = true;
			component.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			if (!component.Male)
			{
				component.CharacterAnimation.Play("f02_crushed_00");
			}
			else
			{
				component.CharacterAnimation.Play("crushed_00");
			}
			component.transform.position = new Vector3(-28.78f, 100f, 10.25f);
			component.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			component.MapMarker.gameObject.SetActive(value: false);
			GenericPrompt.CrushedStudent = component;
			NemesisScript component2 = component.gameObject.GetComponent<NemesisScript>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			component.Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * component.Yandere.Numbness;
		}
		else if (other.gameObject.layer == 15 && other.gameObject.name == "Radio")
		{
			Debug.Log("Shutting off that god damn noisy radio.");
			other.gameObject.GetComponent<RadioScript>().TurnOff();
		}
	}
}
