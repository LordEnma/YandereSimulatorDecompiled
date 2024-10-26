using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleSoundtest : MonoBehaviour
{
	private class ParticleDelta
	{
		public IList<ParticleSystem.Particle> Added { get; set; } = new List<ParticleSystem.Particle>();


		public IList<ParticleSystem.Particle> Removed { get; set; } = new List<ParticleSystem.Particle>();

	}

	private ParticleSystem _parentParticleSystem;

	private IDictionary<uint, ParticleSystem.Particle> _trackedParticles = new Dictionary<uint, ParticleSystem.Particle>();

	private void Start()
	{
		_parentParticleSystem = GetComponent<ParticleSystem>();
		if (_parentParticleSystem == null)
		{
			Debug.LogError("Missing ParticleSystem!", this);
		}
	}

	private void Update()
	{
		ParticleSystem.Particle[] array = new ParticleSystem.Particle[_parentParticleSystem.particleCount];
		_parentParticleSystem.GetParticles(array);
		ParticleDelta particleDelta = GetParticleDelta(array);
		foreach (ParticleSystem.Particle item in particleDelta.Added)
		{
			Debug.Log($"New particle spawned '{item.randomSeed}' at position '{item.position}'");
		}
		foreach (ParticleSystem.Particle item2 in particleDelta.Removed)
		{
			Debug.Log($"Particle despawned '{item2.randomSeed}' at position '{item2.position}'");
		}
	}

	private ParticleDelta GetParticleDelta(ParticleSystem.Particle[] liveParticles)
	{
		ParticleDelta particleDelta = new ParticleDelta();
		for (int i = 0; i < liveParticles.Length; i++)
		{
			ParticleSystem.Particle particle = liveParticles[i];
			if (_trackedParticles.TryGetValue(particle.randomSeed, out var _))
			{
				_trackedParticles[particle.randomSeed] = particle;
				continue;
			}
			particleDelta.Added.Add(particle);
			_trackedParticles.Add(particle.randomSeed, particle);
		}
		Dictionary<uint, ParticleSystem.Particle> dictionary = liveParticles.ToDictionary((ParticleSystem.Particle x) => x.randomSeed, (ParticleSystem.Particle x) => x);
		foreach (uint item in _trackedParticles.Keys.ToList())
		{
			if (!dictionary.ContainsKey(item))
			{
				particleDelta.Removed.Add(_trackedParticles[item]);
				_trackedParticles.Remove(item);
			}
		}
		return particleDelta;
	}
}
