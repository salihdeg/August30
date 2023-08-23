using UnityEngine;

public abstract class BasePaintingInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] protected HistoryLessonSO _historyLesson;
    [SerializeField] protected GameObject _visualSelected;
    public bool isInteractedBefore = false;
    [SerializeField] protected AdditionalEvent _additionalEvent;

    private void Start()
    {
        if(_additionalEvent != null)
            _historyLesson.additionalEvent = _additionalEvent;
    }

    public virtual void Interact()
    {

    }

    public Transform GetTransform()
    {
        return transform;
    }

    public HistoryLessonSO GetHistoryLessonSO()
    {
        return _historyLesson;
    }

    public bool IsEnable()
    {
        return enabled;
    }

    public void Highlight()
    {
        if (_visualSelected == null) return;

        _visualSelected.SetActive(true);
    }

    public void Obscure()
    {
        if (_visualSelected == null) return;

        _visualSelected.SetActive(false);
    }
}