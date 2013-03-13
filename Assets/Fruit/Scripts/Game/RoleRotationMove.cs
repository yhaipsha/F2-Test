using UnityEngine;
using System.Collections;

public class RoleRotationMove : MonoBehaviour
{
	private bool flagMove;
	private RaycastHit hit;
	private Vector3 mousePos;
	private Vector3 targetDir;

	// Use this for initialization
	void Start ()
	{
		flagMove = false;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {

			RayControl ();

		}

		if (flagMove) {

			if (Vector3.Distance (transform.position, mousePos) > 0.1) {

				transform.Translate (transform.worldToLocalMatrix * transform.right * Time.deltaTime * 0.5f);

			} else {

				flagMove = false;

			}

		}

	}

	void RayControl ()
	{

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);//从Camera发射射线到屏幕

		if (Physics.Raycast (ray, out hit)) {//射线碰撞检测

			mousePos = hit.point;

			mousePos.z = transform.position.z;

			targetDir = mousePos - transform.position;//计算到目标点的方向

			Vector3 tempDir = Vector3.Cross (transform.right, targetDir.normalized);

			float dotValue = Vector3.Dot (transform.right, targetDir.normalized);

			float angle = Mathf.Acos (dotValue) * Mathf.Rad2Deg;//计算夹角

			if (tempDir.z < 0) {//根据叉乘判断夹角的正负

				angle = angle * (-1);

			}

			if (!float.IsNaN (angle)) {

				transform.RotateAround (transform.position, Vector3.forward, angle);//转向目标点

			}

			flagMove = true;

		}

	}

}
