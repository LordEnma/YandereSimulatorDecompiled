using UnityEngine;

[ExecuteAlways]
public class NewArcScript : MonoBehaviour
{
	public YandereScript Yandere;

	[Header("References")]
	public ParticleSystem ArcParticles;

	[Header("Settings")]
	[Tooltip("Layers that the Arc can collide with")]
	public LayerMask CollisionLayers;

	[Space]
	[Tooltip("Equivalent of the Start Speed on Particle System")]
	public float ForwardMomentum = 10f;

	[Tooltip("Equivalent of the Gravity Modifier on Particle System")]
	public float GravityFactor = 1f;

	[Header("Debug")]
	public GameObject ProjectilePrefab;

	private Vector3 _position;

	private Vector3 _rotation;

	private Vector3 _scale;

	public Transform PositionTarget;

	public Transform RotationTarget;

	public InputDeviceScript InputDevice;

	public int Max;

	public int Min;

	public int Strength;

	public void Start()
	{
		Strength = ClassGlobals.PhysicalGrade;
	}

	private void Update()
	{
		if (!(ArcParticles != null))
		{
			return;
		}
		if (Yandere != null)
		{
			if (Yandere.Obvious)
			{
				Max = 20 + Yandere.Class.PhysicalGrade;
				Min = 10;
			}
			else
			{
				Max = 10 + Yandere.Class.PhysicalGrade;
				Min = 5;
			}
		}
		else
		{
			Max = 20 + Strength;
			Min = 10;
		}
		string axisName = "Mouse Y";
		if (InputDevice.Type == InputDeviceType.Gamepad)
		{
			axisName = InputNames.Xbox_JoyY;
		}
		if (InputDevice.Type == InputDeviceType.Gamepad)
		{
			if (Input.GetAxis(axisName) > 0f)
			{
				ForwardMomentum = Mathf.MoveTowards(ForwardMomentum, Max, Input.GetAxis(axisName) * Time.deltaTime * 10f);
			}
			else if (Input.GetAxis(axisName) < 0f)
			{
				ForwardMomentum = Mathf.MoveTowards(ForwardMomentum, Min, Input.GetAxis(axisName) * Time.deltaTime * -1f * 10f);
			}
		}
		else
		{
			ForwardMomentum += Input.GetAxis("Mouse ScrollWheel") * 10f;
		}
		ForwardMomentum = Mathf.Clamp(ForwardMomentum, Min, Max);
		if (_position != base.transform.position || _rotation != base.transform.eulerAngles || _scale != base.transform.localScale || (int)ArcParticles.collision.collidesWith != (int)CollisionLayers || ArcParticles.main.startSpeedMultiplier != ForwardMomentum || ArcParticles.main.gravityModifierMultiplier != GravityFactor)
		{
			UpdateParticles();
		}
	}

	[ContextMenu("Spawn Projectile")]
	public void SpawnProjectile()
	{
		if (ProjectilePrefab != null)
		{
			ArcProjectileScript component = Object.Instantiate(ProjectilePrefab, base.transform.position, base.transform.rotation).GetComponent<ArcProjectileScript>();
			if (component != null)
			{
				component.ForwardMomentum = ForwardMomentum;
				component.GravityFactor = GravityFactor;
				component.Init();
			}
			else
			{
				Debug.LogError("The assigned projectile Prefab does not have a component of type 'ArcProjectileScript'");
			}
		}
		else
		{
			Debug.LogError("There was no projectile prefab assigned");
		}
	}

	private void UpdateParticles()
	{
		ArcParticles.Stop();
		ParticleSystem.CollisionModule collision = ArcParticles.collision;
		collision.collidesWith = CollisionLayers;
		ParticleSystem.MainModule main = ArcParticles.main;
		main.startSpeedMultiplier = ForwardMomentum;
		main.gravityModifierMultiplier = GravityFactor;
		_position = base.transform.position;
		_rotation = base.transform.eulerAngles;
		_scale = base.transform.localScale;
		ArcParticles.Play();
	}

	public void LateUpdate()
	{
		base.transform.position = PositionTarget.position;
		base.transform.rotation = RotationTarget.rotation;
	}
}
