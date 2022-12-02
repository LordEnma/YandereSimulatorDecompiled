using UnityEngine;

public class BlasterScript : MonoBehaviour
{
	public Transform Skull;

	public Renderer Eyes;

	public Transform Beam;

	public float Size;

	private void Start()
	{
		Skull.localScale = Vector3.zero;
		Beam.localScale = Vector3.zero;
	}

	private void Update()
	{
		AnimationState animationState = GetComponent<Animation>()["Blast"];
		if (animationState.time > 1f)
		{
			Beam.localScale = Vector3.Lerp(Beam.localScale, new Vector3(15f, 1f, 1f), Time.deltaTime * 10f);
			Eyes.material.color = new Color(1f, 0f, 0f, 1f);
		}
		if (animationState.time >= animationState.length)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void LateUpdate()
	{
		AnimationState animationState = GetComponent<Animation>()["Blast"];
		Size = ((animationState.time < 1.5f) ? Mathf.Lerp(Size, 2f, Time.deltaTime * 5f) : Mathf.Lerp(Size, 0f, Time.deltaTime * 10f));
		Skull.localScale = new Vector3(Size, Size, Size);
	}
}
