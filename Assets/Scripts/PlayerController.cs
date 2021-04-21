using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public PhotonView PV;
	public Rigidbody rb;


	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		if (!PV.IsMine)
		{
            /*Destroy(GetComponentInChildren<Camera>().gameObject);*/
            /*Destroy(rb);*/
        }		
	}
}