using TMPro;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private PlayerInteract _playerInteract;
    [SerializeField] private TextMeshProUGUI _titleText;

    private void Update()
    {
        if (_playerInteract.GetInteractableObject() != null)
            Show();
        else
            Hide();
    }

    public void Show()
    {
        _titleText.text = _playerInteract.GetInteractableObject()?.GetHistoryLessonSO().title;
        _container.SetActive(true);
    }

    public void Hide()
    {
        _container.SetActive(false);
    }
}