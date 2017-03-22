using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TriggerAnimation : MonoBehaviour
{
	public string AnimationName;
	public Animator stateMachine;

	public Teleporter teleporter;
	// Reference to the Teleporter script

	//	private bool created = false;

	void Awake ()
	{
//		if (GvrViewer.Instance == null) {
//			GvrViewer.Create ();
//			created = true;
//		}
	}

	void Start ()
	{
//		if (created) {
//			foreach (Camera c in GvrViewer.Instance.GetComponentsInChildren<Camera>()) {
//				c.enabled = false; // to use the Gvr SDK without adding cameras we have to disable them
//			}
//		}

	}

	void Update ()
	{

		GvrViewer.Instance.UpdateState (); //need to update the data here otherwise we dont get mouse clicks; this is because we are automatically creating the GVRSDK (seems like a bug)

		if (GvrViewer.Instance.Triggered) { // True if the Cardboard button is pressed .. However, we need to gurantee that it was pointing to the Globe.

			RaycastHit hit;  // Will be used to check where the viewer was pointing at.

			if (Physics.Raycast (transform.position, transform.forward, out hit)) { // Store information on the gameObject that was pointed at in "hit".
//				Debug.Log ("Collision Detected");
				if (hit.collider.gameObject.CompareTag ("Globe")) {  // If that gameObject has a tag equals to "Globe", then we should start rotation of the Globe.
//					Debug.Log ("We hit the Globe");
					teleporter.enabled = false;                      // First: Disable the Teleporter script to remain in front of the Globe and not quickly move to another waypoint.
//					Debug.Log ("Teleporter disabled");
					stateMachine.SetTrigger (AnimationName);         // Activate rotation  ... Will be stopped when the viewer presses the cardboard again when pointing to the Globe.
//					Debug.Log ("The Globe is rotating");
					teleporter.enabled = true;						 // Allow the viewer to move around when he/she desires. 
//					Debug.Log ("Teleporter enabled");

				}
			}
		}
	}
}