using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PosolZone : MonoBehaviour
{
    [SerializeField] Image image;
    public GameObject target;
    [SerializeField] GameObject posol;
    [SerializeField] float posolSpeed;
    [SerializeField] float posolSpeedGoBack;

    [SerializeField] private Animator _posolAnimator;
    [SerializeField] private float _interactiveDistance = 0.5f;
    [SerializeField, Min(0.1f)] private float _posolBlinkTime = 0.15f;
    [SerializeField] private float _offset = 0.5f;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HeroController>(out var vorplayer))
        {
            PosolMessage();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HeroController>(out var vorplayer))
        {
            posol.transform.position = Vector2.MoveTowards(posol.transform.position, new Vector2(target.transform.position.x, target.transform.position.y - _offset), posolSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(posol.transform.position, target.transform.position) <= _interactiveDistance)
        {
            ShowTutorial();
            this.gameObject.SetActive(false);
            _posolAnimator.SetBool("Run", false);
        }
    }
    public void PosolMessage()
    {
        posol.SetActive(true);
        Vector2 pos = new Vector2(target.transform.position.x - 16f, target.transform.position.y);
        posol.transform.position = pos;

        target.GetComponent<Animator>().SetBool("Cutscene", true);
        target.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        HeroController player = target.GetComponent<HeroController>();
        player.DisableMovement();
        player.enabled = false;

        _posolAnimator.SetBool("Run", true);
        StartCoroutine(PosolBlink());
    }

    public void ShowTutorial()
    {
        image.gameObject.SetActive(true);
    }

    private IEnumerator PosolBlink()
    {
        SpriteRenderer spriteRenderer = posol.GetComponent<SpriteRenderer>();

        Color color = spriteRenderer.color;
        color.a = 0.5f;
        spriteRenderer.color = color;

        yield return new WaitForSeconds(_posolBlinkTime);
        color.a = 0.75f;
        spriteRenderer.color = color;

        yield return new WaitForSeconds(_posolBlinkTime);
        color.a = 1f;
        spriteRenderer.color = color;
    }
}
