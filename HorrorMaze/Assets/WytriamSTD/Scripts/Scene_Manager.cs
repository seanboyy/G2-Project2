using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is intended to be inherited by every Scene_Manager class I use (not to be confused with SceneManger)
 * It includes some standard scene manager items, like access the Constants class. 
 * Scene_Manager's that inherit from this should be called SM_SceneName
 */

namespace WytriamSTD
{

    public abstract class Scene_Manager : MonoBehaviour
    {
        //protected WytriamSTD.Constants constants = WytriamSTD.Constants.getInstance();
        //protected WytriamSTD.Announcements announcements = WytriamSTD.Announcements.getInstance();
        
        // Use this for initialization
        void Start()
        {
            Debug.Log("Scene_Manager::Start() - You are using the generic Scene_Manager. Please create a SM_SceneName that inherits from this class instead and override the Start() method.");
        }

        public void Announce(string announcement)
        {
            //Debug.Log("Scene_Manager::announce() - " + announcement);
            Announcements.getInstance().DisplayAnnouncement(announcement);
        }

        public void Announce(string announcement, int duration)
        {
            //Debug.Log("Scene_Manager::announce() - " + announcement);
            Announcements.getInstance().DisplayAnnouncement(announcement, duration);
        }

        public void MuteAnnoucements()
        {
            Announcements.getInstance().disableAnnouncements();
        }

        public void HearAnnouncements()
        {
            Announcements.getInstance().enableAnnouncements();
        }

        public abstract void DoEndOfLevel();
    }
}
