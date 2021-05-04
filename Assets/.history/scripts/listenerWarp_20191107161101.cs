using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.listener;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.message;
using com.shephertz.app42.gaming.multiplayer.client.transformer;
public class listenerWarp :  MonoBehaviour, ConnectionRequestListener , RoomRequestListener , LobbyRequestListener,ZoneRequestListener, NotifyListener, ChatRequestListener
{   	
	private Collision m_apppwarp;
    int state = 0;
    string debug = "";
    bool conexionLograda = false;
    bool joinRoomOk = false; 
    string roomJoined = "";
    bool receivePeer = false;
	string tiempoEntradaRoom;
    string mensajeChat = "";
	string nameSender = "";
	/**
		static const Byte SUCCESS = 0;    
		static const Byte AUTH_ERROR = 1;    
		static const Byte RESOURCE_NOT_FOUND = 2;    
		static const Byte RESOURCE_MOVED = 3;     
		static const Byte BAD_REQUEST = 4;
		static const Byte CONNECTION_ERR = 5;
		static const Byte UNKNOWN_ERROR = 6;
	 */
    //long roomsCreados;
    List<string> roomsCreados = new List<string>();
    public int getState(){
        return state;
    }
    public bool getConexionEstado(){
        return conexionLograda;
    }
    public List<string> getRoomsCreados(){
        return roomsCreados;
    }
    public string getRoomJoined(){
        return roomJoined;
    }
    public bool getReceivePeer(){
        return receivePeer;
    }
    public string getMensajeChat(){
        return mensajeChat;
    }
	public string getNameSender(){
		return nameSender;
	}
	public string getTiempoEntradaRoom(){
		return tiempoEntradaRoom;
	}
    public void onConnectDone(ConnectEvent eventObj)  
    {  
        if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)  
        {  
            Debug.Log("connection success yeah "+eventObj.getResult());  
			conexionLograda = true;
			if( m_apppwarp == null ){
				//m_apppwarp = GameObject.FindWithTag("cuboScriptPrin").GetComponent<CameraScript3>();
			}
        }  
        else  
        {  
            Debug.Log("connection fail "+eventObj.getResult());  
        }  
    }  
    public void onDisconnectDone(ConnectEvent eventObj)  
    {  
        // handle Disconnect here  
    }  
  
    public void onInitUDPDone (byte resultCode)  
    {  
        // handle onInitUDPDone here  
    }  
    public void onUpdatePeersReceived (UpdateEvent eventObj)
		{
			Log ("onUpdatePeersReceived");
			m_apppwarp.onBytes(eventObj.getUpdate());
			Log("isUDP " + eventObj.getIsUdp());
            receivePeer = true;
		}
    public void sendBytes(byte[] msg, bool useUDP)
    {
        Debug.Log ("**** send bytes 1 state "+state);
        if(state == 1)
        {	
            if(useUDP == true){
                Debug.Log ("**** send bytes udp "+state);
                Log ("**** log send bytes udp "+state);
                WarpClient.GetInstance().SendUDPUpdatePeers(msg);
            }
            else
                WarpClient.GetInstance().SendUpdatePeers(msg);
        }
    }
    public void onJoinRoomDone (RoomEvent eventObj)
    {
        if(eventObj.getResult() == 0)
        {
            state = 1;
			Log ("onJoinRoomDone : " + eventObj.getResult()+" id "+eventObj.getData().getId()+" name "+eventObj.getData().getName());
			joinRoomOk = true;
    	    roomJoined = eventObj.getData().getId();
			tiempoEntradaRoom = System.DateTime.UtcNow.Ticks.ToString();
        }
    }
    public void onDeleteRoomDone (RoomEvent eventObj)
		{
			Log ("onDeleteRoomDone : " + eventObj.getResult());
		}
		
        public void onGetAllRoomsDone (AllRoomsEvent eventObj)
		{
			Log ("onGetAllRoomsDone : " + eventObj.getResult());
            if ( eventObj.getRoomIds() == null) {
                    Log (" length rooms  null ");
            }
            else {
                for(int i=0; i< eventObj.getRoomIds().Length; ++i)
                {
                    Log ("Room ID : " + eventObj.getRoomIds()[i]);
                    string idRoom = eventObj.getRoomIds()[i];
                    if( !roomsCreados.Contains(idRoom)){
                          roomsCreados.Add( idRoom );
                    }
                }
            }
		}
        	
		public void onCreateRoomDone (RoomEvent eventObj)
		{
			Log ("onCreateRoomDone : " + eventObj.getResult());
		}
        public void onGetMatchedRoomsDone(MatchedRoomsEvent eventObj)
		{
			if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
            {
                Log ("GetMatchedRooms event received with success status");
                foreach (var roomData in eventObj.getRoomsData())
                {
                    Log("Room ID:" + roomData.getId());
                }
            }
		}
    //RoomRequestListener
		//#region RoomRequestListener
		public void onSubscribeRoomDone (RoomEvent eventObj)
		{
			if(eventObj.getResult() == 0)
			{
				/*string json = "{\"start\":\""+id+"\"}";
				WarpClient.GetInstance().SendChat(json);
				state = 1;*/
				//// como estoy usando join in range, ya estoy unido
				///WarpClient.GetInstance().JoinRoom(m_apppwarp.getRoomID());
			}
			
			Log ("onSubscribeRoomDone : " + eventObj.getResult());
		}
        public void onLeaveRoomDone (RoomEvent eventObj)
		{
			Log ("onLeaveRoomDone : " + eventObj.getResult());
		}
		public void sendMsg(string msg)
		{
			if(state == 1)
			{
				WarpClient.GetInstance().SendChat(msg);
				Log ("enviando mensaje send");
			}
		}
		public void onUnSubscribeRoomDone (RoomEvent eventObj)
		{
			Log ("onUnSubscribeRoomDone : " + eventObj.getResult());
		}
			
		public void onGetLiveRoomInfoDone (LiveRoomInfoEvent eventObj)
		{
			Log ("onGetLiveRoomInfoDone : " + eventObj.getResult());
		}
        public void onSetCustomRoomDataDone (LiveRoomInfoEvent eventObj)
		{
			Log ("onSetCustomRoomDataDone : " + eventObj.getResult());
		}
        	public void onUpdatePropertyDone(LiveRoomInfoEvent eventObj)
        {
            if (WarpResponseResultCode.SUCCESS == eventObj.getResult())
            {
                Log ("UpdateProperty event received with success status");
            }
            else
            {
                Log ("Update Propert event received with fail status. Status is :" + eventObj.getResult().ToString());
            }
        }
        public void onLockPropertiesDone(byte result)
		{
			Log ("onLockPropertiesDone : " + result);
		}
        public void onUnlockPropertiesDone(byte result)
		{
			Log ("onUnlockPropertiesDone : " + result);
		}
    //LobbyRequestListener
    public void onJoinLobbyDone (LobbyEvent eventObj)
    {
        Log ("onJoinLobbyDone : " + eventObj.getResult());
        if(eventObj.getResult() == 0)
        {
            state = 1;
        }
    }
    	public void onGetOnlineUsersDone (AllUsersEvent eventObj)
		{
			Log ("onGetOnlineUsersDone : " + eventObj.getResult());
		}
		
		public void onGetLiveUserInfoDone (LiveUserInfoEvent eventObj)
		{
			Log ("onGetLiveUserInfoDone : " + eventObj.getResult());
		}
        	public void onSetCustomUserDataDone (LiveUserInfoEvent eventObj)
		{
			Log ("onSetCustomUserDataDone : " + eventObj.getResult());
		}
		public void onSendChatDone (byte result)
		{
			Log ("onSendChatDone result : " + result);
			
		}
		
		public void onSendPrivateChatDone(byte result)
		{
			Log ("onSendPrivateChatDone : " + result);
		}
    public void onLeaveLobbyDone (LobbyEvent eventObj)
		{
			Log ("onLeaveLobbyDone : " + eventObj.getResult());
		}
		
		public void onSubscribeLobbyDone (LobbyEvent eventObj)
		{
			Log ("onSubscribeLobbyDone : " + eventObj.getResult());
			if(eventObj.getResult() == 0)
			{
				WarpClient.GetInstance().JoinLobby();
			}
		}
		public void onUnSubscribeLobbyDone (LobbyEvent eventObj)
		{
			Log ("onUnSubscribeLobbyDone : " + eventObj.getResult());
		}
        public void onGetLiveLobbyInfoDone (LiveRoomInfoEvent eventObj)
		{
			Log ("onGetLiveLobbyInfoDone : " + eventObj.getResult());
		}
        	public void onRoomCreated (RoomData eventObj)
		{
			Log ("onRoomCreated");
		}
		public void onPrivateUpdateReceived (string sender, byte[] update, bool fromUdp)
		{
			Log ("onPrivateUpdate");
		}
		public void onRoomDestroyed (RoomData eventObj)
		{
			Log ("onRoomDestroyed");
		}
		
		public void onUserLeftRoom (RoomData eventObj, string username)
		{
			Log ("onUserLeftRoom : " + username);
		}
		
		public void onUserJoinedRoom (RoomData eventObj, string username)
		{
			Log ("onUserJoinedRoom : " + username);
		}
			public void onUserLeftLobby (LobbyData eventObj, string username)
		{
			Log ("onUserLeftLobby : " + username);
		}
		
		public void onUserJoinedLobby (LobbyData eventObj, string username)
		{
			Log ("onUserJoinedLobby : " + username);
		}
		
		public void onUserChangeRoomProperty(RoomData roomData, string sender, Dictionary<string, object> properties, Dictionary<string, string> lockedPropertiesTable)
		{
			Log ("onUserChangeRoomProperty : " + sender);
		}
			
		public void onPrivateChatReceived(string sender, string message)
		{
			Log ("onPrivateChatReceived : " + sender);
		}
		
		public void onMoveCompleted(MoveEvent move)
		{
			Log ("onMoveCompleted by : " + move.getSender());
		}
		public void onChatReceived (ChatEvent eventObj)
		{
			Log ("chat recibido ");
            Log(" chat "+eventObj.getSender() + " sended " + eventObj.getMessage());
			com.shephertz.app42.gaming.multiplayer.client.SimpleJSON.JSONNode msg =  com.shephertz.app42.gaming.multiplayer.client.SimpleJSON.JSON.Parse(eventObj.getMessage());
			//msg[0] 
			if(eventObj.getSender() != m_apppwarp.getUserName())
			{
				mensajeChat = eventObj.getMessage();//// solo enviar el msg que es el q tiene el tiempo de llegada
				nameSender = eventObj.getSender();
		        m_apppwarp.onMsgChat(mensajeChat);
				
				//m_apppwarp.movePlayer(msg["x"].AsFloat,msg["y"].AsFloat,msg["z"].AsFloat);
				//Log(msg["x"].ToString()+" "+msg["y"].ToString()+" "+msg["z"].ToString());
            }
		}
		public void onUserPaused(string locid, bool isLobby, string username)
		{
			Log("onUserPaused");
		}
		
		public void onUserResumed(string locid, bool isLobby, string username)
		{
			Log("onUserResumed");
		}
		
		public void onGameStarted(string sender, string roomId, string nextTurn)
		{
			Log("onGameStarted");
		}
		
		public void onGameStopped(string sender, string roomId)
		{
			Log("onGameStopped");
		}
    	public void onNextTurnRequest (string lastTurn)
		{
			Log("onNextTurnRequest");
		}
    private void Log(string msg)
    {
        debug = msg + "\n" + debug;
        Debug.Log(msg);
    }
}  