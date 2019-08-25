using Entitas;
using UnityEngine;

public interface IUIView : IView
{
    RectTransform rectTransform { get; }
    
    void Initialize(Contexts contexts, IEntity entity);
}