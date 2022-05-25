using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class YUT_KID : CoverageSkill{
	GameObject WarningMark;
	GameObject QuestionMark;
	float height = 3f;
	public float distance = 3f;
#region MonoBehaviour CallBacks
	private void Start() {
	}
	private void Update() {
		if(photonView.IsMine && PhotonNetwork.IsConnected){
			if(Input.GetKeyDown(KeyCode.Q)){
				Debug.LogWarning("Q pressed");
				photonView.RPC("SkillFire", RpcTarget.All);
			}
		}
	}
#endregion
#region Override Methods
	protected override void getPlayers(){
		targetList.Clear();
		//탐지 범위, 영역화
		RaycastHit[] hits = Physics.BoxCastAll(transform.position + transform.forward*(distance/2),new Vector3(distance, 1f,distance/2),transform.up,transform.rotation,1f);
		Debug.LogWarning(transform.position + transform.forward*(distance/2));
		foreach(RaycastHit x in hits){ //탐지된 객체 정리
			if(x.transform != transform){ //본인 제외
				if(!targetList.Contains(x.transform.GetComponent<PhotonView>())){ //중복 객체 검수
					if(x.transform.name.StartsWith("Dokkebi"))
						targetList.Add(x.transform.GetComponent<PhotonView>());
				}
			}
		}
		giveEffect(targetList.ToArray());
		return;
	}
	protected override void giveEffect(PhotonView[] targets)
	{
		if(targets == null || targets.Length == 0){
			if(QuestionMark == null){
				QuestionMark = PhotonNetwork.Instantiate("QuestionMark", transform.position + new Vector3(0,height,0),Quaternion.identity);
			}
			else{
				QuestionMark.transform.position = transform.position + new Vector3(0,height,0);
				QuestionMark.SetActive(true);
			}
		}
		else{
			foreach (var x in targets){
				if(WarningMark == null)
					WarningMark = PhotonNetwork.Instantiate("WarningMark", transform.position + new Vector3(0,height,0),Quaternion.identity);
				else{
					WarningMark.transform.position = transform.position + new Vector3(0,height,0);
					WarningMark.SetActive(true);
				}
			}
		}
	}
	[PunRPC]
	public override void SkillFire(){
		base.SkillFire();
		targetList.Clear();
		getPlayers();
	}
#endregion
}