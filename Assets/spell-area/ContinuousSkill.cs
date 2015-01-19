using UnityEngine;
using System.Collections;

public class ContinuousSkill : MonoBehaviour {

	public static ArrayList SkillList;
	public string SkillName;
	public float TimeDuration;
	public float SkillRadius;

	// Use this for initialization
	void Start () {
		if (SkillList == null) {
			SkillList = new ArrayList ();
		}

		SkillList.Add (this);

		StartCoroutine (CheckTimeOut ());
	}
	
	IEnumerator CheckTimeOut () {
		yield return new WaitForSeconds (TimeDuration);

		SkillList.Remove (this);
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () {
	
	}

	public static bool IsAffected(Vector3 p, float radius) {
		bool retV = false;
		foreach (ContinuousSkill sk in SkillList) {
			if (Vector3.Distance(sk.transform.position, p) - radius < sk.SkillRadius) {
				retV = true;
				break;
			}
		}
		return retV;
	}
}
