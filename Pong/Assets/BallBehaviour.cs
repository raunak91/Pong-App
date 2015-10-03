using UnityEngine;
using System.Collections;

public class BallBehaviour : MonoBehaviour {
    public Vector3 startingPosition;
    public float standardForce;
    public float upForce;

    private bool isStationaryFlag = true;
    private bool forceRightFlag = false;
    private bool forceLeftFlag = false;

    private Rigidbody rigidbody;

    void Awake() {
        this.rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }
    
	void Start () {
        this.transform.position = this.startingPosition;
	}

	void Update () {
        if (isStationaryFlag) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                this.rigidbody.useGravity = true;
                this.rigidbody.AddForce(new Vector3(0, 0, standardForce), ForceMode.Impulse);
                isStationaryFlag = false;
            }
        } else {
            if (forceRightFlag) {
                this.rigidbody.AddForce(new Vector3(0, upForce, 2 * standardForce), ForceMode.Impulse);
                this.forceRightFlag = false;
            }

            if (forceLeftFlag) {
                this.rigidbody.AddForce(new Vector3(0, upForce, -2 * standardForce), ForceMode.Impulse);
                this.forceLeftFlag = false;
            }

            if (Input.GetKeyDown(KeyCode.Z)) {
                this.forceRightFlag = true;
            }

            if (Input.GetKeyDown(KeyCode.Period)) {
                this.forceLeftFlag = true;
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                this.rigidbody.useGravity = false;
                this.rigidbody.velocity = Vector3.zero;
                this.rigidbody.angularVelocity = Vector3.zero;
                this.transform.position = this.startingPosition;

                this.isStationaryFlag = true;
            }
        }
	}
}
