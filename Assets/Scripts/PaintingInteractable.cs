using Managers;

public class PaintingInteractable : BasePaintingInteractable
{
    private void Start()
    {
        // For enable and disable
    }

    public override void Interact()
    {
        if (_historyLesson == null) return;

        // You can skip on to the next one just after listening end. If you don't want it, put it in the comment line!
        //if (AudioManager.Instance.IsPlaying() || Subtitle.Instance.IsPlaying()) return;

        if(!isInteractedBefore) isInteractedBefore = true;

        float endTime = _historyLesson.clip ? _historyLesson.clip.length - 4 : 5f;

        Subtitle.Instance.StartDialogue(_historyLesson.description, endTime);
        if (_historyLesson.clip != null)
        {
            AudioManager.Instance.Play(_historyLesson.clip);
        }
        _additionalEvent?.Invoke();

        PaintingManager.Instance.Next(this);
    }
}