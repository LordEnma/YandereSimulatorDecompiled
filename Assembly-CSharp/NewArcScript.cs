using UnityEngine;

[ExecuteAlways]
public class NewArcScript : MonoBehaviour
{
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

	private void Update()
	{
		if (ArcParticles != null)
		{
			if (Input.GetAxis("Mouse Y") > 0f)
			{
				GravityFactor = Mathf.MoveTowards(GravityFactor, 0.1f, Input.GetAxis("Mouse Y") * Time.deltaTime);
			}
			else if (Input.GetAxis("Mouse Y") < 0f)
			{
				GravityFactor = Mathf.MoveTowards(GravityFactor, 2f, Input.GetAxis("Mouse Y") * Time.deltaTime * -1f);
			}
			if (_position != base.transform.position || _rotation != base.transform.eulerAngles || _scale != base.transform.localScale || (int)ArcParticles.collision.collidesWith != (int)CollisionLayers || ArcParticles.main.startSpeedMultiplier != ForwardMomentum || ArcParticles.main.gravityModifierMultiplier != GravityFactor)
			{
				UpdateParticles();
			}
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
