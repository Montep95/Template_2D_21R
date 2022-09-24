using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement; // Retry Scene 구현을 위함

public class gameManager : MonoBehaviour
{
    // 변수 선언 **
    public GameObject star;
    public Text scoreText;
    public Text timeText;

    public GameObject panel;
    public GameObject Player;
    public GameObject g_field;

    float limit = 15.0f; // time Text

    Camera cam;

    public G_field gf;
    public Player player;
    public Trajectory trajectory;

    [SerializeField] float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint;
    Vector2 endPoint;
    Vector2 direction;
    Vector2 force;
    float distance;
    
    int totalScore = 0; // 점수 UI
    // 변수 선언 **


    #region Singleton class: gamaManager

    // 점수UI
    public static gameManager I;
    //public static gameManager Instance;

    void Awake()
    {
        // 점수 UI
        I = this;
        /*
        if (Instance == null)
        {
            Instance = this;
        }
        */
    }
    #endregion

    // retry 했을 경우 'Time'도 재실행
    void initGame()
    {
        Time.timeScale = 1.0f;
        limit = 15.0f;
        totalScore = 0;
    }
    void Start()
    {
        initGame(); // 시작할때마다 initGame 호출로 'time, score' 초기화로 시작
        cam = Camera.main;
        player.DesactivateRb();

        // 별 생성기
        InvokeRepeating("makeStar", 0.0f, 1.0f); // 0.5초마다 생성
        
        
    }

    void makeStar()
    {
        Instantiate(star);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            OnDragStart();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            OnDragEnd();
        }
        if (isDragging)
        {
            OnDrag();
        }

        // 시간 관련 코드
        limit -= Time.deltaTime; // 프레임마다 시간이 떨어짐
        if(limit < 0)
        {
            limit = 0.0f;
            panel.SetActive(true);
            Time.timeScale = 0.0f; // Unity 모든 시간 Stop
        }
        timeText.text = limit.ToString("N2");
    }

    void OnDragStart()
    {
        player.DesactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;
        

        Debug.DrawLine(startPoint, endPoint);


        trajectory.UpdateDots(player.pos, force);
    }

    void OnDragEnd()
    {
        player.ActivateRb();
        player.Push(force);

        trajectory.Hide();
    }


    // 점수 UI
    public void addScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    /*
    public void minusScore(int score)
    {
        totalScore -= score;
        scoreText.text = totalScore.ToString();
    }
    */

    // 다시하기 구현
    public void retry() 
    {
        SceneManager.LoadScene("myproject");
    }
}
