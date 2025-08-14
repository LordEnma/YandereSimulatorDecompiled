using UnityEngine;

public class SuicideCutsceneEndScript : MonoBehaviour
{
	public SuicideCutsceneScript SuicideCutscene;

	public Light Light;

	public float Timer;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 12.5f)
		{
			Debug.Log("Adjusting light intensity.");
			Light.color = Color.Lerp(Light.color, Color.white, Time.deltaTime);
		}
		if (Timer > 18f)
		{
			SuicideCutscene.Exit();
			base.enabled = false;
		}
	}
}
