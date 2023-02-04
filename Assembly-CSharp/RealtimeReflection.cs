using UnityEngine;

public class RealtimeReflection : MonoBehaviour
{
	private ReflectionProbe probe;

	private void Awake()
	{
		probe = GetComponent<ReflectionProbe>();
	}

	private void Update()
	{
		probe.transform.position = new Vector3(Camera.main.transform.position.x, 0f - Camera.main.transform.position.y, Camera.main.transform.position.z);
		probe.RenderProbe();
	}
}
