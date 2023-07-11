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
    private bool isTapped = false;
    void Start()
    {
        this.ballController = this.ball.GetComponent<BallController>();
        this.startingPosition = this.ball.transform.position;
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
        }
        
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
        }
        if(scoreLeft == 5){
            endGameText.text = "YOU WIN!";
            scoreTextLeft.text = this.scoreLeft.ToString();
            scoreTextRight.text = this.scoreRight.ToString();
        }
        if(scoreRight==5){
            endGameText.text = "COMPUTER WINS!";
            scoreTextLeft.text = this.scoreLeft.ToString();
            scoreTextRight.text = this.scoreRight.ToString();
        }
        
        scoreTextLeft.text = this.scoreLeft.ToString();
        scoreTextRight.text = this.scoreRight.ToString();

    }
    private void ResetBall(){
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.ballController.Go();

    }
    
}
