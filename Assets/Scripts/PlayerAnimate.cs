using UnityEngine;
using System.Collections;

public class PlayerAnimate : MonoBehaviour {

	public string [] st = new string[] {"Stay", "WalkForward", "WalkBack", "Attack", "Jump"};

	public float jumpDuration;
	public string state;
	public Animator am;

	// Use this for initialization
	void Start () {

	}

	private int stateToIndex(AnimatorStateInfo s) {
		for (int i = 0; i < st.Length; i++) {
			if (s.IsName (st[i])) {
				return i;
			}
		}

		return 0;
	}
	
	// Update is called once per frame
	void Update () {
		AnimatorStateInfo s = am.GetCurrentAnimatorStateInfo (0);
		int hashIndex = stateToIndex (s);
		state = st [hashIndex];

		if (Input.GetButton("Jump")) {
			if (!s.IsName("Jump")) {
				am.Play ("Jump");
				StartCoroutine(BackToStay());
			}
		}
		else {
			if (Input.GetAxis ("Vertical") > 0) {
				if (!s.IsName("WalkForward")) am.Play ("WalkForward");
			}
			else if (Input.GetAxis ("Vertical") < 0) {
				if (!s.IsName("WalkBack")) am.Play ("WalkBack");
			}
		}
	}

	IEnumerator BackToStay () {

		yield return new WaitForSeconds (jumpDuration);

		if (Input.GetAxis ("Vertical") == 0) {
			AnimatorStateInfo s = am.GetCurrentAnimatorStateInfo (0);
			if (!s.IsName("Stay")) am.Play ("Stay");
		}

		yield break;
	}
}
