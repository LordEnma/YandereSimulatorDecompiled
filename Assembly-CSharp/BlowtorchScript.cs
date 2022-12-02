using UnityEngine;

public class BlowtorchScript : MonoBehaviour
{
	public YandereScript Yandere;

	public RagdollScript Corpse;

	public PickUpScript PickUp;

	public PromptScript Prompt;

	public Transform Flame;

	public float Timer;

	private void Start()
	{
		Flame.localScale = Vector3.zero;
		base.enabled = false;
	}

	private void Update()
	{
		Timer = Mathf.MoveTowards(Timer, 5f, Time.deltaTime);
		float num = Random.Range(0.9f, 1f);
		Flame.localScale = new Vector3(num, num, num);
		if (Timer == 5f && !Yandere.Chased && !Yandere.Sprayed)
		{
			Flame.localScale = Vector3.zero;
			Yandere.Cauterizing = false;
			Yandere.CanMove = true;
			base.enabled = false;
			GetComponent<AudioSource>().Stop();
			Timer = 0f;
		}
	}
}
