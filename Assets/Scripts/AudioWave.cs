using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioWave : MonoBehaviour {
    private float speed = 2f;
    private bool isStartMessageFinished = false;
    public Text messageText;
    // Use this for initialization
    public enum RecordingState
    {
        isStart,
        isRecording,
        isEndRecording,
        isAnalysing,
        isCompleted
    }
    public RecordingState state;
    void Start () {
       // messageText = GetComponent<Transform>().GetChild(2).gameObject.GetComponent<Text>();
        
        GetComponent<CanvasGroup>().alpha = 1;

    }
	
	// Update is called once per frame
	void Update () {
        //WaveMove();
	}
    //public IEnumerator CanvasFadeOut()
    //{
    //    while (GetComponent<CanvasGroup>().alpha < 1f)
    //    {
    //        GetComponent<CanvasGroup>().alpha += Time.deltaTime * speed;
    //        yield return true;
    //    }
    //}
    //public void FadeOut()
    //{
    //    StartCoroutine(CanvasFadeOut());
    //}
    public void WaveMove()
    {
        Image audioWave = GetComponent<Transform>().Find("Wave").gameObject.GetComponent<Image>();
        if (audioWave.fillAmount < 1)
        {
            audioWave.fillAmount += Time.deltaTime * 0.7f;
        }
        else
        {
            audioWave.fillAmount = 0;
        }
    }
    public void TextState(RecordingState recordingState,int count)
    {

        switch (recordingState)
        {
            case RecordingState.isStart:
                messageText.text = "开始录音";
                break;
            case RecordingState.isRecording:
                if (count > 100 && count < 180)
                {
                    messageText.text = "录音中    5";
                }
                else if (count > 180 && count < 260)
                {
                    messageText.text = "录音中    4";
                }
                else if (count > 260 && count < 340)
                {
                    messageText.text = "录音中    3";
                }
                else if (count > 340 && count < 420)
                {
                    messageText.text = "录音中    2";
                }
                else if (count > 420 && count < 500)
                {
                    messageText.text = "录音中    1";
                }
                break;
            case RecordingState.isEndRecording:
                messageText.text = "结束录音";
                break;

        }
    }
    public void UpdateText(int count)
    {
        if (count < 100)
        {
            state = RecordingState.isStart;
        }

        else if (count > 100 && count < 500)
        {
            state = RecordingState.isRecording;
        }
        else if (count > 500 & count < 600)
        {
            state = RecordingState.isEndRecording;
        }
        TextState(state,count);

    }
    //private IEnumerator StartMessageWait()
    //{
    //    messageText.text = "Start Recording";
    //    yield return new WaitForSeconds(1f);
    //    isStartMessageFinished = true;

    //}
    //private IEnumerator EndMessageControl()
    //{
    //    messageText.text = "End Recording";
    //    yield return new WaitForSeconds(1f);
    //    messageText.text = "Analyzing";
    //}
                        
       
}
