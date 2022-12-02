using UnityEngine;

public class HideColliderScript : MonoBehaviour
{
	public RagdollScript Corpse;

	public Collider MyCollider;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer != 11)
		{
			return;
		}
		GameObject gameObject = other.gameObject.transform.root.gameObject;
		if (!gameObject.GetComponent<StudentScript>().Alive)
		{
			Corpse = gameObject.GetComponent<RagdollScript>();
			if (!Corpse.Hidden && !Corpse.Concealed)
			{
				Corpse.HideCollider = MyCollider;
				Corpse.Police.HiddenCorpses++;
				Corpse.Hidden = true;
			}
		}
	}
}
