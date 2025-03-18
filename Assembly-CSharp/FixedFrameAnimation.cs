using UnityEngine;

public class FixedFrameAnimation : MonoBehaviour
{
	public Animation animationComponent;

	public string animationName = "CameraAnimation";

	private float targetFrameRate = 60f;

	private float frameDuration;

	private float elapsedTime;

	public bool isPlaying = true;

	private float maxTime;

	private void Start()
	{
		if (animationComponent == null)
		{
			animationComponent = GetComponent<Animation>();
		}
		if (animationComponent == null || !animationComponent[animationName])
		{
			Debug.LogError("Animação não encontrada!");
			base.enabled = false;
			return;
		}
		frameDuration = 1f / targetFrameRate;
		maxTime = 4060f / targetFrameRate;
		animationComponent[animationName].speed = 0f;
		animationComponent.Play(animationName);
	}

	private void Update()
	{
		if (isPlaying)
		{
			elapsedTime += Time.deltaTime;
			if (elapsedTime >= maxTime)
			{
				elapsedTime = maxTime;
				isPlaying = false;
			}
			float time = Mathf.Floor(elapsedTime * targetFrameRate) / targetFrameRate;
			animationComponent[animationName].time = time;
			animationComponent.Sample();
		}
	}
}
