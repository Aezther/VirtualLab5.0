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

    public void btnUsermanagementFromDashToTeacherDashboard(){
        StartCoroutine(LoadScenes("3. TeacherDashboard"));
    }
    public void btnUsermanagementToTeacherUsermanagement(){
        StartCoroutine(LoadScenes("4. Teacher UserManagement"));
    }
    //5. ADMIN USER MANAGEMENT
    public void lessonDnD() {
        StartCoroutine(LoadScenes("Distance and Displacement Lesson"));
    }

    ///Lessons
    public void lessonMicroscope() {
        StartCoroutine(LoadScenes("Mircroscope lesson"));
    }

    public void lessonSpeednVelocity() {
        StartCoroutine(LoadScenes("Lesson (Speed and Velocity)"));
    }

    public void lessonFaults() {
        StartCoroutine(LoadScenes("Types of Fault"));
    }

    ///Simulations
    public void simChooseDnD() {
        StartCoroutine(LoadScenes("Choose Distance&Displacement Simulations 1"));
    }
    public void simChooseSnV() {
        StartCoroutine(LoadScenes("Choose SpeedVelocity"));
    }
    public void simRobo() {
        StartCoroutine(LoadScenes("RoboDistance"));
    }
    public void simMicroscopeMenu() {
        StartCoroutine(LoadScenes("1. Microscope Start Screen (Temp)"));
    }
    public void simMicroscopeFocus() {
        StartCoroutine(LoadScenes("2. Explore Microscope Specimen"));
    }
    public void simMicroscopeParts() {
        StartCoroutine(LoadScenes("3. Learning Microscope Parts"));
    }
    public void simFarm() {
        StartCoroutine(LoadScenes("Distance and Displacement"));
    }
    public void simCity() {
        StartCoroutine(LoadScenes("CityRoad"));
    }
    public void simMarble() {
        StartCoroutine(LoadScenes("MarbleRace"));
    }
    public void simFaults() {
        StartCoroutine(LoadScenes("TypeOfFaultSim"));
    }
    
    public void TeacherMenuToTeacherUserManagement(){
        StartCoroutine(LoadScenes("4. New Teacher UserManagement"));
    }
    public void TeacherMenuToAssessmentRecords(){
        StartCoroutine(LoadScenes("8. Teacher Assessment Records"));
    }
    public void UsermanagementToTeacheRMainMenu(){
        StartCoroutine(LoadScenes("3. TeacherDashboard"));
    }

    public void AdminMenuToAssessmentRecords(){
        StartCoroutine(LoadScenes("8. Admin Assessment Records 1"));
    }
    public void AdminUsermanagementButtonToAdminMainMenu(){
        StartCoroutine(LoadScenes("6. Admin Dashboard"));
    }
    public void AdminAssessmentRecordsToMainMenu(){
        StartCoroutine(LoadScenes("6. Admin Dashboard"));
    }
    public void LessonManagementToMainMenu(){
        StartCoroutine(LoadScenes("3. TeacherDashboard"));
    }
    
    public void MainMenuToLessonManagement(){
        StartCoroutine(LoadScenes("Lesson Management"));
    }
    public void NewUserManagementTeacherToMainMenuTeacher(){
        StartCoroutine(LoadScenes("3. TeacherDashboard"));
    }
    public void MainMenuToNewUserManagement(){
        StartCoroutine(LoadScenes("4. Teacher UserManagement"));
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
