using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeSceneChanger : MonoBehaviour
{
    public Animator transition;


    //1. START SCREEN
    public void StartScreenToLogin() 
    {
        StartCoroutine(LoadScenes("2. Login Screen"));
    }
    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quit!");
    }
    //2. LOGIN SCREEN
    public void btnReturnToStartScreen() {
        StartCoroutine(LoadScenes("1. Start Screen"));
    }
    
    //3. TEACHER DASHBOARD
    public void btnLogoutToLogin() {
        StartCoroutine(LoadScenes("2. Login Screen"));
    }

    public void btnLessonsToLesson(){
        StartCoroutine(LoadScenes("7. Lessons"));
    }
    public void btnCreateAccountToUserManagement(){
        StartCoroutine(LoadScenes("4. Teacher UserManagement"));
    }
    //3.1 LESSONS
    public void btnReturnToStudentDash(){
        StartCoroutine(LoadScenes("3. TeacherDashboard"));
    }
    public void btnMicroscopeToMicroscopeLesson(){
        StartCoroutine(LoadScenes("Mircroscope lesson"));
    }
    //3.2 LESSON (MICROSCOPE)
    public void btnReturnToLesson(){
        StartCoroutine(LoadScenes("7. Lessons"));
    }
    
    //4. SIMULATIONS
    public void btnSimulationToSimulation(){
        StartCoroutine(LoadScenes("5. Simulations"));
    }
    //4.1
    public void btnROBOSimtoSimulation(){
        StartCoroutine(LoadScenes("5. Simulations"));
    }
    public void btnDistanceAndDisplacement(){
        StartCoroutine(LoadScenes("RoboDistance"));
    }
    //4. ADMIN DASHBOARD
    public void btnUserManagementToAdminCreateTeacherAccount() {
        StartCoroutine(LoadScenes("4. Admin UserManagement"));
    }
    // TEACHER USER MANAGEMENT
    public void btnHomeToTeacherDashboard(){
        StartCoroutine(LoadScenes("3. TeacherDashboard"));
    }
    public void btnUsermanagementToTeacherUsermanagement(){
        StartCoroutine(LoadScenes("4. Teacher UserManagement"));
    }
    //5. ADMIN USER MANAGEMENT
    public void btnHomeToAdminDashboard() {
        StartCoroutine(LoadScenes("6. Admin Dashboard"));
    }
    
    IEnumerator LoadScenes(string SceneIndex) //To control the speed of the transition
    {
        //play the animation using trigger
        transition.SetTrigger("Start");

        //Animation Transition Time speed
        yield return new WaitForSeconds(1f);

        //load the scene
        SceneManager.LoadScene(SceneIndex);
    }

}
