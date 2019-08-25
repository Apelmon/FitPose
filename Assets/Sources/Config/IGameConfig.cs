using System.Collections.Generic;
using Apelmon.CodeGeneration.Attributes;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Config]
[Unique]
[ComponentName("GameConfig")]
[Configuration]
public interface IGameConfig {
    float failedPopupAdsDelay { get; set; }
    
    float ShakeDuration { get; }
    float ShakeAmount { get; }
    float ShakeDecreaseFactor { get; }
}