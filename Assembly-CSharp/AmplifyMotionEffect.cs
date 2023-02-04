using UnityEngine;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Amplify Motion")]
public class AmplifyMotionEffect : AmplifyMotionEffectBase
{
	public new static AmplifyMotionEffect FirstInstance => (AmplifyMotionEffect)AmplifyMotionEffectBase.FirstInstance;

	public new static AmplifyMotionEffect Instance => (AmplifyMotionEffect)AmplifyMotionEffectBase.Instance;
}
