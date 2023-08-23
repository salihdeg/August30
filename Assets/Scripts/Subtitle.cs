using System.Collections;
using TMPro;
using UnityEngine;

public class Subtitle : MonoBehaviour
{
    public static Subtitle Instance;

    [SerializeField] private GameObject _container;
    [SerializeField] private TextMeshProUGUI _subtitle;
    [SerializeField] private float _waitForNextSeconds;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;

    private int _index;
    private bool _isPlaying = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        //StartDialogue();
    }

    public bool IsPlaying()
    {
        return _isPlaying;
    }

    public void StartDialogue(string subtitle, float endTime)
    {
        StopAllCoroutines();
        //StopCoroutine(TypeLine(subtitle, endTime));
        _container.SetActive(true);
        _index = 0;
        _subtitle.text = string.Empty;
        _isPlaying = true;
        StartCoroutine(TypeLine(subtitle, endTime));
    }

    // Refactor Later!
    /*
    private void FillNow(string subtitle, float endTime)
    {
        StopCoroutine(TypeLine(subtitle, endTime));
        _container.SetActive(true);
        _index = 0;
        _subtitle.text = subtitle;
    }

    private void StartDialogue()
    {
        _container.SetActive(true);
        _index = 0;
        StartCoroutine(TypeLine());
    }
    */

    private IEnumerator TypeLine(string subtitle, float endTime)
    {
        foreach (char c in subtitle.ToCharArray())
        {
            _subtitle.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        StartCoroutine(WaitForClipEndAndClose(endTime));
    }

    private IEnumerator WaitForClipEndAndClose(float endTime)
    {
        yield return new WaitForSeconds(endTime);

        _subtitle.text = string.Empty;
        _container.SetActive(false);
        _isPlaying = false;
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in lines[_index].ToCharArray())
        {
            _subtitle.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(_waitForNextSeconds);
        NextLine();
    }

    private void NextLine()
    {
        if (_index < lines.Length - 1)
        {
            _index++;
            _subtitle.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            _container.SetActive(false);
        }
    }
}