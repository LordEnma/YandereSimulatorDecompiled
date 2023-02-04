using UnityEngine;

public class GrowShrinkScript : MonoBehaviour
{
	public float FallSpeed;

	public float Threshold = 1f;

	public float Slowdown = 0.5f;

	public float Strength = 1f;

	public float Target = 1f;

	public float Scale;

	public float Speed = 5f;

	public float Timer;

	public bool Shrink;

	public Vector3 OriginalPosition;

	private void Start()
	{
		OriginalPosition = base.transform.localPosition;
		base.transform.localScale = Vector3.zero;
	}

	private void Update()
	{
		Timer += Time.deltaTime * 2f;
		Scale += Time.deltaTime * (Strength * Speed) * 2f;
		if (!Shrink)
		{
			Strength += Time.deltaTime * Speed * 2f;
			if (Strength > Threshold)
			{
				Strength = Threshold;
			}
			if (Scale > Target)
			{
				Threshold *= Slowdown;
				Shrink = true;
			}
		}
		else
		{
			Strength -= Time.deltaTime * Speed * 2f;
			float num = Threshold * -1f;
			if (Strength < num)
			{
				Strength = num;
			}
			if (Scale < Target)
			{
				Threshold *= Slowdown;
				Shrink = false;
			}
		}
		if (Timer > 3.33333f)
		{
			FallSpeed += Time.deltaTime * 10f * 2f;
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y - FallSpeed * FallSpeed * 2f, base.transform.localPosition.z);
		}
		base.transform.localScale = new Vector3(Scale, Scale, Scale);
	}

	public void Return()
	{
		base.transform.localPosition = OriginalPosition;
		base.transform.localScale = Vector3.zero;
		FallSpeed = 0f;
		Threshold = 1f;
		Slowdown = 0.5f;
		Strength = 1f;
		Target = 1f;
		Scale = 0f;
		Speed = 5f;
		Timer = 0f;
		base.gameObject.SetActive(value: false);
	}
}
