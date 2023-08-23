using UnityEngine;

public interface IInteractable
{
    public void Interact();
    public Transform GetTransform();
    public HistoryLessonSO GetHistoryLessonSO();
    public bool IsEnable();
    public void Highlight();
    public void Obscure();
}
