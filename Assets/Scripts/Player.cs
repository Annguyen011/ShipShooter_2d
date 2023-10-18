using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Key")]
    [SerializeField] private KeyCode keyCodeAttack = KeyCode.Space;
    [SerializeField] private KeyCode keyCodeBoom = KeyCode.Z;

    [SerializeField] private string nextScene;
    [SerializeField] private StageData stageData;

    private bool isDie = false;

    private Animator animator;
    private Movement2D movement2D;
    private Weapon weapon;

    private int score;
    public int Score
    {
        set { score = value; }
        get { return Mathf.Max(0, score); }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movement2D = GetComponent<Movement2D>();
        weapon = GetComponent<Weapon>();
    }

    

    private void OnEnable()
    {
        isDie = false;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (isDie) return;
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, y));

        if (Input.GetKeyDown(keyCodeAttack))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack))
        {
            weapon.StopFiring();
        }
        if (Input.GetKeyDown(keyCodeBoom))
        {
            weapon.StartBoom();
        }
    }

    private void LateUpdate()
    {
        if (isDie) return;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

    public void OnDie()
    {
        isDie = true;
        PlayerPrefs.SetInt("Score", score);

        animator.SetTrigger("onDie");

        Invoke(nameof(ChangeScene), 1f);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
