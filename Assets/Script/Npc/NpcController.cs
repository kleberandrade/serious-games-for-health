using UnityEngine;

public class NpcController : MonoBehaviour {
	public string name;

	private void Awake() {

	}

	private void Start() {
		SetPrefab();
	}

	private void SetPrefab() {
		this.gameObject.name = name;

	}
}