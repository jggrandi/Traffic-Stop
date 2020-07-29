using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sigtrap.VrTunnellingPro;


namespace NextgenUI.AlertsEvaluation 
{    
    [RequireComponent(typeof(Tunnelling))]
 
    public class ScreenFill : MonoBehaviour
    {
        private Tunnelling tunnelling;

        void Start()
        {
            VisualAlert.OnStartVisualAlert += ActivateScreenFill;
            VisualAlert.OnEndVisualAlert += ResetTunnel;
            tunnelling = gameObject.GetComponent<Tunnelling>();
        }

        private void OnDisable()
        {
            VisualAlert.OnStartVisualAlert -= ActivateScreenFill;
            VisualAlert.OnEndVisualAlert -= ResetTunnel;
        }

        void ActivateScreenFill(VisualAlert _alert)
        {
            tunnelling.effectColor = _alert.AlertParameters.color.color;
            tunnelling.effectCoverage = _alert.AlertParameters.screenCoverage;
            tunnelling.effectFeather = _alert.AlertParameters.effectFeather;
        }

        void ResetTunnel()
        {
            tunnelling.effectColor = Color.black;
            tunnelling.effectCoverage = 0f;
            tunnelling.effectFeather = 0f;
        }

    }
}
