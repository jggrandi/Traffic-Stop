using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class UIGuider : MonoBehaviour
{

    Player player;

    public static Action OnCheckingVehiclePhase;

    private static UIGuider _instance;
    public static UIGuider Instance { get { return _instance; } }

    public enum Phases { Intro, Goal, PlateScan, VehicleInfo, Greeting, AskReason, AskDriversLicense, DriverInfo, TakeAction, IssueWarning, IssueTicket, CallBackup};

    [SerializeField]
    int phase = 0;

    float minAngle = 3f;
    private int currentPhase = -1;

    private IEnumerator coroutine;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    void Start()
    {
        Teleport.instance.CancelTeleportHint();

        player = Player.instance;

        HideAllChildUI();

        DriverVoiceAnswers.OnAudioFinished += NextPhase;
        HandleInteractableArea.OnEnterInteractableArea += EnableUIDialog;
        HandleInteractableArea.OnExitInteractableArea += DisableUIDialog;
        PlateScanListener.OnReady += NextPhase;
        PlateScanListener.OnProcessing += HideTooltip;

        TriggerTakeAction.OnTakeActionEnter += TakeActionPhase;
        
    }
    [SerializeField]
    int savedPhase;
    private void TakeActionPhase()
    {
        savedPhase = phase;
        phase = (int)Phases.TakeAction;
    }

    public void BackToScenario()
    {
        phase = savedPhase;
        TriggerTakeAction.isTriggered = false;
    }

    public void IssueWarning()
    {
        phase = (int)Phases.IssueWarning;
        coroutine = Wait();
        StartCoroutine(coroutine);
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        phase = savedPhase;
        TriggerTakeAction.isTriggered = false;
    }
    public void IssueTicket()
    {
        
        phase = (int)Phases.IssueTicket;
        coroutine = Wait();
        StartCoroutine(coroutine);
    }

    public void CallBackup()
    {
        
        phase = (int)Phases.CallBackup;
        coroutine = Wait();
        StartCoroutine(coroutine);
    }


    private void HideTooltip(GameObject obj)
    {
        HideAllChildUI();
    }

    private void OnDestroy()
    {
        DriverVoiceAnswers.OnAudioFinished -= NextPhase;
        HandleInteractableArea.OnEnterInteractableArea -= EnableUIDialog;
        HandleInteractableArea.OnExitInteractableArea -= DisableUIDialog;
        PlateScanListener.OnReady -= NextPhase;
    }

    bool isUIDialogEnabled = false;

    private void EnableUIDialog()
    {
        isUIDialogEnabled = true;
    }

    private void DisableUIDialog()
    {
        isUIDialogEnabled = false;
    }

    private void HideAllChildUI()
    {
        for (int i = 0; i < this.transform.childCount; i++)
            HideUICanvas(i);
    }

    private void ShowUICanvas(int _id)
    {
        this.transform.GetChild(_id).gameObject.SetActive(true);
    }

    void HideUICanvas(int _id)
    {     
        this.transform.GetChild(_id).gameObject.SetActive(false);
    }

    Transform previousUITransform;

    private void FaceUITowardsPlayer()
    {
        this.transform.GetChild(phase).position = player.hmdTransform.position + player.hmdTransform.forward;
        this.transform.GetChild(phase).rotation = Quaternion.LookRotation(this.transform.GetChild(phase).position - player.hmdTransform.position);
         
        previousUITransform = this.transform.GetChild(phase);
    }

    private void FaceUIUsingLastTransform()
    {
        this.transform.GetChild(phase).position = previousUITransform.position;
        this.transform.GetChild(phase).rotation = previousUITransform.rotation;
    }


    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(phase);
        if (currentPhase == phase) return;
        HideAllChildUI();
        switch (phase)
        {
            case (int)Phases.Intro:
                {
                    if (Vector3.Angle(player.hmdTransform.position + player.hmdTransform.forward, player.hmdTransform.position + Vector3.forward) < 3f)
                    {
                        ShowUICanvas(phase);
                        FaceUITowardsPlayer();
                        currentPhase = phase;
                    }
                    break;
                }
            case (int)Phases.Goal:
                {
                    ShowUICanvas(phase);
                    FaceUIUsingLastTransform();
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.PlateScan:
                {
                    ShowUICanvas(phase);
                    currentPhase = phase;
                    OnCheckingVehiclePhase();
                    break;
                }
            case (int)Phases.VehicleInfo:
                {
                    ShowUICanvas(phase);
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.Greeting:
                {
                    if (!isUIDialogEnabled) return;
                    ShowUICanvas(phase);
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.AskReason:
                {
                    if (!isUIDialogEnabled) return;
                    ShowUICanvas(phase);
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.AskDriversLicense:
                {
                    if (!isUIDialogEnabled) return;
                    ShowUICanvas(phase);
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.TakeAction:
                {
                    ShowUICanvas(phase);
                    FaceUITowardsPlayer();
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.IssueWarning:
                {
                    ShowUICanvas(phase);
                    FaceUITowardsPlayer();
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.IssueTicket:
                {
                    ShowUICanvas(phase);
                    FaceUITowardsPlayer();
                    currentPhase = phase;
                    break;
                }
            case (int)Phases.CallBackup:
                {
                    ShowUICanvas(phase);
                    FaceUITowardsPlayer();
                    currentPhase = phase;
                    break;
                }
            default:
                break;
        }
    }

    public void HideButton()
    {
        HideAllChildUI();
    }

    public void NextPhase(GameObject _obj)
    {
        NextPhase();
    }

    public void NextPhase()
    {
        phase++;
        TriggerTakeAction.isTriggered = false;
    }





}
