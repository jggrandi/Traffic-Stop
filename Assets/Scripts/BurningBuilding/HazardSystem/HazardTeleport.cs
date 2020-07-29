using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Handles all the hazard teleport logic
//
//=============================================================================
namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class HazardTeleport : MonoBehaviour
	{
		public SteamVR_Action_Boolean teleportAction;

		public LayerMask traceLayerMask;
		public Material pointVisibleMaterial;
		public Transform destinationReticleTransform;
		public Color pointerValidColor;

		public float meshFadeTime = 0.2f;

		public float arcDistance = 10.0f;


        private LineRenderer pointerLineRenderer;
		private GameObject teleportPointerObject;
		private Transform pointerStartTransform;
		private Hand pointerHand = null;
		private Player player = null;
		private TeleportArc teleportArc = null;

		private bool visible = false;

		private Vector3 pointedAtPosition;

		private Coroutine hintCoroutine = null;


		//-------------------------------------------------
		private static HazardTeleport _instance;
		public static HazardTeleport instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = GameObject.FindObjectOfType<HazardTeleport>();
				}

				return _instance;
			}
		}


		//-------------------------------------------------
		void Awake()
		{
			_instance = this;

			pointerLineRenderer = GetComponentInChildren<LineRenderer>();
			teleportPointerObject = pointerLineRenderer.gameObject;

			teleportArc = GetComponent<TeleportArc>();
			teleportArc.traceLayerMask = traceLayerMask;
		}


		//-------------------------------------------------
		void Start()
		{
			HidePointer();

			player = Player.instance;

			if (player == null)
			{
				Debug.LogError("<b>[SteamVR Interaction]</b> Teleport: No Player instance found in map.", this);
				Destroy(this.gameObject);
				return;
			}

			Invoke("ShowTeleportHint", 5.0f);
		}




		//-------------------------------------------------
		public void HideTeleportPointer()
		{
			if (pointerHand != null)
			{
				HidePointer();
			}
		}


		//-------------------------------------------------
		void Update()
		{
			foreach (Hand hand in player.hands)
			{
				if (visible)
				{
					if (WasTeleportButtonReleased(hand))
					{
						if (pointerHand == hand) //This is the pointer hand
						{
							//TryTeleportPlayer();
							HideTeleportPointer();
						}
					}
				}

				if (WasTeleportButtonPressed(hand))
				{
					ShowPointer(hand);
				}
			}

            if (visible)
            {
                UpdatePointer();

            }
        }


		//-------------------------------------------------
		private void UpdatePointer()
		{
			Vector3 pointerStart = pointerStartTransform.position;
			Vector3 pointerEnd;
			Vector3 pointerDir = pointerStartTransform.forward;

			Vector3 arcVelocity = pointerDir * arcDistance;

			//Check pointer angle
			float dotUp = Vector3.Dot(pointerDir, Vector3.up);
			float dotForward = Vector3.Dot(pointerDir, player.hmdTransform.forward);
			bool pointerAtBadAngle = false;
			if ((dotForward > 0 && dotUp > 0.75f) || (dotForward < 0.0f && dotUp > 0.5f))
			{
				pointerAtBadAngle = true;
			}

			//Trace to see if the pointer hit anything
			RaycastHit hitInfo;
			teleportArc.SetArcData(pointerStart, arcVelocity, true, pointerAtBadAngle);
			if (teleportArc.DrawArc(out hitInfo))
			{
				teleportArc.SetColor(pointerValidColor);
				pointerLineRenderer.startColor = pointerValidColor;
				pointerLineRenderer.endColor = pointerValidColor;
				destinationReticleTransform.gameObject.SetActive(true);
				pointedAtPosition = hitInfo.point;
				pointerEnd = hitInfo.point;
				Vector3 normalToUse = hitInfo.normal;
				float angle = Vector3.Angle(hitInfo.normal, Vector3.up);
				if (angle < 15.0f)
				{
					normalToUse = Vector3.up;
				}
				destinationReticleTransform.rotation = Quaternion.Slerp(destinationReticleTransform.rotation, Quaternion.FromToRotation(Vector3.up, normalToUse), 0.1f);


				destinationReticleTransform.position = pointedAtPosition;

				pointerLineRenderer.SetPosition(0, pointerStart);
				pointerLineRenderer.SetPosition(1, pointerEnd);
			}
        }


		//-------------------------------------------------
		void FixedUpdate()
		{
			if (!visible)
			{
				return;
			}
		}

		//-------------------------------------------------
		private void HidePointer()
		{
			visible = false;

			teleportPointerObject.SetActive(false);

			teleportArc.Hide();

			destinationReticleTransform.gameObject.SetActive(false);

			pointerHand = null;
		}


		//-------------------------------------------------
		private void ShowPointer(Hand newPointerHand)
		{
			if (!visible)
			{
				visible = true;

				teleportPointerObject.SetActive(false);
				teleportArc.Show();

            }


			pointerHand = newPointerHand;

			if (pointerHand)
			{
				pointerStartTransform = GetPointerStartTransform(pointerHand);

			}
		}

		//-------------------------------------------------
		public void ShowTeleportHint()
		{
			CancelTeleportHint();
		}


		//-------------------------------------------------
		public void CancelTeleportHint()
		{
			if (hintCoroutine != null)
			{
				ControllerButtonHints.HideTextHint(player.leftHand, teleportAction);
				ControllerButtonHints.HideTextHint(player.rightHand, teleportAction);

				StopCoroutine(hintCoroutine);
				hintCoroutine = null;
			}

			CancelInvoke("ShowTeleportHint");
		}

		//-------------------------------------------------
		public bool IsEligibleForTeleport(Hand hand)
		{
			if (hand == null)
			{
				return false;
			}

			if (!hand.gameObject.activeInHierarchy)
			{
				return false;
			}

			if (hand.hoveringInteractable != null)
			{
				return false;
			}

			if (hand.noSteamVRFallbackCamera == null)
			{
				if (hand.isActive == false)
				{
					return false;
				}

			}

			return true;
		}


		//-------------------------------------------------
		private bool WasTeleportButtonReleased(Hand hand)
		{
			if (IsEligibleForTeleport(hand))
			{
				if (hand.noSteamVRFallbackCamera != null)
				{
					return Input.GetKeyUp(KeyCode.T);
				}
				else
				{
					return teleportAction.GetStateUp(hand.handType);
				}
			}

			return false;
		}


		//-------------------------------------------------
		private bool WasTeleportButtonPressed(Hand hand)
		{
			if (IsEligibleForTeleport(hand))
			{
				if (hand.noSteamVRFallbackCamera != null)
				{
					return Input.GetKeyDown(KeyCode.T);
				}
				else
				{
					return teleportAction.GetStateDown(hand.handType);

					//return hand.controller.GetPressDown( SteamVR_Controller.ButtonMask.Touchpad );
				}
			}

			return false;
		}


		//-------------------------------------------------
		private Transform GetPointerStartTransform(Hand hand)
		{
			if (hand.noSteamVRFallbackCamera != null)
			{
				return hand.noSteamVRFallbackCamera.transform;
			}
			else
			{
				return hand.transform;
			}
		}
	}
}
