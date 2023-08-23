using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Image _flag;
        public static GameManager Instance { get; private set; }

        private const string IZMIR_MARCH = "IzmirMarch";
        private const string ISTIKLAL_MARCH = "Istiklal";

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private IEnumerator Wait(float waitTime = 2)
        {
            yield return new WaitForSeconds(waitTime + 1);
            // Ýstiklal marþý ve yavaþça beliren Türk Bayraðýmýz

            PaintingManager.Instance.DisableAllPaintings();

            AudioManager.Instance.Play(ISTIKLAL_MARCH);

            float time = AudioManager.Instance.GetClipTime(ISTIKLAL_MARCH);
            _flag.DOFade(1f, time / 3);

            yield return new WaitForSeconds(time + 1f);
            SceneManager.LoadScene(0);
        }

        public void GameEnd(float waitTime)
        {
            StartCoroutine(Wait(waitTime));
        }

        public void StartIzmirMarch()
        {
            AudioManager.Instance.Play(IZMIR_MARCH);
        }

        public void StopIzmirMarch()
        {
            AudioManager.Instance.Stop(IZMIR_MARCH);
        }
    }
}