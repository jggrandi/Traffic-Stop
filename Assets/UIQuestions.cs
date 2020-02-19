using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
public class UIQuestions : MonoBehaviour
{

    Player player;
    CanvasGroup partentCanvasGroup;

    private static UIQuestions _instance;
    public static UIQuestions Instance { get { return _instance; } }

    [SerializeField]
    int phase = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = Player.instance;
        partentCanvasGroup = this.GetComponent<CanvasGroup>();
        partentCanvasGroup.alpha = 1f;
        partentCanvasGroup.interactable = true;
        //this.transform.position = player.hmdTransform.position + player.hmdTransform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        switch (phase)
        {
            case 0:
                if (Vector3.Angle(player.hmdTransform.position + player.hmdTransform.forward, player.hmdTransform.position + Vector3.forward) < 3f)
                {
                    ActivateCanvas(transform.GetChild(phase).GetComponent<CanvasGroup>());
                    phase++;
                }

                break;

            default:
                break;

        }

    }

    void ActivateCanvas(CanvasGroup _canvas)
    {
        LeanTween.alphaCanvas(_canvas, 1f, 1f).setEaseInSine();
        _canvas.interactable = true;
        this.transform.position = player.hmdTransform.position + player.hmdTransform.forward;
        this.transform.rotation = Quaternion.LookRotation(this.transform.position - player.hmdTransform.position);

    }

    void DeactivateCanvas()
    {
        LeanTween.alphaCanvas(partentCanvasGroup, 0f, 1f).setEaseOutBounce();
        partentCanvasGroup.interactable = false;

    }

}
