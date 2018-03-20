using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeButtonController : MonoBehaviour
{

    //s public string NextSceneName;
    public Video_ctrl videoShut;
    Vector3 addPosition = new Vector3(0, -100f, 0);
    Vector3 addPositionUp = new Vector3(0, 300f, 0);
    Vector3 position;
    Vector3 audioWavePosition;
    bool initialization = true;
    private bool isChanging;
    private bool isRecordingCircleFinished;
    private bool isAudioWavePreCreat = false;
    private bool isRecordingFinished = false;
    private bool isRecordingCompleted = false;
    private bool isRecordingStart = false;
    private Image Home;
    private Image Next;
    private Image Record;
    public Transform HomeButton;
    private Transform homebutton;
    //public Image background;

    public float currentValueRecording = 0;
    public float currentValueFrontCar = 0;
    public float currentValueSideCar = 0;
    public float currentValueBehindCar = 0;
    public float currentValueBackFront = 0;
    public float speed = 50;
    private int recordingTimeCount = 0;
    private Transform audioWaveObj;
    public Transform audioWavePre;
    private AudioWave waveController;
    private AudioController audioController;

    public static bool FrontCar;
    public static bool SideCar;
    public static bool BehindCar;

    public static bool isrecording = true;



    public GameObject homebuttonfront;
    public GameObject homebuttonside;
    public GameObject homebuttonbehind;
    public GameObject homebuttonincar;
    void Start()
    {
        homebuttonfront.SetActive(true);
        homebuttonside.SetActive(false);
        homebuttonbehind.SetActive(false);
        homebuttonincar.SetActive(false);
        isrecording = true;
        isChanging = false;
        isRecordingCircleFinished = false;
        isAudioWavePreCreat = false;
        isRecordingFinished = false;
        isRecordingCompleted = false;
         isRecordingStart = false;
        GameObject.Find("Camera").transform.position = new Vector3(12.86f, 1.69f, 33.5f);
        Camera.main.gameObject.AddComponent<MyCameraControl>();
        //GameObject.Find("Camera").transform.position = new Vector3(9.5f, 1.85f, 41.2f);
        //Camera.main.gameObject.AddComponent<IncarCameraControl>();
        //audioController = GameObject.Find("Audio Source").GetComponent<AudioController>();
        FrontCar = true;
        //StartCoroutine (Audio_Capture.speech_analysis ());
        //StartCoroutine(CallSpeechApi.Call ("/Users/eliu209/Desktop/record.wav","record.wav"));
    }
    // Update is called once per frame
    void Update()
    {

        //GameObject.Find("Main Camera").transform.Rotate(Vector3.forward * 1f);
        RaycastHit rayHit;
        Ray ray = new Ray(Camera.main.gameObject.transform.position, Camera.main.transform.forward);

        //if ((Camera.main.transform.eulerAngles.x.CompareTo(40f) == 1) && (Camera.main.transform.eulerAngles.x.CompareTo(140f) == -1) && initialization)
        //{

        //    position = Camera.main.gameObject.transform.position + 0.9f * Camera.main.gameObject.transform.forward + new Vector3(0,-0.1f,0);
        //    homebutton = Instantiate(HomeButton, position, Quaternion.identity);

        //    homebutton.LookAt(Camera.main.transform.position, Vector3.up);
        //    homebutton.Rotate(0, 180f, 0);

        //    initialization = false;
        //    // currentValue = 0;
        //}
        //if ((Camera.main.transform.eulerAngles.x.CompareTo(40f) == -1) && (Camera.main.transform.eulerAngles.x.CompareTo(-220f) == 1))
        //{
        //    if (homebutton != null)
        //    {
        //        Destroy(homebutton.gameObject);
        //        initialization = true;
        //    }
        //}
        //backfront
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.transform.gameObject.name == "BackFrontLoading")
            {
                currentValueBackFront += speed * Time.deltaTime;
                GameObject next = GameObject.Find("BackFrontLoading");
                if (next != null)
                {
                    Next = next.GetComponent<Image>();
                    Next.fillAmount = currentValueBackFront / 10;
                    if (Next.fillAmount >= 1)
                    {
                        SceneManager.LoadScene("MasterRoom");
                    }
                }
            }
            

        }
        else
        {
            currentValueBackFront = 0;
            GameObject home = GameObject.Find("BackFrontLoading");
            if (home != null)
            {
                Home = home.GetComponent<Image>();
                Home.fillAmount = currentValueBackFront / 100;
            }
        }

        //frontcar
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.transform.gameObject.name == "FrontCarLoading")
            {
                currentValueFrontCar += speed * Time.deltaTime;
                GameObject home = GameObject.Find("FrontCarLoading");
                if (home != null)
                {
                    Home = home.GetComponent<Image>();
                    Home.fillAmount = currentValueFrontCar / 10;
                    if (Home.fillAmount >= 1)
                    {
                        FrontCar = true;
                        SideCar = false;
                        BehindCar = false;

                        homebuttonfront.SetActive(true);
                        homebuttonside.SetActive(false);
                        homebuttonbehind.SetActive(false);
                        homebuttonincar.SetActive(false);
                        videoShut.StopVideo();

                        GameObject.Find("Camera").transform.position = new Vector3(12.86f, 1.69f, 33.5f);
                        if (Camera.main.transform.GetComponent<SideCameraControl>())
                        {
                            Destroy(Camera.main.transform.GetComponent<SideCameraControl>());
                            Camera.main.gameObject.AddComponent<MyCameraControl>();
                        }
                        if (Camera.main.transform.GetComponent<BehindCameraControl>())
                        {
                            Destroy(Camera.main.transform.GetComponent<BehindCameraControl>());
                            Camera.main.gameObject.AddComponent<MyCameraControl>();
                        }
                        if (Camera.main.transform.GetComponent<IncarCameraControl>())
                        {
                            Destroy(Camera.main.transform.GetComponent<IncarCameraControl>());
                            Camera.main.gameObject.AddComponent<MyCameraControl>();
                        }
                        //if (Camera.main.transform.GetComponent<MyCameraControl>())
                        //{
                        //    Destroy(Camera.main.transform.GetComponent<MyCameraControl>());
                        //    Camera.main.gameObject.AddComponent<MyCameraControl>();
                        //}
                        isChanging = true;
                    }
                }
            }
            

        }

        else
        {
            currentValueFrontCar = 0;
            GameObject home = GameObject.Find("FrontCarLoading");
            if (home != null)
            {
                Home = home.GetComponent<Image>();
                Home.fillAmount = currentValueFrontCar / 100;
            }
        }
        //sidecar
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.transform.gameObject.name == "SideCarLoading")
            {
                currentValueSideCar += speed * Time.deltaTime;
                GameObject next = GameObject.Find("SideCarLoading");
                if (next != null)
                {
                    Next = next.GetComponent<Image>();
                    Next.fillAmount = currentValueSideCar / 10;
                    if (Next.fillAmount >= 1)
                    {
                        FrontCar = false;
                        SideCar = true;
                        BehindCar = false;

                        homebuttonfront.SetActive(false);
                        homebuttonside.SetActive(true);
                        homebuttonbehind.SetActive(false);
                        homebuttonincar.SetActive(false);
                        videoShut.StopVideo();

                        //background.color = new Color (0, 0, 0, 1);
                        GameObject.Find("Camera").transform.position = new Vector3(5.47f, 2.53f, 38.21f);
                        //Camera.main.transform.position = new Vector3(5.47f, 2.53f, 38.21f);
                        if (Camera.main.transform.GetComponent<MyCameraControl>())
                        {
                            Destroy(Camera.main.transform.GetComponent<MyCameraControl>());
                            Camera.main.gameObject.AddComponent<SideCameraControl>();
                        }
                        if (Camera.main.transform.GetComponent<BehindCameraControl>())
                        {
                            Destroy(Camera.main.transform.GetComponent<BehindCameraControl>());
                            Camera.main.gameObject.AddComponent<SideCameraControl>();
                        }
                        if (Camera.main.transform.GetComponent<IncarCameraControl>())
                        {
                            Destroy(Camera.main.transform.GetComponent<IncarCameraControl>());
                            Camera.main.gameObject.AddComponent<SideCameraControl>();
                        }
                        //if (Camera.main.transform.GetComponent<SideCameraControl>())
                        //{
                        //    Destroy(Camera.main.transform.GetComponent<SideCameraControl>());
                        //    Camera.main.gameObject.AddComponent<SideCameraControl>();
                        //}
                        isChanging = true;
                    }
                }
            }
            

        }
        else
        {
            currentValueSideCar = 0;
            GameObject home = GameObject.Find("SideCarLoading");
            if (home != null)
            {
                Home = home.GetComponent<Image>();
                Home.fillAmount = currentValueSideCar / 100;
            }
        }

        //behindcar
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.transform.gameObject.name == "BehindCarLoading")
            {
                currentValueBehindCar += speed * Time.deltaTime;
                GameObject next = GameObject.Find("BehindCarLoading");
                if (next != null)
                {
                    Next = next.GetComponent<Image>();
                    Next.fillAmount = currentValueBehindCar / 10;
                    if (Next.fillAmount >= 1)
                    {
                        FrontCar = false;
                        SideCar = false;
                        BehindCar = true;

                        homebuttonfront.SetActive(false);
                        homebuttonside.SetActive(false);
                        homebuttonbehind.SetActive(true);
                        homebuttonincar.SetActive(false);
                        videoShut.StopVideo();

                        //background.color = new Color (0, 0, 0, 1);
                        GameObject.Find("Camera").transform.position = new Vector3(5.16f, 2.59f, 46.14f);
                        if (Camera.main.transform.GetComponent<MyCameraControl>())
                        {
                            Destroy(Camera.main.transform.GetComponent<MyCameraControl>());
                            Camera.main.gameObject.AddComponent<BehindCameraControl>();
                        }
                        if (Camera.main.transform.GetComponent<SideCameraControl>())
                        {
                            Destroy(Camera.main.transform.GetComponent<SideCameraControl>());
                            Camera.main.gameObject.AddComponent<BehindCameraControl>();
                        }
                        if (Camera.main.transform.GetComponent<IncarCameraControl>())
                        {
                            Destroy(Camera.main.transform.GetComponent<IncarCameraControl>());
                            Camera.main.gameObject.AddComponent<BehindCameraControl>();
                        }
                        isChanging = true;
                    }
                }
            }

            
        }
        else
        {

            currentValueBehindCar = 0;
            GameObject Behind = GameObject.Find("BehindCarLoading");
            if (Behind != null)
            {
                Next = Behind.GetComponent<Image>();
                Next.fillAmount = currentValueBehindCar / 10;
            }
        }


        //Recording
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.transform.gameObject.name == "RecordingLoading")
            {
                currentValueRecording += speed * Time.deltaTime;
                GameObject record = GameObject.Find("RecordingLoading");
                if (record != null)
                {
                    Record = record.GetComponent<Image>();
                    Record.fillAmount = currentValueRecording / 10;
                    if (Record.fillAmount >= 1)
                    {
                        if (isrecording)
                        { 
                            isrecording = false;
                            isRecordingCircleFinished = true;
                            isRecordingStart = true;
                        }
                    }
                }
            }
            
        }
        else
        {
            currentValueRecording = 0;
            GameObject record = GameObject.Find("RecordingLoading");
            if (record != null)
            {
                Record = record.GetComponent<Image>();
                Record.fillAmount = currentValueRecording / 10;
            }

        }
        
        RecordingRun();
        
        //if (recordingTimeCount == 800)
        //{
        //    RecordingEnd();
        //}

        if (CallSpeechApi.iscomplete)
        {
            Debug.Log("iscomplete");
            RecordingEnd();
            CallSpeechApi.iscomplete = false;
            isrecording = true;
        }

    }
    void RecordingRun()
    {
        Debug.Log("isRecordingStart="+isRecordingStart);
        if (isRecordingStart)
        {
            //Debug.Log("recording start and the isRecordingCircleFinishedis "+isRecordingCircleFinished+"isAudioWavecreate"+isAudioWavePreCreat);
            if (isRecordingCircleFinished && !isAudioWavePreCreat)
            {

                audioWavePosition = Camera.main.gameObject.transform.position + 0.9f * Camera.main.gameObject.transform.forward+new Vector3(0, 0.1f,0);
                audioWaveObj = Instantiate(audioWavePre, audioWavePosition, Quaternion.identity);
                //audioWaveObj.LookAt(Camera.main.transform);
                //audioWaveObj.Rotate(0, 180f, 0);
                waveController = audioWaveObj.gameObject.GetComponent<AudioWave>();
                //waveController.FadeOut();
                isAudioWavePreCreat = true;

            }
            if (isRecordingCircleFinished)
            {
                recordingTimeCount++;
                audioWavePosition = Camera.main.gameObject.transform.position + 0.9f * Camera.main.gameObject.transform.forward+ new Vector3(0, 0.1f, 0);
                audioWaveObj.position = audioWavePosition;
                audioWaveObj.LookAt(Camera.main.transform);
                audioWaveObj.Rotate(0, 180f, 0);
                if (waveController != null)
                {
                    waveController.WaveMove();
                    waveController.UpdateText(recordingTimeCount);
                }
                //if (isRecordingCompleted)
                //{
                //    if (waveController != null)
                //    {
                //        Destroy()
                //    }
                //}
            }
        }
    }
    void RecordingEnd()
    {
        isRecordingCircleFinished = false;
        recordingTimeCount = 0;
        if (audioWaveObj != null)
        {
            Destroy(audioWaveObj.gameObject);
            isAudioWavePreCreat = false;
            isRecordingStart = false;
        }
    }
}