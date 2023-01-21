using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UserData : ScriptableObject
{
    [System.Serializable]
    public class User
    {
        // user attributes
        public string ID;
        public string username;
        public string password;
        public string firstName;
        public string middleName;
        public string lastName;
        public string section;
    }

    [System.Serializable]
    public class UserList
    {
        // user instance
        public User[] user;
    }

    public UserList userList = new UserList();
}
