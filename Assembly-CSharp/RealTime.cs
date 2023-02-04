using UnityEngine;

public class RealTime : MonoBehaviour
{
	public static float time => Time.unscaledTime;

	public static float deltaTime => Time.unscaledDeltaTime;
}
