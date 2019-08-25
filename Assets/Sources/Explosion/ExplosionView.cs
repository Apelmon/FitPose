using Entitas;
using UnityEngine;

public class ExplosionView : UnityView {
    [SerializeField] private ParticleSystem _particle;
    
    public override void Initialize(Contexts contexts, IEntity entity) {
        base.Initialize(contexts, entity);

        _particle = GetComponent<ParticleSystem>();

        if (_particle == null) return;
        
        var particleMain = _particle.main;
//        particleMain.startColor = LinkedEntity.color.value;

        contexts.ExplosionTimer(LinkedEntity.id.value, particleMain.duration);
    }
}