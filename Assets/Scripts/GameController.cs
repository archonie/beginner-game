using UnityEngine.Events;
using UnityEngine;
using TMPro;
using Lean.Touch;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    private int scoreLeft = 0;
    private int scoreRight = 0;
    public UnityEvent onTriggerEnter;
    private bool isStarted = false;
    public TMP_Text scoreTextLeft;
    public  TMP_Text scoreTextRight;
    public GameObject ball;
    private BallController ballController;
    private Vector3 startingPosition;
    public TMP_Text endGameText;
    public TMP_Text tap2Start;
    private bool isTapped = false;
    public GameObject sManager;
    private SpawnManager spawnManager;
    void Start()
    {
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPosition = this.ball.transform.position;
        this.spawnManager =  this.sManager.GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isStarted){
            return;
        }
        
        
    }
    public void StartGame(){  
        if(!isTapped){
            scoreLeft = 0;
            scoreRight = 0;
            UpdateUI();       
            this.isStarted = true;
            this.ballController.Go();
            InvokeRepeating("InvokeMethod", 2.5f, 5f);
            }
        
    }

    private void InvokeMethod(){
        this.spawnManager.Spawn();
    }
    public void StartGameOnTap(){
        StartGame();
        isTapped = true;        
    }
    public void ScoreGoalLeft(){
        this.scoreLeft +=1;
        UpdateUI();
        if(scoreLeft == 5){
            EndGame();
        }
        else{
            ResetBall();
        }
    }
    public void ScoreGoalRight(){
        this.scoreRight +=1;
        UpdateUI();
        if(scoreRight == 5){
            EndGame();
        }
        else{
            ResetBall();
        }
        
    }
    public void EndGame(){
        this.ballController.Stop();
        this.ball.transform.position = startingPosition;
        isStarted = false;
        isTapped = false;
    }
    private void UpdateUI(){
        if(scoreLeft <5 || scoreRight <5){
            this.endGameText.text = "";
            this.tap2Start.text = "";
            scoreTextLeft.text = this.scoreLeft.ToString();
            scoreTextRight.text = this.scoreRight.ToString();
        }
        if(scoreLeft == 5){
            endGameText.text = "YOU WIN!";
            tap2Start.text = "Tap to start again!";
            scoreTextLeft.text = "";
            scoreTextRight.text = "";
        }
        if(scoreRight==5){
            endGameText.text = "COMPUTER WINS!";
            tap2Start.text = "Tap to start again!";
            scoreTextLeft.text = "";
            scoreTextRight.text = "";
        }
        
        

    }
    private void ResetBall(){
        this.ballController.ResetBall();
        isTapped = true;
    }
    
}
