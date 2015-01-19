using UnityEngine;
using System.Collections;

public class SpellSkill : MonoBehaviour {

	public GameObject spell;
	public Texture2D spellTxt;
	public Transform blizzard;
	public Camera cam;
	public Vector3 lastPos;
	public bool boolKeyBDown;
	public ArrayList arraySkills;

	public static SpellSkill s_spellSkill;

	// Use this for initialization
	void Start () {
		if (s_spellSkill == null) {
			s_spellSkill = this;
		}

		arraySkills = new ArrayList ();
	}

	public 
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.B)) {
//			Screen.showCursor = false;
			boolKeyBDown = true;

			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hit)) {
				if (hit.collider.gameObject == this.gameObject) {
					
					spell.SetActive(true);
					spell.transform.position = new Vector3(hit.point.x, hit.point.y + 1.1f, hit.point.z);

//					Debug.Log(hit.textureCoord);
//					Vector2 pixelUV = hit.textureCoord;
//					pixelUV.x *= spellTxt.width;
//					pixelUV.y *= spellTxt.height;
//					spellTxt.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
//					spellTxt.Apply();
				}
			}
		}

		if (boolKeyBDown) {
			RaycastHit hit;
			Ray ray = cam.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray.origin, ray.direction, out hit)) {
				if (hit.collider.gameObject == this.gameObject) {
					
					spell.SetActive(true);
					
					lastPos = new Vector3(hit.point.x, hit.point.y + 1.1f, hit.point.z);
//					Debug.Log (lastPos);
					spell.transform.position = Vector3.Lerp (spell.transform.position, lastPos, Time.deltaTime * 10f);
				}
			}
			else {
				spell.SetActive(false);
			}

			if (Input.GetMouseButtonUp(0)) {
				boolKeyBDown = false;
				spell.SetActive(false);
				Screen.showCursor = true;
//				Debug.Log("Instantiate");
				Transform bl = Instantiate(blizzard, new Vector3(spell.transform.position.x, spell.transform.position.y + 30f, spell.transform.position.z), Quaternion.Euler(new Vector3(90f, 0, 0))) as Transform;
				bl.gameObject.SetActive(true);
			}

			if (Input.GetMouseButtonUp(1)) {
				boolKeyBDown = false;
				spell.SetActive(false);
				Screen.showCursor = true;
			}
		}
	}
}
