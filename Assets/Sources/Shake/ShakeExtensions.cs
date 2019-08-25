using UnityEngine;

public static class ShakeExtensions {
    public static void ShakeCamera(this Contexts contexts, float duration = 0.0f, float amount = 0.0f) {
        var camera = contexts.game.mainCameraEntity;
        duration = (duration == 0.0f) ? contexts.config.gameConfig.value.ShakeDuration : duration;
        amount = (amount == 0.0f) ? contexts.config.gameConfig.value.ShakeAmount : amount;
        
        camera.canShake = true;
        camera.ReplaceShakeOriginalPosition(camera.position.value);
        camera.ReplaceShakeDuration(duration);
        camera.ReplaceShakeAmount(amount);
    }
}