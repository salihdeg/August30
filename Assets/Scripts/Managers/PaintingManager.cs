using UnityEngine;

namespace Managers
{
    public class PaintingManager : MonoBehaviour
    {
        public static PaintingManager Instance { get; private set; }

        [SerializeField] private PaintingInteractable[] _paintingInteractables;

        private int _currentIndex = 0;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            DisableAllPaintings();

            _paintingInteractables[_currentIndex].enabled = true;
            _paintingInteractables[_currentIndex].Highlight();
        }

        public void DisableAllPaintings()
        {
            foreach (var item in _paintingInteractables)
            {
                item.enabled = false;
            }
        }

        public void Next(IInteractable interactable)
        {
            int index = -1;
            for (int i = 0; i < _paintingInteractables.Length; i++)
            {
                if (_paintingInteractables[i] == interactable)
                {
                    index = i;
                    break;
                }
            }

            if (index == _currentIndex)
            {
                _paintingInteractables[index].Obscure();
                if (_currentIndex + 1 < _paintingInteractables.Length)
                {
                    _currentIndex++;
                    _paintingInteractables[_currentIndex].enabled = true;
                    _paintingInteractables[_currentIndex].Highlight();
                }
                else
                {
                    if (_currentIndex + 1 >= _paintingInteractables.Length)
                    {
                        //GameEnd
                        AudioClip clip = _paintingInteractables[_currentIndex].GetHistoryLessonSO().clip;
                        float waitTime = clip ? clip.length - 4 : 3f;

                        GameManager.Instance.GameEnd(waitTime);
                    }
                }
            }
        }
    }
}