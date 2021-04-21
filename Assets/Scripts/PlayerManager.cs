using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using FLFlight;
using FLFlight.UI;
public class PlayerManager : MonoBehaviour
{
	PhotonView PV;

	GameObject controller;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		if (PV.IsMine)
		{
			CreateController();
		}
	}

	void CreateController()
	{
        Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
        controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), spawnpoint.position, Quaternion.identity, 0, new object[] { PV.ViewID });
		GameObject.FindObjectOfType<CameraRig>().ship = controller.GetComponent<Transform>();
		GameObject.FindObjectOfType<BoresightCrosshair>().ship = controller.GetComponent<Transform>();

	}

	public void Die()
	{
		PhotonNetwork.Destroy(controller);
		CreateController();
	}
}