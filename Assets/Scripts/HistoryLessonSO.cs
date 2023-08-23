using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class AdditionalEvent : UnityEvent { }

[CreateAssetMenu()]
public class HistoryLessonSO : ScriptableObject
{
    public string title;
    public string description;
    public AudioClip clip;
    public AdditionalEvent additionalEvent;
}